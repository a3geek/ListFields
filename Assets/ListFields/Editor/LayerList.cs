using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class LayerList : ListField<int> {
        protected override Func<int, int, int> drawer {
            get {
                return (index, value) => EditorGUILayout.LayerField(this.Labeler(index), value);
            }
        }


        public LayerList()
            : base() {; }

        public LayerList(string label)
            : base(label) {; }

        public LayerList(string label, List<int> initial)
            : base(label, initial) {; }
    }
}
