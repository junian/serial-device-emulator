using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JunianDev.SDEmu.Services
{
    public class AssemblyService
    {
        private static readonly AssemblyService _current = new AssemblyService();

        public static AssemblyService Current => _current;

        private readonly Assembly _assembly;

        private readonly AssemblyName _assemblyName;
        private readonly System.Version _version;
        private readonly string _location;
        private readonly string _path;

        public AssemblyService(Assembly assembly = null)
        {
            _assembly = assembly ?? Assembly.GetExecutingAssembly();

            _assemblyName = _assembly?.GetName();
            _name = _assemblyName?.Name;
            _version = _assemblyName?.Version;
            _location = _assembly?.Location;
            _path = System.IO.Path.GetDirectoryName(_location);
            _defaultTitle = System.IO.Path.GetFileNameWithoutExtension(_location);

            _assembly.Modules.First().GetPEKind(out var pekind, out var machine);
            PEKind = pekind;
            Arch = GetArch(machine); ;
        }

        private string GetArch(ImageFileMachine mach)
        {
            if (mach == ImageFileMachine.I386)
                return "x86";

            if (mach == ImageFileMachine.AMD64)
                return "x86_64";

            if (mach == ImageFileMachine.IA64)
                return "ia64";

            if (mach == ImageFileMachine.ARM)
                return "arm";

            if ((int)mach == 43620)
                return "arm64";

            return "Unknown";
        }

        public PortableExecutableKinds PEKind { get; private set; }
        public string Arch { get; private set; }

        private string GetStringAttribute<T>(Func<T, string> getStringFunc, string defaultValue = "")
        {
            var attr = (T)_assembly?
                .GetCustomAttributes(typeof(T), false)?
                .FirstOrDefault();
            return getStringFunc?.Invoke(attr) ?? defaultValue;
        }

        private readonly string _name = default;
        public string Name
            => _name;

        private readonly string _defaultTitle;
        private string _title;
        public string Title
            => _title ?? (_title = GetStringAttribute<AssemblyTitleAttribute>(
                x => x?.Title,
                _defaultTitle));

        public System.Version Version
            => _version;

        private string _description = default;
        public string Description
            => _description ?? (_description = GetStringAttribute<AssemblyDescriptionAttribute>(x => x?.Description));

        private string _product = default;
        public string Product
            => _product ?? (_product = GetStringAttribute<AssemblyProductAttribute>(x => x?.Product));

        private string _copyright = default;
        public string Copyright
            => _copyright ?? (_copyright = GetStringAttribute<AssemblyCopyrightAttribute>(x => x?.Copyright));

        private string _company = default;
        public string Company
            => _company ?? (_company = GetStringAttribute<AssemblyCompanyAttribute>(x => x?.Company));

        private string _guid = default;
        public string Guid
            => _guid ?? (_guid = GetStringAttribute<GuidAttribute>(x => x?.Value));

        private string _configuration = default;
        public string Configuration
            => _configuration ?? (_configuration = GetStringAttribute<AssemblyConfigurationAttribute>(x => x?.Configuration));

        public string Path
            => _path;
    }
}
