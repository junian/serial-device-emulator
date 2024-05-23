using Juniansoft.SDEmu.Services;
using System;
using System.Collections.Generic;
using System.IO;
using WixSharp;

namespace Juniansoft.SDEmu.Setup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string TargetFramework = "net462";
            const string ProgramFilesDir = "%ProgramFiles%";
            const string ProgramMenuDir = "%ProgramMenu%";
            const string InstallDir = "[INSTALLDIR]";

            var assembly = new AssemblyService(typeof(AssemblyService).Assembly);

            var buildConfigs = new Dictionary<string, WixSharp.Platform>
            {
                ["ARM64"] = Platform.arm64,
                ["x64"] = Platform.x64,
                ["x86"] = Platform.x86,
            };

            foreach (var b in buildConfigs)
            {
                var project = new Project(
                    name: $"{assembly.Name}",
                    new Dir(
                        targetPath: Path.Combine(
                            ProgramFilesDir,
                            assembly.Company,
                            assembly.Product),
                        new Files(
                            sourcePath: Path.Combine(
                                "..",
                                $"{assembly.Name}",
                                "bin",
                                b.Key,
                                assembly.Configuration,
                                TargetFramework,
                                "*.*"),
                            filter: f => !f.EndsWith(".obj"))
                        {
                        },
                        new ExeFileShortcut(
                            name: $"Uninstall {assembly.Product}",
                            target: "[System64Folder]msiexec.exe",
                            arguments: "/x [ProductCode]")
                    ),
                    new Dir(
                        targetPath: Path.Combine(
                            ProgramMenuDir,
                            assembly.Company,
                            assembly.Product),
                        new ExeFileShortcut(
                            name: $"{assembly.Product}",
                            target: Path.Combine(InstallDir, $"{assembly.Name}.exe"),
                            arguments: "")
                        {
                            WorkingDirectory = InstallDir
                        }/*,
                        new ExeFileShortcut(
                            name: $"Uninstall {assembly.Product}",
                            target: "[System64Folder]msiexec.exe",
                            arguments: "/x [ProductCode]")*/
                    ),
                    new EnvironmentVariable("Path", InstallDir)
                    {
                        Id = "Path_INSTALLDIR",
                        Action = EnvVarAction.set,
                        Part = EnvVarPart.last,
                        Permanent = false,
                        System = true,
                    })
                    {
                        // DO NOT Change, should be {1D32E0B8-D829-4969-B546-FA57B6ED7189}
                        // Same with UpgradeCode
                        GUID = new Guid("1D32E0B8-D829-4969-B546-FA57B6ED7189"),
                        Name = assembly.Product,
                        Version = assembly.Version,
                        MajorUpgradeStrategy = MajorUpgradeStrategy.Default,

                    };

                project.Name = $"{assembly.Product} ({b.Key.ToLower()}) - v{assembly.Version.ToString(3)}";
                project.Platform = b.Value;
                if (b.Value == Platform.arm64)
                    project.InstallerVersion = 500;

                project.ControlPanelInfo.ProductIcon = Path.Combine(
                            "..",
                            "..",
                            "assets",
                            "Favicon.ico");

                project.MajorUpgradeStrategy.RemoveExistingProductAfter = Step.InstallInitialize;
                project.LicenceFile = Path.Combine(".", "LICENSE.rtf");
                project.ResolveWildCards(pruneEmptyDirectories: true)
                       .FindFirstFile($"{assembly.Name}.exe")
                       .Shortcuts = new[]
                       {
                       new FileShortcut($"{assembly.Name}.exe", "%Desktop%")
                       };

                Compiler.PreserveTempFiles = true;
                Compiler.EmitRelativePaths = false;

                project
                    .BuildMsi(path: Path.Combine(
                        "wix",
                        assembly.Configuration,
                        TargetFramework,
                        $"{assembly.Product.Replace(" ", "")}-v{assembly.Version.ToString(3)}-{b.Key.ToLower()}.msi"));

            }
        }
    }
}