using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanBePlaced : MonoBehaviour
{
    [SerializeField]
    private bool canBePlaced = true;

    [SerializeField]
    private List<GameObject> gameObjects = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant") || collision.gameObject.CompareTag("Hut"))
        {
            gameObjects.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant") || collision.gameObject.CompareTag("Hut"))
        {
            gameObjects.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        gameObjects.RemoveAll(item => item == null);

        canBePlaced = 0 == gameObjects.Count;
    }

    public bool getCanBePlaced()
    {
        return canBePlaced;
    }
}
