using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;

namespace Net.Junian.SDEmu.Lib
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

        //public Boolean Compile(string script)
        //{
        //    return Compile(new string[1] { script });
        //}

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
                "class SDEmuScriptRunner" +
                "{" +
                    "public SDEmuScriptRunner(){}" +
                    "public static string Execute(string message)" +
                    "{\n";
            string closingSource =
                        "\nreturn \"\";" +
                    "}" +
                "}";

            stringBuilder.Append(openingSource);
            stringBuilder.Append(script);
            stringBuilder.Append(closingSource);

            //string[] sources = new string[script.Length + 2];
            string sources = stringBuilder.ToString();
            //Console.WriteLine(sources);
            //sources[0] = openingSource;
            //Array.Copy(script, 0, sources, 1, script.Length);
            //sources[sources.Length-1] = closingSource;

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
