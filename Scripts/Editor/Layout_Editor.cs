using UnityEditor;
using UnityEngine;

namespace Poke.UI
{
    [
        CustomEditor(typeof(Layout)),
        CanEditMultipleObjects
    ]
    public class Layout_Editor : Editor
    {
        private Layout _layout;
        
        private void Awake() {
            _layout = target as Layout;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            
            EditorGUILayout.Space();
            EditorGUILayout.HelpBox($"Tracking {_layout.ChildCount} layout elements.", MessageType.Info);
            if(GUILayout.Button("Refresh Child Cache")) {
                _layout.RefreshChildCache();
                EditorApplication.QueuePlayerLoopUpdate();
            }
        }
    }
}