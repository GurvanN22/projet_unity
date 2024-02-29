using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyNamespace
{
    public class life3 : MonoBehaviour
    {
        [SerializeField] Transform target;
        NavMeshAgent agent;

        public int life_points = 3;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
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
    }
}