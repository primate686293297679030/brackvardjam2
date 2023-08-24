using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GunScriptableObject", order = 1)]
public class GunScriptableObject : ScriptableObject
{
    public string name;
    public Sprite gunSprite;
    public int damage;
    public int capacity;
    public int fireRate;
    public GameObject ammoType;
}
