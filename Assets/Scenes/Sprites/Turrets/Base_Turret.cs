using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turrets")]
public class Turret : ScriptableObject
{
    public Sprite topSprite;
    public Sprite bottomSprite;

    public float cost;
}