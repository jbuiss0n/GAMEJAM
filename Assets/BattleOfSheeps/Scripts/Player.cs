using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfSheeps
{
    public class Player : MonoBehaviour
    {
        public float JumpForce;

        private SpriteRenderer m_spriteRenderer;
        private Rigidbody2D m_rigidbody;
        private Animator m_animator;

        public AudioClip HitSound;
        public AudioClip MoveSound;

        private bool m_isGrounded;
        private bool m_canDoubleJump;

        private bool m_isHit;

        void Start()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (m_isGrounded)
                {
                    SoundManager.Instance.PlaySingleSfx(MoveSound);
                    m_rigidbody.velocity = new Vector2(0, JumpForce);
                    m_canDoubleJump = true;
                    m_isGrounded = false;

                    m_animator.speed = .5f;
                }
                else if (m_canDoubleJump)
                {
                    SoundManager.Instance.PlaySingleSfx(MoveSound);
                    m_rigidbody.velocity = new Vector2(0, JumpForce);
                    m_canDoubleJump = false;
                }
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Ground")
            {
                m_isGrounded = true;
                m_animator.speed = 1f;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                m_isHit = true;
                Time.timeScale = 1;
                m_animator.Play("Player_Hit");
                StartCoroutine(DammageEffect());
                SoundManager.Instance.PlaySingleSfx(HitSound);
            }
        }
        IEnumerator DammageEffect()
        {
            for (int i = 0; i < 3; i++)
            {
                m_spriteRenderer.color = new Color(1, 0, 0, .4f);
                yield return new WaitForSeconds(0.2f);
                m_spriteRenderer.color = Color.white;
                yield return new WaitForSeconds(0.2f);
            }

            Time.timeScale = 1;
            m_isHit = false;
            yield break;
        }
    }
}
