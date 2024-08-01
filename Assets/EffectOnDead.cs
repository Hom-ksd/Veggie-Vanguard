using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectOnDead : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;

    [SerializeField]
    private Transform parent;

    // Name of the scene you want to check
    [SerializeField]
    private string sceneNameToCheck;

    private void OnDestroy()
    {
        // Check if the current scene is the one we're interested in
        if (SceneManager.GetActiveScene().name == sceneNameToCheck)
        {
            Instantiate(effect, transform.position, Quaternion.identity, parent);
        }
    }
}
