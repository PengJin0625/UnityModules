﻿using UnityEngine;
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor;
#endif

[AddComponentMenu("")]
[LeapGuiTag("Sprite")]
public class LeapGuiSpriteFeature : LeapGuiFeature<LeapGuiSpriteData> {
  public string propertyName = "_MainTex";
  public UVChannelFlags channel = UVChannelFlags.UV0;

#if UNITY_EDITOR
  public bool AreAllSpritesPacked() {
    foreach (var dataObj in data) {
      if (dataObj.sprite == null) continue;

      if (!dataObj.sprite.packed) {
        return false;
      }
    }
    return true;
  }

  public override void DrawFeatureEditor(Rect rect, bool isActive, bool isFocused) {
    Rect line = rect.SingleLine();

    propertyName = EditorGUI.TextField(line, "Property Name", propertyName);
    line = line.NextLine();

    channel = (UVChannelFlags)EditorGUI.EnumPopup(line, "Uv Channel", channel);
  }

  public override float GetEditorHeight() {
    return EditorGUIUtility.singleLineHeight * 2;
  }
#endif
}