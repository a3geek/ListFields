using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class DelayedIntList : ListField<int> {
        protected override Func<int, int, int> drawer {
            get {
                return (index, value) => EditorGUILayout.DelayedIntField(this.Labeler(index), value);
            }
        }


        public DelayedIntList()
            : base() {; }

        public DelayedIntList(string label)
            : base(label) {; }

        public DelayedIntList(string label, List<int> initial)
            : base(label, initial) {; }
    }
}
