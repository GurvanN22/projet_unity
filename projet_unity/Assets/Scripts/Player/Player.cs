using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{

    public float speed = 2.0f;

    private int health = 3;
    private int kills = 0; 

    private GameObject killCounter;
    private GunHandler GunHandler;
    private bool IsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        killCounter = GameObject.FindGameObjectsWithTag("kills")[0];
        GunHandler = GameObject.FindGameObjectsWithTag("Gun")[0].GetComponent<GunHandler>();
        GetComponent<Animator>().SetBool("IsDead", false);
        GetComponent<Animator>().SetBool("IsWalking", false);
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
            //sprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = +1f;
            //sprite.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (!IsAlive)
        {
            x = 0;
            y = 0;
        }
        Vector3 move = new Vector3(x, y, 0).normalized;
        transform.position += move * speed * Time.deltaTime;
        if (x == 0 && y == 0)
        {
            // We start idle animation
            GetComponent<Animator>().SetBool("IsWalking", false);
        } else 
        {
            // We start running animation
            GetComponent<Animator>().SetBool("IsWalking", true);
        } 
        
    }

    public void take_damage(int damage)
    {
        health -= damage;
        if (health <= 0 && IsAlive)
        {
            IsAlive = false;
            GunHandler.SetDeath();
            GetComponent<Animator>().SetBool("IsDead", true);
        }
    }   


    public void Add_kill()
    {
        kills++;
        killCounter.GetComponent<TextMeshProUGUI>().text = "Score : " + kills.ToString();
    }
}
