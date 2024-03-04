using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the collision sound
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }
}
