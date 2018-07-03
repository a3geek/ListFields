using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace ListFields {
    public abstract class ListField<T> : IListField {
        protected abstract Func<int, T, T> drawer { get; }

        public event Action<bool> OnFoldToggle = delegate { };
        #pragma warning disable 0067
        public event Action OnCountChanged = delegate { };

        public T this[int index] {
            get {
                if(index < 0 || index >= this.Count) { throw new ArgumentOutOfRangeException("Index"); }
                return this.list[index];
            }
            set {
                if(index < 0 || index >= this.Count) { throw new ArgumentOutOfRangeException("Index"); }
                this.list[index] = value;
            }
        }
        public Func<int, object, object> Drawer {
            get {
                return (index, value) => this.drawer(index, (T)value);
            }
        }

        public virtual Func<int, string> Labeler { get; set; }
        public float MinHeight { get; set; }
        public float MaxHeight { get; set; }
        public float MinWidth { get; set; }
        public float MaxWidth { get; set; }
        public bool ShowHorizontalScrollBar { get; set; }
        public bool ShowVerticalScrollBar { get; set; }
        public bool ShowCountField { get; set; }

        public int Count { get; protected set; }
        public bool Folding { get; protected set; }
        public string Label { get; protected set; }

        protected List<T> list = new List<T>();
        protected string controlName = "";
        protected int inputCount = 0;
        protected Vector2 scroll = Vector2.zero;


        public ListField() : this(typeof(T).FullName + " Field") {
            ;
        }

        public ListField(string label) {
            this.MinHeight = 100f;
            this.MaxHeight = 200f;
            this.MinWidth = 500f;
            this.MaxWidth = 1000f;

            this.ShowHorizontalScrollBar = false;
            this.ShowVerticalScrollBar = true;
            this.ShowCountField = true;

            this.Count = 0;
            this.Folding = false;

            this.Label = label;
            this.controlName = label + Guid.NewGuid().ToString();

            this.Labeler = index => index.ToString();
        }

        public ListField(string label, List<T> initial) : this(label) {
            if(initial != null && initial.Count > 0) {
                this.list.AddRange(initial);
                this.inputCount = this.Count = initial.Count;
            }
        }

        public virtual void Draw() {
            if(this.EventCheck(EventType.KeyDown, KeyCode.Return) && GUI.GetNameOfFocusedControl() == this.controlName) {
                this.Arrangement();
            }

            this.DrawGUI();
        }

        public virtual void SetCount(int count) {
            this.inputCount = count;
            this.Arrangement();
        }

        public virtual IEnumerable<T> GetList() {
            for(var i = 0; i < this.Count && i < this.list.Count; i++) {
                yield return this.list[i];
            }
        }
        
        public virtual void AddValue(T value) {
            this.list.Add(value);

            this.Count++;
            this.inputCount++;
        }

        public virtual IEnumerable<object> GetObjectList() {
            yield return this.GetList();
        }

        public virtual IEnumerable<T> GetAllList() {
            return new List<T>(this.list);
        }

        public virtual IEnumerable<T> GetValidityList() {
            for(var i = 0; i < this.Count && i < this.list.Count; i++) {
                if(this.list[i] != null) {
                    yield return this.list[i];
                }
            }
        }
        
        protected virtual void DrawGUI() {
            var folding = this.Folding;
            this.Folding = EditorGUILayout.Foldout(this.Folding, this.Label, true);

            if(folding != this.Folding) {
                this.OnFoldToggle(this.Folding);
            }

            if(this.Folding == false)
            {
                return;
            }

            EditorGUI.indentLevel += 1;

            if(this.ShowCountField)
            {
                EditorGUILayout.BeginHorizontal();
                GUI.SetNextControlName(this.controlName);

                EditorGUIUtility.labelWidth = 50f;
                this.inputCount = EditorGUILayout.IntField("Size", this.inputCount, GUILayout.ExpandWidth(false));

                if(GUILayout.Button("Apply", GUILayout.ExpandWidth(false)))
                {
                    this.Arrangement();
                }

                EditorGUILayout.EndHorizontal();
                EditorGUIUtility.labelWidth = 0f;

                EditorGUI.indentLevel += 1;
            }

            var verticalOptions = new List<GUILayoutOption>();
            if(this.MinHeight >= 0f) { verticalOptions.Add(GUILayout.MinHeight(this.MinHeight)); }
            if(this.MaxHeight >= 0f) { verticalOptions.Add(GUILayout.MaxHeight(this.MaxHeight)); }
            if(this.MinWidth >= 0f) { verticalOptions.Add(GUILayout.MinWidth(this.MinWidth)); }
            if(this.MaxWidth >= 0f) { verticalOptions.Add(GUILayout.MaxWidth(this.MaxWidth)); }

            EditorGUILayout.BeginVertical(verticalOptions.ToArray());
            this.scroll = GUILayout.BeginScrollView(this.scroll, this.ShowHorizontalScrollBar, this.ShowVerticalScrollBar);

            for(var i = 0; i < this.Count && i < this.list.Count; i++)
            {
                this.list[i] = (T)this.Drawer(i, this.list[i]);
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            EditorGUI.indentLevel -= this.ShowCountField ? 2 : 1;
        }

        protected virtual void Arrangement() {
            for(var i = this.inputCount - this.list.Count; i > 0; i--) {
                this.list.Add(default(T));
            }

            if(this.Count != this.inputCount) {
                this.Count = this.inputCount;
                this.OnCountChanged();
            }
        }

        protected virtual bool EventCheck(EventType type, KeyCode code) {
            return (Event.current.type == type ? Event.current.keyCode == code : false);
        }
    }
}
