using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class MaskList : ListField<int> {
        public string[] DisplayedOption = new string[0];

        protected override Func<int, int, int> drawer {
            get {
                return (index, value) => EditorGUILayout.MaskField(this.Labeler(index), value, this.DisplayedOption);
            }
        }


        public MaskList()
            : base() {; }

        public MaskList(string label)
            : base(label) {; }

        public MaskList(string label, List<int> initial)
            : base(label, initial) {; }

        public MaskList(string label, string[] displayedOption) : this(label) {
            this.DisplayedOption = displayedOption;
        }

        public MaskList(string label, string[] displayedOption, List<int> initial) : this(label, initial) {
            this.DisplayedOption = displayedOption;
        }
    }
}
