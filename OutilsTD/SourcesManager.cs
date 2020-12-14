#if !NO_SOURCE
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// those don't require sources but are useless if sources don't exists
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System;
#endif

namespace OutilsTD
{
    public class SourcesManager
    {
        private SourcesManager() { }

#if !NO_SOURCE
        static Dictionary<string, KeyValuePair<List<MethodDeclarationSyntax>, Dictionary<string, string>>> sourcesList =
            new Dictionary<string, KeyValuePair<List<MethodDeclarationSyntax>, Dictionary<string, string>>>();

        static KeyValuePair<List<MethodDeclarationSyntax>, Dictionary<string, string>> GetTypeMethods(string typeName)
        {
            if(!sourcesList.ContainsKey(typeName))
            {
                string sourceContents = ReadSource(typeName);
                if (sourceContents == null || sourceContents.Trim().Length == 0) throw new KeyNotFoundException();

                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceContents);
                List<MethodDeclarationSyntax> methodDeclarations = syntaxTree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().ToList();
                sourcesList.Add(typeName, new KeyValuePair<List<MethodDeclarationSyntax>, Dictionary<string, string>>(methodDeclarations, new Dictionary<string, string>()));
            }

            return sourcesList[typeName];
        }

        public static string GetMethodSource(string typeName, string methodName)
        {
            KeyValuePair<List<MethodDeclarationSyntax>, Dictionary<string, string>> methods;
            try
            {
                methods = GetTypeMethods(typeName);
            } catch(KeyNotFoundException)
            {
                return null;
            }


            if (!methods.Value.ContainsKey(methodName))
            {
                string methodSource = methods.Key.Where(md => md.Identifier.ValueText.Equals(methodName)).FirstOrDefault().ToFullString();
                List<string> methodLines = methodSource.Split('\n').ToList();
                if(methodLines.Count > 0)
                {
                    // code to remove spaces at the start of each lines

                    // we first remove empty lines at the start, but not empty lines inside the code
                    bool hasFoundFirstCodeLine = false;
                    methodLines = methodLines.ToList().FindAll(line =>
                    {
                        if (hasFoundFirstCodeLine) return true;
                        else if (line.Trim().Length > 0)
                        {
                            hasFoundFirstCodeLine = true;
                            return true;
                        }
                        else return false;
                    });

                    // then we count the spaces at the first line, it will give the maximum count of spaces to remove
                    string firstLine = methodLines[0]; // methodLines.Find(line => line.Trim().Length > 0 && line.Contains("static"));
                    int spacesCount = firstLine.TakeWhile(char.IsWhiteSpace).Count();

                    // then we rejoin all the lines with the starting spaces removed
                    methodSource = string.Join("\n", methodLines.Select(line =>
                    {
                        for(int i = 0; i < spacesCount; i++)
                        {
                            if (line.Length == 0 || !char.IsWhiteSpace(line[0])) break;
                            else line = line.Substring(1);
                        }

                        return line;
                    }));
                }
                methods.Value.Add(methodName, methodSource);
            }

            return methods.Value[methodName];
        }

        static string sourcesFolder = "";
        public static void InitSources(string appFolder)
        {
            sourcesFolder = Path.Combine(appFolder.Trim(), "AlgoEsilv");
        }

        static string[] resourcesNames = null;

        static string ReadSource(string typeName)
        {
            var assembly = Assembly.GetEntryAssembly();
            if (resourcesNames == null) resourcesNames = assembly.GetManifestResourceNames();

            string resourceName = "sources." + typeName;
            if (resourcesNames.Contains(resourceName))
            {
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
            else if (sourcesFolder.Length > 0)
            {
                string sourceFilename = Path.Combine(sourcesFolder, typeName + ".cs");
                if (File.Exists(sourceFilename)) return File.ReadAllText(sourceFilename);
                else return null;
            }
            else return null;
        }
#endif
    }
}
