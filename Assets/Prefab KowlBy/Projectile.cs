using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] bool piercing=false;
    [SerializeField] float lifespan=0.5f;

    [SerializeField] int speed=50;

    public int damage=10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right*speed*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D opponent)
    {
        opponent.gameObject.GetComponent<Monstre>().takedamage(damage);
            if (!piercing){
                Destroy(gameObject);
            }
    }
}

