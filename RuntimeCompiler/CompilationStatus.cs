using System;
using System.Collections.Generic;
using System.Text;

namespace RuntimeCompiler
{
    public class CompilationStatus
    {
        public int fileVersion = 1;

        public DateTime compilationTime;
        public Dictionary<string, CompiledAssembly> assemblies;

        public CompilationStatus(DateTime compilationTime, Dictionary<string, CompiledAssembly> assemblies)
        {
            this.compilationTime = compilationTime;
            this.assemblies = assemblies;
        }

        public static CompilationStatus Default()
        {
            return new CompilationStatus(DateTime.Now, new Dictionary<string, CompiledAssembly>());
        }
    }
}
