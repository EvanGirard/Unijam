using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float xf = GetComponent<Transform>().position.x;
        float zf = GetComponent<Transform>().position.z;
        float xp = PlayerMovement.PlayerPosition.Item1;
        float zp = PlayerMovement.PlayerPosition.Item2;
        if ((SpawnOrcs.NbOrcs == 0))
        {  
            gameObject.SetActive(false);
            if ((xf - xp) * (xf - xp) + (zf - zp) * (zf - zp) < 9)
            {
                SceneManager.LoadScene("Main_Scene");
                gamemanager.Instance.niveau += 1;
            }
        }
    }
}
