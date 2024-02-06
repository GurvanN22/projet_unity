using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handle_move();
    }
    
    private void handle_move()
    {
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            y = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = +1f;
        }
        Vector3 move = new Vector3(x, y, 0).normalized;
        transform.position += move * speed * Time.deltaTime;
    }
}
