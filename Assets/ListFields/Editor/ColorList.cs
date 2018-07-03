using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class ColorList : ListField<Color> {
        protected override Func<int, Color, Color> drawer {
            get {
                return (index, value) => EditorGUILayout.ColorField(this.Labeler(index), value);
            }
        }


        public ColorList()
            : base() {; }

        public ColorList(string label)
            : base(label) {; }

        public ColorList(string label, List<Color> initial)
            : base(label, initial) {; }
    }
}
