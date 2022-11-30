using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class murs : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites_murs = new Sprite[5];
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = sprites_murs[gamemanager.Instance.niveau -1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
