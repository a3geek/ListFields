using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public sealed class BoundsList : ListField<Bounds> {
        protected override Func<int, Bounds, Bounds> drawer {
            get {
                return (index, value) => EditorGUILayout.BoundsField(this.Labeler(index), value);
            }
        }


        public BoundsList()
            : base() {; }

        public BoundsList(string label)
            : base(label) {; }

        public BoundsList(string label, List<Bounds> initial)
            : base(label, initial) {; }
    }
}
