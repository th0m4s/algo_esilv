using Microsoft.CSharp;
using Newtonsoft.Json;
using OutilsTD;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RuntimeCompiler
{
    public class CompilerExercices
    {
        string appFolder;

        string filesFolder;
        string compiledFolder;
        string statusFile;

        public bool HasCompiled = false;

        List<string> assemblyFilenames = new List<string>();
        public bool HasAssemblies
        {
            get
            {
                return assemblyFilenames.Count > 0;
            }
        }

        public CompilerExercices(string appFolder)
        {
            this.appFolder = appFolder;

            this.filesFolder = Path.Combine(appFolder, "AlgoEsilv");
            this.compiledFolder = Path.Combine(this.filesFolder, "assemblies");
            this.statusFile = Path.Combine(this.compiledFolder, "status.json");
        }

        CompilationStatus compilationStatus;
        Dictionary<string, string> shouldCompile = new Dictionary<string, string>();

        public bool CheckFiles()
        {
            if (Directory.Exists(filesFolder))
            {
                if (!Directory.Exists(compiledFolder)) Directory.CreateDirectory(compiledFolder);
                if (!File.Exists(statusFile)) File.WriteAllText(statusFile, JsonConvert.SerializeObject(CompilationStatus.Default()));

                compilationStatus = JsonConvert.DeserializeObject<CompilationStatus>(File.ReadAllText(statusFile));

                string sourcePattern = @"^(?<name>S\d+_TD\d+)\.cs$";
                foreach (string filePath in Directory.GetFiles(filesFolder))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string fileName = fileInfo.Name;

                    Match match = Regex.Match(fileName, sourcePattern);
                    if (match.Success)
                    {
                        fileName = match.Groups["name"].Value;
                        string sha256sum = sha256file(filePath);
                        if (!compilationStatus.assemblies.ContainsKey(fileName) || compilationStatus.assemblies[fileName].sourceHash != sha256sum || !File.Exists(Path.Combine(compiledFolder, fileName + ".dll")))
                            shouldCompile.Add(fileName, sha256sum);
                    }
                }

                string dllPattern = @"^(?<name>.+)\.dll$";
                foreach (string filePath in Directory.GetFiles(compiledFolder))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string fileName = fileInfo.Name;

                    Match match = Regex.Match(fileName, dllPattern);
                    if (match.Success)
                    {
                        fileName = match.Groups["name"].Value;
                        assemblyFilenames.Add(fileName);
                        string sha256sum = sha256file(filePath);
                        if (!compilationStatus.assemblies.ContainsKey(fileName) || compilationStatus.assemblies[fileName].compiledHash != sha256sum)
                            shouldCompile.Add(fileName, null);
                    }
                }

                return shouldCompile.Count > 0;

            } else return false;
        }

        public bool Compile()
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            foreach (string requiredAssembly in new string[] { "OutilsTD", "mscorlib", "System", "netstandard" })
                parameters.ReferencedAssemblies.Add(Assembly.Load(requiredAssembly).Location);
             
            parameters.GenerateInMemory = false;
            parameters.GenerateExecutable = false;

            bool error = false;
            int successCount = 0;
            Dictionary<string, CompiledAssembly> newCompiled = new Dictionary<string, CompiledAssembly>();
            List<string> removeInStatus = new List<string>();

            foreach(KeyValuePair<string, string> compilePair in shouldCompile)
            {
                string baseName = compilePair.Key;
                string sourceFile = Path.Combine(filesFolder, baseName + ".cs");
                if (File.Exists(sourceFile))
                {
                    string outputFile = Path.Combine(compiledFolder, baseName + ".dll");
                    parameters.OutputAssembly = outputFile;

                    CompilerResults results = provider.CompileAssemblyFromFile(parameters, sourceFile);
                    if (results.Errors.HasErrors)
                    {
                        error = true;
                    } else
                    {
                        string sourceHash = compilePair.Value;
                        if (sourceHash == null) sourceHash = sha256file(sourceFile);

                        string compiledHash = sha256file(outputFile);
                        newCompiled.Add(baseName, new CompiledAssembly(sourceHash, compiledHash));

                        assemblyFilenames.Add(baseName);
                        successCount++;
                    }
                } else removeInStatus.Add(baseName);
            }

            if(successCount > 0)
            {
                HasCompiled = true;

                foreach (string toRemove in removeInStatus)
                    compilationStatus.assemblies.Remove(toRemove);

                foreach(KeyValuePair<string, CompiledAssembly> newAssembly in newCompiled)
                {
                    string newAssemblyName = newAssembly.Key;
                    if (compilationStatus.assemblies.ContainsKey(newAssemblyName))
                        compilationStatus.assemblies.Remove(newAssemblyName);

                    compilationStatus.assemblies.Add(newAssemblyName, newAssembly.Value);
                }

                compilationStatus.compilationTime = DateTime.Now;
                File.WriteAllText(statusFile, JsonConvert.SerializeObject(compilationStatus));
            }

            return !error;
        }

        public List<Assembly> LoadedAssemblies = new List<Assembly>();

        public void LoadAssemblies()
        {
            foreach(string assemblyName in assemblyFilenames)
                LoadedAssemblies.Add(Assembly.LoadFrom(Path.Combine(compiledFolder, assemblyName + ".dll")));
        }

        private static string sha256file(string filePath)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                    return Convert.ToBase64String(sha256.ComputeHash(fileStream));
            }
        }
    }
}
