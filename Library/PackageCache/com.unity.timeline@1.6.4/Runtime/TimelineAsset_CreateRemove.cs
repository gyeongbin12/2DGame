using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngineInternal; // for metro type extensions

namespace UnityEngine.Timeline
{
    public partial class TimelineAsset
    {
        /// <summary>
        /// Allows you to create a track and add it to the Timeline.
        /// </summary>
        /// <param name="type">The type of track to create. Must derive from TrackAsset.</param>
        /// <param name="parent">Track to 