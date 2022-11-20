using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coeur1 : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriterenderer;
    [SerializeField] Sprite[] coeur= new Sprite[5];

    [SerializeField] Playerbasic charac;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charac.PV>4){
            spriterenderer.sprite = coeur[4];
        }
        else{if (charac.PV<0){
            spriterenderer.sprite = coeur[0];
        }
        else{
            spriterenderer.sprite = coeur[charac.PV];
        }
        }
        transform.position=cam.ScreenToWorldPoint(new Vector3(50,Screen.height-50,0));
        transform.position-=new Vector3(0,0,transform.position.z-1);
    }
}
