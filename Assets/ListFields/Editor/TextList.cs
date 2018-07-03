using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class TextList : ListField<string> {
        protected override Func<int, string, string> drawer {
            get {
                return (index, value) => EditorGUILayout.TextField(this.Labeler(index), value);
            }
        }


        public TextList()
            : base() {; }

        public TextList(string label)
            : base(label) {; }

        public TextList(string label, List<string> initial)
            : base(label, initial) {; }
    }
}
