using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class TagList : ListField<string> {
        protected override Func<int, string, string> drawer {
            get {
                return (index, value) => EditorGUILayout.TagField(this.Labeler(index), value);
            }
        }


        public TagList()
            : base() {; }

        public TagList(string label)
            : base(label) {; }

        public TagList(string label, List<string> initial)
            : base(label, initial) {; }
    }
}
