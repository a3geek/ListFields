using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class FloatList : ListField<float> {
        protected override Func<int, float, float> drawer {
            get {
                return (index, value) => EditorGUILayout.FloatField(this.Labeler(index), value);
            }
        }


        public FloatList()
            : base() {; }

        public FloatList(string label)
            : base(label) {; }

        public FloatList(string label, List<float> initial)
            : base(label, initial) {; }
    }
}
