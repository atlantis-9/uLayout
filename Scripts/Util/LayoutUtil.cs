using UnityEngine;

namespace Poke.UI
{
    public static class LayoutUtil
    {
        public static void DrawCenteredDebugBox(Vector3 pos, float w, float h, Color color, float duration) {
            DrawDebugBox(pos - new Vector3(w/2, h/2, 0), w, h, color, duration);
        }

        /// <summary>
        /// Draws a box out of debug rays, positioned at the bottom left corner.
        /// </summary>
        public static void DrawDebugBox(Vector3 pos, float w, float h, Color color, float duration) {
            // left
            Debug.DrawRay(pos, Vector3.up * h, color, duration);
            // bottom
            Debug.DrawRay(pos, Vector3.right * w, color, duration);
            // right
            Debug.DrawRay(pos + new Vector3(w, h), Vector2.down * h, color, duration);
            // top
            Debug.DrawRay(pos + new Vector3(w, h), Vector2.left * w, color, duration);
        }

        public static void DrawDebugBox(Vector2 pos, Vector2 size, Color color, float duration) {
            DrawDebugBox(pos, size.x, size.y, color, duration);
        }

        public static void DrawDebugBox(Rect rect, float z, Color color, float duration) {
            DrawDebugBox((Vector3)rect.position + new Vector3(0, 0, z), rect.width, rect.height, color, duration);
        }
        
        public static Vector2 With(this Vector2 vec, float? x = null, float? y = null) {
            return new Vector2(x ?? vec.x, y ?? vec.y);
        }
    }
    
    [System.Serializable]
    public struct Margins
    {
        public float top, bottom, left, right;
    }
    
    public enum SizingMode
    {
        None,
        Inherit,
        FitContent
    }
}
