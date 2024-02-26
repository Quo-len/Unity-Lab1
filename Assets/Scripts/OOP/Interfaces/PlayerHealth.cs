using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        public float startingHealth = 100f;
        float m_CurrentHealth;

        [SerializeReference]
        public IDamageable shield = new ProtonShield();

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }
        void Start()
        {
            m_CurrentHealth = startingHealth;
        }
        public void Damage(float damage)
        {
            m_CurrentHealth -= damage;
        }
    }
}