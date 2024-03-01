using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyNamespace
{
    public class life : MonoBehaviour
    {
        [SerializeField] Transform target;
        NavMeshAgent agent;

        public int life_points = 2;
        GameObject playerObject;
        Player playerScript;

        private bool CanStrick = false;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            playerObject = GameObject.FindGameObjectWithTag("Player");
            target = playerObject.transform;
            playerScript = playerObject.GetComponent<Player>();
            Invoke("StrickReset", 2.5f);
        }

        void Update()
        {
            agent.SetDestination(target.position);
            // Rushplayer();
        }

        public void take_damage(int damage)
        {
            life_points -= damage;
            if (life_points <= 0)
            {
                playerScript.Add_kill();
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                take_damage(1);
            } else if (other.CompareTag("Player"))
            {
                Invoke("StrickReset", 1.5f);
                CanStrick = false;
                playerScript.take_damage(1);
            }
        }
        private void StrickReset()
    {
        CanStrick = true;
    }
    }
}