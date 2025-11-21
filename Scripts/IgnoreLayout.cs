using UnityEngine;

namespace Poke.UI
{
    [ExecuteAlways]
    public class IgnoreLayout : MonoBehaviour
    {
        private Layout _parent;

        private void OnEnable() {
            _parent = transform.parent.GetComponent<Layout>();
            _parent.RefreshChildCache();
        }

        private void OnDisable() {
            _parent.RefreshChildCache();
        }
    }
}
