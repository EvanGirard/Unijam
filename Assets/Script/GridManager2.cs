using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager2 : MonoBehaviour
{
    public int length=10;
    public int heigth=10;
    public int bottom=-5;
    public int left=-5;
    [SerializeField] GameObject floor;
    [SerializeField] GameObject mur;
    [SerializeField] GameObject porte;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<length; i++){
            for(int j=0; j<heigth; j++){
                Instantiate(floor, new Vector3(0.5f+left+i,0.5f+bottom+j,0), new Quaternion());
            }
        }
        for(int i=0; i<length; i++){
            if ( (i != 3) || (i != 7)) {
            Quaternion orient=new Quaternion();
            Instantiate(mur, new Vector3(left-0.5f,i+0.5f+bottom,0),orient);
            orient.eulerAngles = new Vector3(0,0,-90);
            Instantiate(mur, new Vector3(left+0.5f+i,0.5f+bottom+heigth,0),orient);
            orient.eulerAngles = new Vector3(0,0,180);
            Instantiate(mur, new Vector3(left+length+0.5f,i+0.5f+bottom,0),orient);
            orient.eulerAngles = new Vector3(0,0,90);
            Instantiate(mur, new Vector3(left+0.5f+i,-0.5f+bottom,0),orient);
            }
            else {
            Debug.Log("spawn porte");
            Quaternion orient=new Quaternion();
            Instantiate(mur, new Vector3(left-0.5f,i+0.5f+bottom,0),orient);
            orient.eulerAngles = new Vector3(0,0,-90);
            Instantiate(porte, new Vector3(left+0.5f+i,0.5f+bottom+heigth,0),orient);
            orient.eulerAngles = new Vector3(0,0,180);
            Instantiate(mur, new Vector3(left+length+0.5f,i+0.5f+bottom,0),orient);
            orient.eulerAngles = new Vector3(0,0,90);
            Instantiate(mur, new Vector3(left+0.5f+i,-0.5f+bottom,0),orient);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
