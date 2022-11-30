using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbasic : MonoBehaviour
{
    
    [SerializeField] private Sprite[] armure = new Sprite[5];
    public int screenhaut=20;
public int screenright=20;
public int bottomcorner=-10;
public int leftcorner=-10;
[SerializeField] int speed=1;
[SerializeField] GameObject GameOverScreen;
[SerializeField] Camera Maincam ;

public SpriteRenderer spriteRenderer;
/*public Sprite leftsprite;

public Sprite rightsprite;

public Sprite upsprite;

public Sprite downsprite;*/

private int timer=0;
[SerializeField] int cc=300;
[SerializeField] float dash=3f;
[SerializeField] int dashduration=10;
private int ddash=11;
static public (float,float) PlayerPosition = (0,0); 
public int PV = 12;
public float next_damage = 0f;
public float cooldown = 2f;
public GameObject gamemanager;
private Vector3 direcdash;


    // Start is called before the first frame update
    void Start()
    {
        //gamemanager = GameObject.FindGameObjectWithTag("GameController");
        
       // spriteRenderer.sprite = armure[gamemanager.GetComponent<gamemanager>().niveau -1];

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
            /*if (mousepos.x-transform.position.x < 0 && mousepos.x-transform.position.x < -Mathf.Abs(mousepos.y-transform.position.y)){
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
            }*/
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

        PlayerPosition = (GetComponent<Transform>().position.x, GetComponent<Transform>().position.z);
    }

    public void TakeDamage(int damage){
        PV -= damage;
        Debug.Log("took " + damage + "damage");
        Debug.Log("Current HP : " + PV);
        if (PV <= 0) {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    void OnTriggerStay2D(Collider2D collide){
        
        if (collide.gameObject.tag == "Orc") {
        //Debug.Log(collide.gameObject.name);
        collide.gameObject.GetComponent<AgroMob>().b_move = false;
        collide.gameObject.GetComponent<AgroMob>().Move(true);
        if ( Time.time > next_damage ){
            next_damage = Time.time + cooldown;
            int damage = collide.gameObject.GetComponent<AgroMob>().damage;
            //collide.gameObject.GetComponent<AgroMob>().Move(true);
            TakeDamage(damage);
        }
        } 

        if (collide.gameObject.tag == "Laser" && collide.gameObject.GetComponent<Laser>().chargement == false ) { //
         Debug.Log(collide.gameObject.name);

            if ( Time.time > next_damage ){
            next_damage = Time.time + cooldown;
            int damage = collide.gameObject.GetComponent<Laser>().damage;
            //collide.gameObject.GetComponent<AgroMob>().Move(true);
            TakeDamage(damage);
            Debug.Log("contact laser");
         }
        }
    }





        //collide.gameObject.GetComponent<BallBehaviour>().Print();
    
    
    

    void OnTriggerEnter2D(Collider2D collide){
        
        if ( collide.gameObject.tag == "Orc") {
        collide.gameObject.GetComponent<AgroMob>().b_move = true;
        }

    }

}
