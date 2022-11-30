using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] Transform charac;
    [SerializeField] Camera Maincam ;
    public SpriteRenderer spriteRenderer;
    public Sprite swordsprite;
    Vector3 currentEulerAngles;
    private int timer=0;
    [SerializeField] int cc=300;
    [SerializeField] Projectile projectile;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite=swordsprite;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        Vector3 mousepos=Maincam.ScreenToWorldPoint(Input.mousePosition);
        float a = mousepos.x-charac.position.x;
        float b = mousepos.y-charac.position.y;
        transform.position = charac.position + new Vector3(a/(Mathf.Sqrt(a*a+b*b))*transform.lossyScale.x,b/(Mathf.Sqrt(a*a+b*b))*transform.lossyScale.y,0);
        if (b> 0){
            transform.eulerAngles=new Vector3(0,0,Mathf.Acos(a/(Mathf.Sqrt(a*a+b*b)))/Mathf.PI*180-135);
        }
        else{ 
            transform.eulerAngles=new Vector3(0,0,-Mathf.Acos(a/(Mathf.Sqrt(a*a+b*b)))/Mathf.PI*180-135);
        }

        if (Input.GetMouseButton(0)){
            if (timer > cc){
                Debug.Log(timer);
                timer=0;
                Quaternion tire=transform.rotation;
                tire.eulerAngles+=new Vector3(0,0,135);
                Instantiate(projectile, transform.position, tire);

            }
        }
    }
}
