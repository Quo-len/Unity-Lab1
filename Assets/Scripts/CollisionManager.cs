using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public delegate void TouchAction();
    public static event TouchAction OnTouched;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (OnTouched != null)
                OnTouched();
        }
    }


}
