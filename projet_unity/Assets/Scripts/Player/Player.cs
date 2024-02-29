using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 2.0f;
    public int bulletNbrMax = 15;
    public int bulletNbr = 15;

    public GameObject bulletDisplayPrefab;


    private GameObject sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GameObject.FindGameObjectsWithTag("PlayerSprite")[0];   
        bulletDisplay = GameObject.FindGameObjectsWithTag("ammo")[0];
    }

    // Update is called once per frame
    void Update()
    {
        handle_move();
        handle_reload();
    }

    private void handle_reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletNbr = bulletNbrMax;
        }
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
            //sprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = +1f;
            //sprite.GetComponent<SpriteRenderer>().flipX = false;
        }

        Vector3 move = new Vector3(x, y, 0).normalized;
        transform.position += move * speed * Time.deltaTime;

        if (x == 0 && y == 0)
        {
            // We start idle animation
            sprite.GetComponent<Animator>().SetBool("IsRunning", false);
        } else 
        {
            // We start running animation
            sprite.GetComponent<Animator>().SetBool("IsRunning", true);
        } 
        
    }

    private void updateShootingDisplay()
    {
        bulletDisplay.GetComponent<TextMeshProUGUI>().text = bulletNbr.ToString() + " / " + bulletNbrMax.ToString();
    }
}
