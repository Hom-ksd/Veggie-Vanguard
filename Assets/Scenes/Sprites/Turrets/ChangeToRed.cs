using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToRed : MonoBehaviour
{
    private Color target = Color.red;

    private Color[] originalColors;

    private SpriteRenderer[] targetSprites;

    private bool status = false;

    private void Start()
    {
        SpriteRenderer[] childSprites = GetComponentsInChildren<SpriteRenderer>();

        targetSprites = System.Array.FindAll(childSprites, sprite => sprite.CompareTag("Plant"));

        originalColors = new Color[childSprites.Length];
        for (int i = 0; i< childSprites.Length; i++)
        {
            originalColors[i] = childSprites[i].color;
        }
    }

    public void ChangeColor()
    {
        foreach (var sprite in targetSprites)
        {
            sprite.color = target;
            status = true;
        }
    }

    public void ChangeOriginal()
    {
        for (int i = 0; i < targetSprites.Length; i++)
        {
            targetSprites[i].color = originalColors[i];
            status = false;
        }
    }

    public bool getStatus()
    {
        return status;
    }
}
