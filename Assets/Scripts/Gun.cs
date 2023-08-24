using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunScriptableObject gunScriptableObject;

    private void Update()
    {
        var gunSpriteRenderer = GetComponent<SpriteRenderer>();
        gunSpriteRenderer.sprite = gunScriptableObject.gunSprite;
        gunSpriteRenderer.size = gameObject.transform.localScale;
    }
}
