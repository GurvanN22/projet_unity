using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace // Add a namespace to enclose the top-level statements
{
    public class life : MonoBehaviour
    {
        // Start is called before the first frame update

        public int life_points = 2;
        void Start()
        {

        }

        // Update is called once per frame
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



        public float speed = 5f; // Vitesse de déplacement de l'ennemi


        void Rushplayer()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                // Déplacement vers le joueur
                Vector3 direction = player.transform.position - transform.position;
                transform.Translate(direction.normalized * speed * Time.deltaTime);

                // Vérification de la collision avec le joueur
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < 1f) // Changer cette valeur selon votre besoin
                {
                    // Collision avec le joueur, gérer la mort du joueur ici
                    PlayerDeath();
                }
            }
        }

        void PlayerDeath() // Remove the 'public' modifier
        {
            // À compléter : Gérer la mort du joueur (par exemple, désactiver le joueur, afficher un écran de fin, etc.)
            Debug.Log("Le joueur est mort !");
        }

    }
}
