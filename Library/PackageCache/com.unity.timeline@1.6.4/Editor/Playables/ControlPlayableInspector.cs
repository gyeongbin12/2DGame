using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityEditor.Timeline
{
    [CustomEditor(typeof(ControlPlayableAsset)), CanEditMultipleObjects]
    class ControlPlayableInspector : Editor
    {
        static class Styles
        {
            static string s_DisabledBecauseOfSelfControlTooltip = "Must be disabled when the Source Game Object references the same PlayableDirector component that is being controlled";
  