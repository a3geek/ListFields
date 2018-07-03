using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class IntList : ListField<int> {
        protected override Func<int, int, int> drawer {
            get {
                return (index, value) => EditorGUILayout.IntField(this.Labeler(index), value);
            }
        }


        public IntList()
            : base() {; }

        public IntList(string label)
            : base(label) {; }

        public IntList(string label, List<int> initial)
            : base(label, initial) {; }
    }
}
