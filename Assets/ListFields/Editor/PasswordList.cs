using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class PasswordList : ListField<string> {
        protected override Func<int, string, string> drawer {
            get {
                return (index, value) => EditorGUILayout.PasswordField(this.Labeler(index), value);
            }
        }


        public PasswordList()
            : base() {; }

        public PasswordList(string label)
            : base(label) {; }

        public PasswordList(string label, List<string> initial)
            : base(label, initial) {; }
    }
}
