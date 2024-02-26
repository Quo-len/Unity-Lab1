using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        Vector3 Position { get; }
        void Damage(float damage);
    }
}