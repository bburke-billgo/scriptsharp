// CheckedNode.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class CheckedNode : StatementNode {

        private BlockStatementNode _body;

        public CheckedNode(Token token, BlockStatementNode body)
            : base(ParseNodeType.Checked, token) {
            _body = (BlockStatementNode)GetParentedNode(body);
        }
    }
}
