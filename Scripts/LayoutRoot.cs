using UnityEngine;

namespace Poke.UI
{
    [
        ExecuteAlways,
        RequireComponent(typeof(RectTransform))
    ]
    public class LayoutRoot : MonoBehaviour
    {
        private readonly SortedBucket<Layout, int, Layout> _layouts = new (l => l, l => l.GetInstanceID());

        public void LateUpdate() {
            // sizing pass (0)
            foreach(Layout l in _layouts) {
                l.ComputeSize();
            }

            // layout pass (1)
            foreach(Layout l in _layouts) {
                l.ComputeLayout();
            }
        }

        public void RegisterLayout(Layout layout) {
            Debug.Log($"Registered \"{layout.name}\" at depth [{layout.Depth}]");
            _layouts.Add(layout);
        }

        public void UnregisterLayout(Layout layout) {
            if(_layouts.Remove(layout)) {
                Debug.Log($"Removed \"{layout.name}\"");
            }
            else {
                Debug.LogError($"Failed to remove \"{layout.name}\" (not found)");
            }
        }
    }
}