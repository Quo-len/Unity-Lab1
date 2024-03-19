using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public float spinSpeed = 100f;

    private AudioSource audioSource; 
    public AudioClip collectSound;

    public ParticleSystem activateParticle;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("FFF");
            if (!audioSource.isPlaying || audioSource.clip != collectSound)
            {
                audioSource.clip = collectSound;
                audioSource.Play();
                if (activateParticle != null)
                    activateParticle.Play();
                if (textMeshPro != null)
                {
                    int coins = ++other.gameObject.GetComponent<BallController>().collectedCoins;
                    textMeshPro.text = "Collected Coins: " + coins.ToString();
                }
                Destroy(gameObject, collectSound.length);
            }
        }
    }

 
}
