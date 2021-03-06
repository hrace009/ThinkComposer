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
// File   : DomainMaintainer.RelationshipDefClusters.cs
// Object : Instrumind.ThinkComposer.Composer.DefinitorMaintenance.DomainMaintainer (Class)
//
// Date       Author             Changes
// ---------- ------------------ -------------------------------------------------------------
// 2013.08.11 Néstor Sánchez A.  Creation
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using Instrumind.Common;
using Instrumind.Common.EntityBase;
using Instrumind.Common.EntityDefinition;
using Instrumind.Common.Visualization;
using Instrumind.Common.Visualization.Widgets;

using Instrumind.ThinkComposer;
using Instrumind.ThinkComposer.ApplicationProduct;
using Instrumind.ThinkComposer.Composer;
using Instrumind.ThinkComposer.Definitor.DefinitorMaintenance;
using Instrumind.ThinkComposer.Definitor.DefinitorUI.Widgets;
using Instrumind.ThinkComposer.Model;
using Instrumind.ThinkComposer.Model.GraphModel;
using Instrumind.ThinkComposer.MetaModel;
using Instrumind.ThinkComposer.MetaModel.GraphMetaModel;

/// Maintenance services of Domain related Definitions.
namespace Instrumind.ThinkComposer.Definitor.DefinitorMaintenance
{
    /// <summary>
    /// Provides maintenance services for a Domain entity. Marker Definitions part.
    /// </summary>
    public static partial class DomainMaintainer
    {
        public static void SetRelationshipDefClustersMaintainer(ItemsGridMaintainer<Domain, FormalPresentationElement> TargetMaintainer)
        {
            TargetMaintainer.CreateItemOperation = RelationshipDefClusterCreate;
            TargetMaintainer.DeleteItemOperation = RelationshipDefClusterDelete;
            TargetMaintainer.EditItemOperation = RelationshipDefClusterEdit;
            TargetMaintainer.CloneItemOperation = RelationshipDefClusterClone;
        }

        public static FormalPresentationElement RelationshipDefClusterCreate(Domain OwnerEntity, IList<FormalPresentationElement> EditedList)
        {
            int NewNumber = EditedList.Count + 1;
            string NewName = "RelationshipDefCluster" + NewNumber.ToString();
            var Definitor = new FormalPresentationElement(NewName, NewName.TextToIdentifier(), "", Display.GetAppImage("def_cluster.png"));

            if (RelationshipDefClusterEdit(OwnerEntity, EditedList, Definitor))
                return Definitor;

            return null;
        }

        public static bool RelationshipDefClusterEdit(Domain OwnerEntity, IList<FormalPresentationElement> EditedList, FormalPresentationElement RelationshipDefCluster)
        {
            var InstanceController = EntityInstanceController.AssignInstanceController(RelationshipDefCluster);
            InstanceController.StartEdit();

            /* POSTPONED: Ability to edit and reorganize Relationship-Defs via its Cluster-Key.
            var Expositor = new EntityPropertyExpositor(RelationshipDefCluster.__ClusterKey.TechName);
            Expositor.LabelMinWidth = 90; */

            var EditPanel = Display.CreateEditPanel(RelationshipDefCluster, null, true, null, null, true, false, true /*, Expositor*/);

            return InstanceController.Edit(EditPanel, "Edit Relationship-Def Cluster - " + RelationshipDefCluster.ToString()).IsTrue();
        }

        public static bool RelationshipDefClusterDelete(Domain OwnerEntity, IList<FormalPresentationElement> EditedList, FormalPresentationElement RelationshipDefCluster)
        {
            var Result = Display.DialogMessage("Confirmation", "Are you sure you want to Delete the '" + RelationshipDefCluster.Name + "' Relationship-Def Cluster?",
                                               EMessageType.Question, System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxResult.No);
            return (Result == MessageBoxResult.Yes);
        }

        public static FormalPresentationElement RelationshipDefClusterClone(Domain OwnerEntity, IList<FormalPresentationElement> EditedList, FormalPresentationElement RelationshipDefCluster)
        {
            var Result = new FormalPresentationElement(RelationshipDefCluster.Name, RelationshipDefCluster.TechName, RelationshipDefCluster.Summary, RelationshipDefCluster.Pictogram);

            var NamesWereEquivalent = (Result.TechName == Result.Name.TextToIdentifier());
            Result.Name = Result.Name + "(copy)";   // Auto-update of TechName when equivalents
            if (!NamesWereEquivalent) Result.TechName = Result.TechName + "_copy";

            return Result;
        }
    }
}
