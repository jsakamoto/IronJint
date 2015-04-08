using System;
using Jint;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronJint
{
    /// <summary>
    /// JavaScriptCode
    /// </summary>
    public class JavaScriptCode : ScriptCode
    {
        /// <summary>
        /// Gets or sets the jint engine.
        /// </summary>
        /// <value>
        /// The jint engine.
        /// </value>
        public Engine JintEngine { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptCode"/> class.
        /// </summary>
        /// <param name="sourceUnit">The source unit.</param>
        public JavaScriptCode(SourceUnit sourceUnit)
            : base(sourceUnit)
        {
            JintEngine = new Engine();
        }

        /// <summary>
        /// Runs the specified scope.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns></returns>
        public override object Run(Scope scope)
        {
            var scopeStrage = (ScopeStorage)scope.Storage;
            foreach (var item in scopeStrage.GetItems())
            {
                JintEngine.SetValue(item.Key, item.Value);
            }

            var code = this.SourceUnit.GetCode();
            JintEngine.Execute(code);

            return null;
        }
    }
}
