using Fody;
using System.IO;
using System.Collections.Generic;
using Mono.Cecil;

namespace SourceTD.Fody
{
    public class ModuleWeaver : BaseModuleWeaver
    {
        public override void Execute()
        {
            List<string> sourceTypes = new List<string>();

            foreach(TypeDefinition typeDef in ModuleDefinition.GetTypes())
            {
                bool typeAdded = false;
                foreach (MethodDefinition methodDef in typeDef.Methods)
                {
                    foreach(CustomAttribute customAttribute in methodDef.CustomAttributes)
                    {
                        if(customAttribute.AttributeType.FullName == "OutilsTD.ExerciceAttribute")
                        {
                            if(customAttribute.HasFields)
                            {
                                foreach(CustomAttributeNamedArgument arg in customAttribute.Fields)
                                {
                                    if (arg.Name == "exerciceSource" && ((bool)arg.Argument.Value) == true)
                                    {
                                        string typeName = typeDef.Name;
                                        sourceTypes.Add(typeName);

                                        typeAdded = true;
                                        break;
                                    }
                                }

                                if (typeAdded) break;
                            }
                        }
                    }

                    if (typeAdded) break;
                }
            }

            if (sourceTypes.Count > 0)
            {
                foreach (string typeName in sourceTypes)
                {
                    string[] parts = typeName.Split('_');
                    if (parts.Length == 2)
                        ModuleDefinition.Resources.Add(new EmbeddedResource("sources." + typeName, ManifestResourceAttributes.Private, new FileStream(Path.Combine(Directory.GetCurrentDirectory(), parts[0], typeName + ".cs"), FileMode.Open, FileAccess.Read)));
                }
            }
        }

        public override bool ShouldCleanReference => true;

        public override IEnumerable<string> GetAssembliesForScanning()
        {
            yield return "netstandard";
            yield return "mscorlib";
        }
    }
}
