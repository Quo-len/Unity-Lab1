using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public float scaleFactor = 0.01f;
    public float scaleChangeSpeed = 1f;
    public float massMultiplier = 1f; 
    public float dragMultiplier = 1f;
    public float minScale = 0.3f;
    public Vector3 initialPosition;

    private Rigidbody rb;
    private float initialMass;
    private float initialDrag;

    private Camera mainCamera;
    private Vector3 cameraOffset;

    void Start()
    {
        Debug.Log("Movement with -WASD, Reset position - R, Shrink - Ctrl, Enlagre - Shift, F - Move Obstacle");
        rb = GetComponent<Rigidbody>();
        initialMass = rb.mass;
        initialDrag = rb.drag;

        mainCamera = Camera.main;
        cameraOffset = mainCamera.transform.position - transform.position;

        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            transform.localScale += Vector3.one * scaleFactor * scaleChangeSpeed * Time.deltaTime;
            AdjustMassAndDrag();
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            transform.localScale -= Vector3.one * scaleFactor * scaleChangeSpeed * Time.deltaTime;
            transform.localScale = Vector3.Max(transform.localScale, new Vector3(minScale, minScale, minScale));
            AdjustMassAndDrag();
        }

        UpdateCameraPosition();

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBallPosition();
        }
    }

    void AdjustMassAndDrag()
    {
        float scaleFactorMagnitude = transform.localScale.magnitude;
        rb.mass = initialMass * scaleFactorMagnitude * massMultiplier;
        rb.drag = initialDrag * scaleFactorMagnitude * dragMultiplier;
    }

    void UpdateCameraPosition()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * 10f;
        mainCamera.transform.RotateAround(transform.position, Vector3.up, rotation.y);
        mainCamera.transform.RotateAround(transform.position, mainCamera.transform.right, rotation.x);

        mainCamera.transform.position = transform.position + cameraOffset;
    }

    void ResetBallPosition()
    {
        transform.position = initialPosition;
        rb.velocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero;
    }
}
