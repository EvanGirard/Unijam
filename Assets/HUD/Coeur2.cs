using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coeur2 : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriterenderer;
    [SerializeField] Sprite[] coeur= new Sprite[5];
    [SerializeField] Camera cam;
    [SerializeField] Playerbasic Chirac;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=cam.ScreenToWorldPoint(new Vector3(100,Screen.height-50,0));
        transform.position-=new Vector3(0,0,transform.position.z-1);
        if (Chirac.PV>8){
            spriterenderer.sprite=coeur[4];
        }
        else{if(Chirac.PV<4){
            spriterenderer.sprite=coeur[0];
        }
        else{
            spriterenderer.sprite=coeur[Chirac.PV-4];
        }
        }
    }
}
