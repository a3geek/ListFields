using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class DelayedFloatList : ListField<float> {
        protected override Func<int, float, float> drawer {
            get {
                return (index, value) => EditorGUILayout.DelayedFloatField(this.Labeler(index), value);
            }
        }


        public DelayedFloatList()
            : base() {; }

        public DelayedFloatList(string label)
            : base(label) {; }

        public DelayedFloatList(string label, List<float> initial)
            : base(label, initial) {; }
    }
}
