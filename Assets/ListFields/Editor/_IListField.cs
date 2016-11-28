using System.Collections.Generic;
using System;

namespace A3Utility.Editor.ListFields {
    public interface IListField {
        event Action<bool> OnFoldToggle;
        event Action OnCountChanged;

        Func<int, object, object> Drawer { get; }
        Func<int, string> Labeler { get; set; }

        float MinHeight { get; set; }
        float MaxHeight { get; set; }
        float MinWidth { get; set; }
        float MaxWidth { get; set; }
        bool ShowHorizontalScrollBar { get; set; }
        bool ShowVerticalScrollBar { get; set; }
        bool ShowCountField { get; set; }

        int Count { get; }
        bool Folding { get; }
        string Label { get; }

        void Draw();
        void SetCount(int count);
        IEnumerable<object> GetObjectList();
    }
}
