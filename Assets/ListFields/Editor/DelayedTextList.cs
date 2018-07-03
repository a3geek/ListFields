using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class DelayedTextList : ListField<string> {
        protected override Func<int, string, string> drawer {
            get {
                return (index, value) => EditorGUILayout.DelayedTextField(this.Labeler(index), value);
            }
        }


        public DelayedTextList()
            : base() {; }

        public DelayedTextList(string label)
            : base(label) {; }

        public DelayedTextList(string label, List<string> initial)
            : base(label, initial) {; }
    }
}
