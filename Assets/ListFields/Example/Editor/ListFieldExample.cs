using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace ListFields.Example {
    public class ListFieldExample : EditorWindow {
        private List<IListField> listFields = new List<IListField>();
        private Vector2 scroll = Vector2.zero;
        private SerializedObject serialized = null;


        [MenuItem("/List Fields/Example Window")]
        public static void ShowWindow() {
            var window = GetWindow<ListFieldExample>();

            window.Show();
            window.Init();
        }

        private void Init() {
            this.listFields = new List<IListField>();

            #region "List Inits"
            this.listFields.Add(new BoundsList("Bounds list"));
            this.listFields.Add(new ColorList("Color List"));
            this.listFields.Add(new CurveList("Curve List"));
            this.listFields.Add(new DelayedFloatList("Delayed Float List"));
            this.listFields.Add(new DelayedIntList("Delayed Int List"));
            this.listFields.Add(new DelayedTextList("Delayed Text List"));
            this.listFields.Add(new DoubleList("Double List"));
            this.listFields.Add(new FloatList("Float List"));
            this.listFields.Add(new IntList("Int List"));
            this.listFields.Add(new LayerList("Layer List"));
            this.listFields.Add(new MaskList("Mask List"));
            this.listFields.Add(new ObjectList<GameObject>("GameObject List"));
            this.listFields.Add(new PasswordList("Password List"));
            this.listFields.Add(new RectList("Rect List"));
            this.listFields.Add(new TagList("Tag List"));
            this.listFields.Add(new TextList("Text List"));
            this.listFields.Add(new Vector2List("Vector2 List"));
            this.listFields.Add(new Vector3List("Vector3 List"));
            this.listFields.Add(new Vector4List("Vector4 List"));

            var label = new LabelList("Label List", new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("Key1", "Value1"),
                new KeyValuePair<string, string>("Key2", "Value2")
            }) {
                ShowCountField = false
            };
            label.SetCount(2);
            this.listFields.Add(label);

            ExampleObj example = null;
            var select = Selection.activeGameObject;
            if(select != null && (example = select.GetComponent<ExampleObj>()) != null) {
                this.serialized = new SerializedObject(example);

                var property = new PropertyList("Property List", true, new List<SerializedProperty>() {
                    this.serialized.FindProperty("Vec3"),
                    this.serialized.FindProperty("Str"),
                    this.serialized.FindProperty("List")
                }) {
                    ShowCountField = false
                };
                property.SetCount(3);

                this.listFields.Add(property);
            }
            #endregion
        }

        void OnGUI() {
            if(this.serialized != null) {
                this.serialized.Update();
            }

            this.scroll = EditorGUILayout.BeginScrollView(this.scroll);
            this.listFields.ForEach(e => e.Draw());

            if(this.serialized != null) {
                this.serialized.ApplyModifiedProperties();
            }

            EditorGUILayout.EndScrollView();
        }
    }
}
