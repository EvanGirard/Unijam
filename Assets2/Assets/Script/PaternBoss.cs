using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaternBoss : MonoBehaviour
{
    public GameObject player;
    public GameObject laser;
    public GameObject caillou;
    public float cd_laser = 10;
    public float new_laser = 2;
    public float cd_caillou = 3;
    public float new_caillou = 4;
    public float speed = 3;
    private Vector3 target;
    public int PV = 30;
    // Start is called before the first frame update

    public int destinationx =1;
    int lastNumberx =0 ;
    int maxAttempts = 15;
    
    public void kill(){
        Destroy(gameObject);
    }

    void NewRandomNumberx()
    {
         for(int i=0; destinationx == lastNumberx && i < maxAttempts; i++) {
            destinationx = Random.Range(-5, 5);
        }

        lastNumberx = destinationx;
    }

    public int destinationy =1;
    int lastNumbery = 0;
    void NewRandomNumbery()
    {
        for(int i=0; destinationy == lastNumbery && i < maxAttempts; i++) {
            destinationy = Random.Range(-5, 5);
        }

        lastNumbery = destinationy;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > new_laser  ) {
            Debug.Log("create laser");
            new_laser += cd_laser;

            Vector3 position = transform.position;
            position += new Vector3(0,-2,0);
           
            Instantiate(laser, position, transform.rotation );
           
        }

        if (Time.time > new_caillou ) {
            Debug.Log("create caillou");
            new_caillou += cd_caillou;

            Vector3 position = transform.position;
            position += new Vector3(0,-2,0);
           
            Instantiate(caillou, position, transform.rotation );
        }

        else {
            randomMove();
        }
    }
    
    void randomMove(){
        if (target == transform.position) {

      
        NewRandomNumberx();
        NewRandomNumbery();
         }
        target = new Vector3(destinationx,destinationy,0);
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime );
    }


    }
