using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrcs : MonoBehaviour
{
    public GameObject orc;
    static public int NbOrcs = 0;

    // Start is called before the first frame update
    void Start()
    {
        int x;
        int y;
        for (int i = 0; i < 4; i++){
            Debug.Log("spawn " + i);
            x = Random.Range(1,7);
            y = Random.Range(4,7);
            NbOrcs += 1;
            
            Instantiate(orc, new Vector3(x,y,0), Quaternion.identity  );

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
