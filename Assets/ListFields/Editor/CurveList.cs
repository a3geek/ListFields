using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class CurveList : ListField<AnimationCurve> {
        protected override Func<int, AnimationCurve, AnimationCurve> drawer {
            get {
                return (index, value) => {
                    if(value == null) { value = new AnimationCurve(); }
                    return EditorGUILayout.CurveField(this.Labeler(index), value);
                };
            }
        }


        public CurveList()
            : base() {; }

        public CurveList(string label)
            : base(label) {; }

        public CurveList(string label, List<AnimationCurve> initial)
            : base(label, initial) {; }
    }
}
