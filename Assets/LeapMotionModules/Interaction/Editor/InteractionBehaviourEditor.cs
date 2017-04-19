﻿using UnityEditor;

namespace Leap.Unity.UI.Interaction {

  [CanEditMultipleObjects]
  [CustomEditor(typeof(InteractionBehaviour), editorForChildClasses: true)]
  public class InteractionBehaviourEditor : CustomEditorBase<InteractionBehaviour> {

    private EnumEventTableEditor _tableEditor;

    protected override void OnEnable() {
      base.OnEnable();

      deferProperty("_eventTable");
      specifyCustomDrawer("_eventTable", drawEventTable);

      specifyConditionalDrawing(() => !target.ignoreGrasping,
                   "_allowMultiGrasp",
                   "_moveObjectWhenGrasped",
                   "graspedMovementType",
                   "graspHoldWarpingEnabled__curIgnored");
    }

    private void drawEventTable(SerializedProperty property) {
      if (_tableEditor == null) {
        _tableEditor = new EnumEventTableEditor(property, typeof(InteractionBehaviour.EventType));
      }

      _tableEditor.DoGuiLayout();
    }
  }
}
