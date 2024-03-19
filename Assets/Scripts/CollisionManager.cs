using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public delegate void TouchAction();
    public static event TouchAction OnTouched;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Endrew"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<RestartScript>().Restart();
            }
            if (OnTouched != null)
                OnTouched();
        }
    }


}
