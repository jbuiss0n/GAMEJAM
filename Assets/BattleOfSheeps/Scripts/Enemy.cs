using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfSheeps
{
    public class Enemy : MonoBehaviour
    {
        public float Speed;

        private Rigidbody2D m_rigidbody;
        private Animator m_animator;

        void Start()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
        }

        void Update()
        {
            transform.position = new Vector3(transform.position.x - Speed * Time.timeScale, transform.position.y, transform.position.z);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Bound")
                transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }
    }
}
