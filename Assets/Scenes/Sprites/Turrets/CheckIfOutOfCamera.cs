using UnityEngine;

public class CheckIfOutOfCamera : MonoBehaviour
{
    // Flag to track if the GameObject is visible
    private bool isVisible;

    // Called when the renderer is no longer visible by any camera
    void OnBecameInvisible()
    {
        isVisible = false;
        Debug.Log(gameObject.name + " is out of camera view.");
        // Perform actions when the GameObject is out of camera view
    }

    // Called when the renderer becomes visible by any camera
    void OnBecameVisible()
    {
        isVisible = true;
        Debug.Log(gameObject.name + " is in camera view.");
        // Perform actions when the GameObject is in camera view
    }

    // You can use this method to check the visibility status
    public bool IsVisible()
    {
        return isVisible;
    }
}
