using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

namespace UnityEditor.Timeline
{
    class ClipInspectorCurveEditor
    {
        CurveEditor m_CurveEditor;
        CurveWrapper[] m_CurveWrappers;

        const float k_HeaderHeight = 30;
        const float k_PresetHeight = 30;

        Action<AnimationCurve, EditorCurveBinding> m_CurveUpdatedCallback;
        GUIContent m_TextContent = new GUIContent();

        GUIStyle m_LabelStyle;
     