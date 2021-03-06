﻿// -------------------------------------------------------------------------------------------
// Instrumind ThinkComposer
//
// Copyright (C) 2011-2015 Néstor Marcel Sánchez Ahumada.
// https://github.com/nmarcel/ThinkComposer
//
// This file is part of ThinkComposer, which is free software licensed under the GNU General Public License.
// It is provided without any warranty. You should find a copy of the license in the root directory of this software product.
// -------------------------------------------------------------------------------------------
//
// Project: Instrumind ThinkComposer v1.0
// File   : SimpleNode.cs
// Object : Instrumind.Common.SimpleNode (Class)
//
// Date       Author             Changes
// ---------- ------------------ -------------------------------------------------------------
// 2009.06.23 Néstor Sánchez A.  Creation
//

using System;

/// Library of general purpose components and features across Instrumind products.
namespace Instrumind.Common
{
    /// <summary>
    /// Node for SimpleList population.
    /// </summary>
    /// <typeparam name="TDatum">Type of the contained data.</typeparam>
    [Serializable]
    public class SimpleNode<TData>
    {
        /// <summary>
        /// Node content.
        /// </summary>
        internal TData Data;

        /// <summary>
        /// Reference to the next node.
        /// </summary>
        internal SimpleNode<TData> NextNode;
    }
}