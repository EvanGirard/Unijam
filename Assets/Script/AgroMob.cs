using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroMob : MonoBehaviour
{
    
    
    public float speed = 10;
    public Vector2 target;
    public float range_attack = 1;
    public int frame_attack = 0;
    public Sprite[] sprites;
    public int damage = 2;
    private float step =0;
    public bool b_move = true;
    public int PV = 4;
    SpriteRenderer _spriteRenderer;
    string tagName = "Player";
    public GameObject player;
    public float distance;
    public float temp_dist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(tagName);


    }

    // Update is called once per frame

    void Update()
    {   
        if (b_move) {
            Move(false);
        }
      
        temp_dist = distance;
        frame_attack = (frame_attack +1 ) %4;
        distance = Vector2.Distance(target,transform.position);
        if (distance == temp_dist){
            b_move = true;
        }


        Affichage(frame_attack);
        
     
    }
    public void takedamage(int damage){
        PV -= damage;
        if (PV<=0) {
            Destroy(gameObject);
        }
    }

    public void Move(bool reverse){


        target = player.transform.position;
        if (reverse) {
            target *= -1;
        }
        step = speed * Time.deltaTime;        
        
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    public void Affichage(int frame_attack) {
        /*if(frame_attack < 0 || frame_attack >= sprites.Length)
        {
            Debug.LogError("Attempted to display a sprite outside the valid range: " + frame_attack);
            return;
        } */
         switch (frame_attack)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
                break;
            default :
                break;
        }
    }

    
}
