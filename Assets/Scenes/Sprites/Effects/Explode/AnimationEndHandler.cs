using UnityEngine;

public class AnimationEndHandler : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        // Check if we are in edit mode
#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
        {
            Destroy(gameObject);
        }
        else
        {
            // Use DestroyImmediate in edit mode
            UnityEditor.EditorApplication.delayCall += () =>
            {
                if (this != null) // Ensure the object still exists
                {
                    UnityEngine.Object.DestroyImmediate(gameObject);
                }
            };
        }
#else
        // Use Destroy at runtime
        Destroy(gameObject);
#endif
    }
}
