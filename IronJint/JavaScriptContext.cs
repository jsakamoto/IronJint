using System;
using System.Collections.Generic;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronJint.Runtime
{
    /// <summary>
    /// JavaScriptContext
    /// </summary>
    public class JavaScriptContext : LanguageContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptContext"/> class.
        /// </summary>
        /// <param name="domainManager">The domain manager.</param>
        /// <param name="options">The options.</param>
        public JavaScriptContext(ScriptDomainManager domainManager, IDictionary<string, object> options)
            : base(domainManager)
        {
        }

        /// <summary>
        /// Parses the source code within a specified compiler context.
        /// The source unit to parse is held on by the context.
        /// </summary>
        /// <param name="sourceUnit"></param>
        /// <param name="options"></param>
        /// <param name="errorSink"></param>
        /// <returns>
        ///   <b>null</b> on failure.
        /// </returns>
        /// <remarks>
        /// Could also set the code properties and line/file mappings on the source unit.
        /// </remarks>
        public override ScriptCode CompileSourceCode(SourceUnit sourceUnit, CompilerOptions options, ErrorSink errorSink)
        {
            return new JavaScriptCode(sourceUnit);
        }
    }
}
