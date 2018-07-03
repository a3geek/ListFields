using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class Vector2List : ListField<Vector2> {
        protected override Func<int, Vector2, Vector2> drawer {
            get {
                return (index, value) => EditorGUILayout.Vector2Field(this.Labeler(index), value);
            }
        }


        public Vector2List()
            : base() {; }

        public Vector2List(string label)
            : base(label) {; }

        public Vector2List(string label, List<Vector2> initial)
            : base(label, initial) {; }
    }
}
