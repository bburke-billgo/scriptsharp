// BreakStatement.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class BreakStatement : Statement {

        public BreakStatement()
            : base(StatementType.Break) {
        }
    }
}
