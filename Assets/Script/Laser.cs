using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Sprite[] sprites;
    public int frame_attack =0;
    public float delay_phase = 1f;
    public float next_phase = 0.2f;
    public bool chargement = true;
    public int damage = 3;
    public float lifespan = 8;
    [SerializeField] Playerbasic charac;
    // Start is called before the first frame updates
    void Start()
    {
        Destroy(gameObject,lifespan);
        float a = 2*transform.lossyScale.y+transform.position.y-charac.transform.position.y;
        float b = transform.position.x-charac.transform.position.x;
        if (b> 0){
            transform.eulerAngles=new Vector3(0,0,Mathf.Acos(a/(Mathf.Sqrt(a*a+b*b)))/Mathf.PI*180);
        }
        else{ 
            transform.eulerAngles=new Vector3(0,0,-Mathf.Acos(a/(Mathf.Sqrt(a*a+b*b)))/Mathf.PI*180);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_phase) {
            

            if (chargement){
                frame_attack += 1;
                if (frame_attack >5){
                    chargement = false;
                }
                Affichage (frame_attack);
            }

            else {
                delay_phase = 0.1f;
                frame_attack = (frame_attack +1) %3;

                Affichage(frame_attack +6);

            }
            next_phase += delay_phase;
        }

        

       

    }
    

    public void Affichage(int frame_attack) {

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
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
              break;
            case 6:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
                break;
            case 7:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
                break;
            case 8:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[8];
                break;
            default :
                break;
        }
    }

   /* public void OnTriggerEnter2D(Collider2D collide){
        if (collide.gameObject.tag == "Player"){
            //collide.gameObject.GetComponent<Playerbasic>().TakeDamage(damage);
            Debug.Log("touch player");
        }

    }$
    */
}
