using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    using LS = List<SerializedProperty>;

    public sealed class PropertyList : ListField<SerializedProperty> {
        public bool IncludeChildren = true;
        public List<SerializedProperty> Properties { get; private set; }

        protected override Func<int, SerializedProperty, SerializedProperty> drawer {
            get {
                return (index, value) => {
                    if(index < this.Properties.Count) {
                        EditorGUILayout.PropertyField(this.Properties[index], this.IncludeChildren);
                        return this.Properties[index];
                    }

                    return null;
                };
            }
        }


        public PropertyList() : base() {
            this.Properties = new List<SerializedProperty>();
        }

        public PropertyList(string label) : base(label) {
            this.Properties = new List<SerializedProperty>();
        }
        
        public PropertyList(string label, bool includeChildren, LS properties) : this(label) {
            this.Properties = properties;
            this.IncludeChildren = includeChildren;
        }
    }
}
