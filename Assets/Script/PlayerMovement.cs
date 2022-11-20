using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement  : MonoBehaviour
{
    public float speed = 20;
    private Vector2 motion;
    public Component camera;
    public int PV = 12;
    public float next_damage = 0f;
    public float cooldown = 2f;
    static public (float, float) PlayerPosition = (0, 0);
    [SerializeField] Canvas GameOverScreen;
    // Update is called once per frame
    void Update()
    {
        motion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(motion * speed * Time.deltaTime);
        camera.transform.Translate(motion* speed * Time.deltaTime);
        PlayerPosition = (GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
    }

    void TakeDamage(int damage){
        PV -= damage;
        Debug.Log("took " + damage + "damage");
        Debug.Log("Current HP : " + PV);
        if (PV == 0) {
            Time.timeScale = 0f;
            GameOverScreen.enabled=true;
        }
    }

    void OnTriggerStay2D(Collider2D collide){
        //Debug.Log(collide.gameObject.name);
        //collide.gameObject.GetComponent<AgroMob>().b_move = false;
        //collide.gameObject.GetComponent<AgroMob>().Move(true);
        if ( Time.time > next_damage  && collide.gameObject.tag == "Orc"){
            next_damage = Time.time + cooldown;
            int damage = collide.gameObject.GetComponent<AgroMob>().damage;
            //collide.gameObject.GetComponent<AgroMob>().Move(true);
            TakeDamage(damage);
            

        //collide.gameObject.GetComponent<BallBehaviour>().Print();
    }
    
    }
/*    void OnTriggerExit2D(Collider2D collide){

        collide.gameObject.GetComponent<AgroMob>().b_move = true;
            

    }
    /*void OnTriggerEnter2D(Collider2D collide){
        Debug.Log("Trigger");
       
        }
        
    } */
    
}
