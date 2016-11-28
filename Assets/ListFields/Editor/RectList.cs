using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class RectList : ListField<Rect> {
        protected override Func<int, Rect, Rect> drawer {
            get {
                return (index, value) => EditorGUILayout.RectField(this.Labeler(index), value);
            }
        }


        public RectList()
            : base() {; }

        public RectList(string label)
            : base(label) {; }

        public RectList(string label, List<Rect> initial)
            : base(label, initial) {; }
    }
}
