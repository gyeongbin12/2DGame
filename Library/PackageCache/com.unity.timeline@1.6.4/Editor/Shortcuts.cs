using System;
using JetBrains.Annotations;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace UnityEditor.Timeline
{
    static class Shortcuts
    {
        public static class Clip
        {
            public const string split = "Timeline/Editing/Split";
            public const string trimStart = "Timeline/Editing/TrimStart";
            public const string trimEnd = "Timeline/Editing/TrimEnd";

            [UsedImplicitly, ShortcutManagement.Shortcut(split, typeof(TimelineWindow), Key