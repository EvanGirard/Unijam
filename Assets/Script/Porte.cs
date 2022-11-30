using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porte : MonoBehaviour
{  
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] porte = new Sprite[2];
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float xf = GetComponent<Transform>().position.x;
        float zf = GetComponent<Transform>().position.z;
        float xp = Playerbasic.PlayerPosition.Item1;
        float zp = Playerbasic.PlayerPosition.Item2;
        if ((SpawnOrcs.NbOrcs == 0))
        { 
            spriteRenderer.sprite = porte[1];
            if ((xf - xp) * (xf - xp) + (zf - zp) * (zf - zp) < 9)
            {
                SceneManager.LoadScene("Main_Scene");
                gamemanager.Instance.niveau += 1;
            }
        }
    }
}
