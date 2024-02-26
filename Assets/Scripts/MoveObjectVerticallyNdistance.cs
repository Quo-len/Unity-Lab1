using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectVerticallyNdistance : MonoBehaviour
{
    public float moveDistance = 1f; 
    public KeyCode moveUpKey = KeyCode.F;
    public float stopHeight = 10f; 

    private bool isMoving = false; 
    private Vector3 targetPosition; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(moveUpKey) && !isMoving)
        {
            targetPosition = transform.position + Vector3.up * moveDistance;
            targetPosition.y = Mathf.Min(targetPosition.y, stopHeight);
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveDistance);

            if (transform.position.y >= targetPosition.y)
            {
                isMoving = false;
            }
        }
    }
}
