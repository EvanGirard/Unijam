using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaillouMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 target;
    public GameObject cible;
    public Sprite[] sprites;
    public float speed = 4;
    public float range_explosion = 0.5f;
    public float distance;
    public int damage = 3;
    public bool otw = true;
    public float timer_change;
    public float delay_explosion = 1f;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        cible = Instantiate(cible, target, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (otw){
        if (transform.position != target){
            transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        }
        else {
            Explosion();
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            otw =false;
            timer_change = Time.time + delay_explosion;
        }
        }
        else {

            if (Time.time > timer_change){                
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                
            }
            if (Time.time > timer_change + delay_explosion){
                Destroy(gameObject);
                Destroy(cible);
            }


        }
    

        
    }

    void Explosion(){
        distance = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distance < range_explosion){
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Playerbasic>().TakeDamage(damage);
        }
    }

    
}
