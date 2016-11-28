using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class Vector4List : ListField<Vector4> {
        protected override Func<int, Vector4, Vector4> drawer {
            get {
                return (index, value) => EditorGUILayout.Vector4Field(this.Labeler(index), value);
            }
        }


        public Vector4List()
            : base() {; }

        public Vector4List(string label)
            : base(label) {; }

        public Vector4List(string label, List<Vector4> initial)
            : base(label, initial) {; }
    }
}
