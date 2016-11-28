using UnityEditor;
using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    using Pair = List<KeyValuePair<string, string>>;

    public sealed class LabelList : ListField<string> {
        public Pair LabelPairs { get; private set; }

        protected override Func<int, string, string> drawer {
            get {
                return (index, value) => {
                    if(index < this.LabelPairs.Count) {
                        var labels = this.LabelPairs[index];
                        EditorGUILayout.LabelField(labels.Key, labels.Value);

                        return labels.Key;
                    }

                    return "";
                };
            }
        }


        public LabelList() : base() {
            this.LabelPairs = new Pair();
        }

        public LabelList(string label) : base(label) {
            this.LabelPairs = new Pair();
        }

        public LabelList(string label, Pair labelPairs) : this(label) {
            this.LabelPairs = labelPairs;
            this.Count = labelPairs.Count;
        }
    }
}
