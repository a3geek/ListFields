using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class DoubleList : ListField<double> {
        protected override Func<int, double, double> drawer {
            get {
                return (index, value) => EditorGUILayout.DoubleField(this.Labeler(index), value);
            }
        }


        public DoubleList()
            : base() {; }

        public DoubleList(string label)
            : base(label) {; }

        public DoubleList(string label, List<double> initial)
            : base(label, initial) {; }
    }
}
