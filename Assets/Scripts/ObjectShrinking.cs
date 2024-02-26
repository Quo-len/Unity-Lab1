using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShrinking : MonoBehaviour
{
    public Vector3 targetSize;
    public float shrinkSpeed = 1f;  

    private Vector3 initialSize;  
    private bool isShrinking = false;
    // Start is called before the first frame update
    void Start()
    {
        initialSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShrinking && transform.localScale.magnitude > targetSize.magnitude)
        {
            Vector3 newSize = transform.localScale - (Vector3.one * shrinkSpeed * Time.deltaTime);
            newSize = Vector3.Max(newSize, targetSize);
            transform.localScale = newSize;
        }
    }
}
