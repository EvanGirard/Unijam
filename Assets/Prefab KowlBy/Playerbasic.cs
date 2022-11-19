using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbasic : MonoBehaviour
{public int screenhaut=20;
public int screenright=20;
public int bottomcorner=-10;
public int leftcorner=-10;
[SerializeField] int speed=1;
[SerializeField] Camera Maincam ;

public SpriteRenderer spriteRenderer;
public Sprite leftsprite;

public Sprite rightsprite;

public Sprite upsprite;

public Sprite downsprite;

private int timer=0;
[SerializeField] int cc=300;
[SerializeField] float dash=3f;
[SerializeField] int dashduration=10;
private int ddash=11;

private Vector3 direcdash;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        ddash++;
        if (ddash>=dashduration){
            if (Input.GetKey(KeyCode.Z)){
                if (bottomcorner + screenhaut - transform.lossyScale.y/2 > transform.position.y ){
                    transform.position += new Vector3(0,speed*Time.deltaTime,0);
                }
            }
            if (Input.GetKey(KeyCode.D)){
                if (leftcorner + screenright - transform.lossyScale.x/2 > transform.position.x ){
                    transform.position += new Vector3(speed*Time.deltaTime,0,0);
                }
            }
            if (Input.GetKey(KeyCode.S)){
                if (bottomcorner + transform.lossyScale.y/2 < transform.position.y ){
                    transform.position += new Vector3(0,-speed*Time.deltaTime,0);
                }
            }
            if (Input.GetKey(KeyCode.Q)){
                if (leftcorner + transform.lossyScale.x/2 < transform.position.x ){
                    transform.position += new Vector3(-speed*Time.deltaTime,0,0);
                }
            }
            Vector3 mousepos=Maincam.ScreenToWorldPoint(Input.mousePosition);
            if (mousepos.x-transform.position.x < 0 && mousepos.x-transform.position.x < -Mathf.Abs(mousepos.y-transform.position.y)){
                spriteRenderer.sprite = leftsprite;
            }
            if (mousepos.y-transform.position.y < 0 && mousepos.y-transform.position.y < -Mathf.Abs(mousepos.x-transform.position.x)){
                spriteRenderer.sprite = downsprite;
            }
            if (mousepos.x-transform.position.x > 0 && mousepos.x-transform.position.x > Mathf.Abs(mousepos.y-transform.position.y)){
                spriteRenderer.sprite = rightsprite;
            }
            if (mousepos.y-transform.position.y > 0 && mousepos.y-transform.position.y > Mathf.Abs(mousepos.x-transform.position.x)){
                spriteRenderer.sprite = upsprite;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && timer > cc){
            timer=0;
            int a=0;
            int b=0;
            int c=0;
            int d=0;
            if (Input.GetKey(KeyCode.Z)){
                a=1;
            }
            if (Input.GetKey(KeyCode.S)){
                b=1;
            }
            if (Input.GetKey(KeyCode.Q)){
                d=1;
            }
            if (Input.GetKey(KeyCode.D)){
                c=1;
            }
            Vector3 resultat=new Vector3((c-d)*dash,(a-b)*dash,0)+transform.position;
            if (resultat.x > leftcorner + screenright - transform.lossyScale.x/2 ){
                resultat.x=leftcorner + screenright - transform.lossyScale.x/2;
            }
            else{
                if (resultat.x < leftcorner + transform.lossyScale.x/2){
                    resultat.x=leftcorner + transform.lossyScale.x/2;
                }
            }
            if (resultat.y > bottomcorner + screenhaut - transform.lossyScale.y/2){
                resultat.y=bottomcorner + screenhaut - transform.lossyScale.y/2;
            }
            else{
                if (resultat.y < bottomcorner + transform.lossyScale.y/2){
                    resultat.y=bottomcorner + transform.lossyScale.y/2;
                }
            }
            ddash=0;
            direcdash=(resultat-transform.position)/dashduration;
        }
        if (ddash<dashduration){
            transform.position+=direcdash;
        }
    }
}
