﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.CSharp
{
    internal sealed partial class LocalRewriter
    {
        public override BoundNode VisitGotoStatement(BoundGotoStatement node)
        {
            // we are removing the label expressions from the bound tree because this expression is no longer needed
            // for the emit phase. It is even doing harm to e.g. the stack depth calculation because because this expression
            // would not need to be pushed to the stack.
            BoundExpression caseExpressionOpt = null;

            // we are removing the label expressions from the bound tree because this expression is no longer needed
            // for the emit phase. It is even doing harm to e.g. the stack depth calculation because because this expression
            // would not need to be pushed to the stack.
            BoundLabel labelExpressionOpt = null;

            return AddSequencePoint(node.Update(node.Label, caseExpressionOpt, labelExpressionOpt));
        }

        public override BoundNode VisitLabel(BoundLabel node)
        {
            // we are removing the label expressions from the bound tree because this expression is no longer needed
            // for the emit phase. It is even doing harm to e.g. the stack depth calculation because because this expression
            // would not need to be pushed to the stack.
            return null;
        }

        public override BoundNode VisitSwitchLabel(BoundSwitchLabel node)
        {
            // we are removing the label expressions from the bound tree because this expression is no longer needed
            // for the emit phase. It is even doing harm to e.g. the stack depth calculation because because this expression
            // would not need to be pushed to the stack.
            return node.Update(node.Label, expressionOpt: null);
        }
    }
}
