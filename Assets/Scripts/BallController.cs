using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int collectedCoins = 0;
    [Range(5f, 100f)]
    public float speed = 10f;
    [Range(0.01f, 5f)]
    public float scaleFactor = 1.5f;
    [Range(0f, 5f)]
    public float scaleChangeSpeed = 1f;
    public float massMultiplier = 1f;
    public float dragMultiplier = 1f;
    [Header("Lowest object size")]
    public float minScale = 0.3f;
    public static Vector3 initialPosition;

    public AudioClip shrinkSound;
    public AudioClip enlargeSound;
    private AudioSource audioSource;

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

        // Get AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        bool isEnlarging = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isShrinking = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        if (isEnlarging)
        {
            // Play enlarge sound
            if (!audioSource.isPlaying || audioSource.clip != enlargeSound)
            {
                audioSource.clip = enlargeSound;
                audioSource.Play();
            }
        }
        else if (isShrinking)
        {
            // Play shrink sound
            if (!audioSource.isPlaying || audioSource.clip != shrinkSound)
            {
                audioSource.clip = shrinkSound;
                audioSource.Play();
            }
        }

        transform.localScale += isEnlarging ? Vector3.one * scaleFactor * scaleChangeSpeed * Time.deltaTime :
                                isShrinking ? -Vector3.one * scaleFactor * scaleChangeSpeed * Time.deltaTime : Vector3.zero;

        transform.localScale = isShrinking ? Vector3.Max(transform.localScale, new Vector3(minScale, minScale, minScale)) : transform.localScale;

        AdjustMassAndDrag();

        UpdateCameraPosition();
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

}
