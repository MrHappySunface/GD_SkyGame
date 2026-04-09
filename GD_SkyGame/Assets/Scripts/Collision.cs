using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [Header("Pickup Sound")]
    public AudioClip pickupSound;
    public float volume = 1f;
    public Vector2 scoreRange = new Vector2(10f, 15f);

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.TryGetComponent<Health>(out var health))
        {
            if (gameObject.tag != "friend")
            {
                Debug.Log($"{gameObject.name} Hit");
                health.Damage(10);
            }
            else
            {
                col.gameObject.SendMessage("increase_score", scoreRange);
                health.Heal(1);
            }

            AudioSource playerAudio = col.GetComponent<AudioSource>();
            if (playerAudio != null && pickupSound != null)
            {
                playerAudio.PlayOneShot(pickupSound, volume);
            }
            Destroy(gameObject);
        }
    }
}