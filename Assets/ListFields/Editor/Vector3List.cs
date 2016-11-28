using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class Vector3List : ListField<Vector3> {
        protected override Func<int, Vector3, Vector3> drawer {
            get {
                return (index, value) => EditorGUILayout.Vector3Field(this.Labeler(index), value);
            }
        }


        public Vector3List()
            : base() {; }

        public Vector3List(string label)
            : base(label) {; }

        public Vector3List(string label, List<Vector3> initial)
            : base(label, initial) {; }
    }
}
