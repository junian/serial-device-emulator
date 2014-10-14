using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;

namespace Net.Junian.SDEmu
{
    public class SDEmuScript
    {
        #region Private Variables

        private object sdemuScript;

        #endregion

        #region Properties

        public bool IsCompiled { get; private set; }
        public CompilerErrorCollection Errors { get; private set; }

        #endregion

        public SDEmuScript()
        {
            IsCompiled = false;
        }

        /// <summary>
        /// compile script
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public Boolean Compile(string script)
        {
            IsCompiled = false;

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();

            compilerParameters.GenerateExecutable = false;
            compilerParameters.GenerateInMemory = true;
            compilerParameters.ReferencedAssemblies.Add("System.dll");

            StringBuilder stringBuilder = new StringBuilder();
		
            string openingSource =
                "using System;" +
            	"using System.Text;" +
            	"using System.IO.Ports;" +
            	"using System.Collections.Generic;" +
            	"class CustomDict" +
            	"{ " +
            	"   private Dictionary<string, object> variables = new Dictionary<string, object>();" +
            	"   public object this[string key]" +
            	    "{" +
            	    "    get { " +
            	    "      if(variables == null) variables = new Dictionary<string, object>();" +
            	    "      if(!variables.ContainsKey(key)) return null;" +
            	    "      return variables[key];" +
                    "    }" +            	
            	    "    set { " +
            	    "      if(variables == null) variables = new Dictionary<string, object>();" +
            	    "      if(!variables.ContainsKey(key)) variables.Add(key, value);" +
            	    "      else variables[key] = value;" +
            	    "    }" +
            	    "}" +
            	"} " +
                "class SDEmuScriptRunner" +
                "{" +
            	    "private CustomDict vars = new CustomDict();" +
            	    "private bool initVar = true;" +
            	    "public SDEmuScriptRunner(){}" +
                    "private bool init() { bool returnVal = false; if(initVar) { returnVal = true; initVar = false; } return returnVal; } " +            	
            	    "private string ToHex(byte[] bytes)" +
            	    "{\n" +
            	    "  if(bytes == null) return string.Empty;" +
            	    "  StringBuilder sb = new StringBuilder();" +
            	    "  foreach(byte b in bytes) sb.Append(string.Format(\"{0:X}\", b)).Append(\" \");" +
            	    "  return sb.ToString();" +
            	    "}" +
                    "public string Execute(string message)" +
                    "{\n";
            
            string closingSource =
            	        "return \"\";" +
                    "}" +
                "}";

            stringBuilder.Append(openingSource);
            stringBuilder.Append(script);
            stringBuilder.Append(closingSource);

            string sources = stringBuilder.ToString();

            CompilerResults compilerResults = codeProvider.CompileAssemblyFromSource(compilerParameters, sources);

            Errors = compilerResults.Errors;
            
            if (compilerResults.Errors.Count == 0 && compilerResults.CompiledAssembly != null)
            {
                Type objType = compilerResults.CompiledAssembly.GetType("SDEmuScriptRunner");
                try
                {
                    if (objType != null)
                    {
                        sdemuScript = Activator.CreateInstance(objType);
                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                    return false;
                }
                IsCompiled = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// get response based on script
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string GetResponse(string message)
        {
            string response = "";
            object[] parameters = new object[1] { message };
            if (IsCompiled && sdemuScript != null)
            {
                MethodInfo method = sdemuScript.GetType().GetMethod("Execute");
                response = (string)method.Invoke(sdemuScript, parameters);
            }
            return response;
        }
    }
}
