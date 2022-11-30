using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;

    float _moveHorizontal;
    float _moveSpeed = 10f;
    Vector2 _currentVelocity;

    bool _canInteract;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");

        _currentVelocity = new Vector2(_moveHorizontal, 0f) * _moveSpeed;

        
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer(){
        if (_moveHorizontal != 0){
            _rb.velocity = _currentVelocity;

        }
        else {
            _currentVelocity = new Vector2(0f,0f);
            _rb.velocity = _currentVelocity;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collide){
        Debug.Log(collide.gameObject.name);
        //collide.gameObject.GetComponent<BallBehaviour>().Print();
    }
    
}
