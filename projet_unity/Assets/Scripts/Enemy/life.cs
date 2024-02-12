using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    // Start is called before the first frame update

    public int life_points = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void take_damage(int damage)
    {
        life_points -= damage;
        if (life_points <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet")) 
        {
            take_damage(1);
        }
    }
}
