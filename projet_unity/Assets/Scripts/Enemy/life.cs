using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace 
{
    public class life : MonoBehaviour
    {

        public int life_points = 2;
        void Start()
        {

        }
        void Update()
        {
            Rushplayer();
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
            if (other.CompareTag("Bullet"))
            {
                take_damage(1);
            }
        }



        public float speed = 5f; 


        void Rushplayer()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                Vector3 direction = player.transform.position - transform.position;
                transform.Translate(direction.normalized * speed * Time.deltaTime);

                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < 1f) 
                {
                    PlayerDeath();
                }
            }
        }

        void PlayerDeath() 
        {
            Debug.Log("Le joueur est mort !");
        }

    }
}
