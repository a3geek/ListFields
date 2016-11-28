using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public sealed class ObjectList<T> : ListField<T> where T : UnityEngine.Object {
        public bool AllowSceneObjects = true;

        protected override Func<int, T, T> drawer {
            get {
                return (index, value) => {
                    return (T)EditorGUILayout.ObjectField(this.Labeler(index), value, typeof(T), this.AllowSceneObjects);
                };
            }
        }


        public ObjectList()
            : base() {; }

        public ObjectList(string label)
            : base(label) {; }

        public ObjectList(string label, List<T> initial)
            : base(label, initial) {; }
    }
}
