using System;
using System.Collections.Generic;
using System.Text;

namespace RuntimeCompiler
{
    public class CompiledAssembly
    {
        public string sourceHash = null;
        public string compiledHash = null;

        public CompiledAssembly()
        {

        }

        public CompiledAssembly(string sourceHash, string compiledHash)
        {
            this.sourceHash = sourceHash;
            this.compiledHash = compiledHash;
        }
    }
}
