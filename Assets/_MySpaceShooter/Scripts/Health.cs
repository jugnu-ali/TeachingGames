using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();

        audioPlayer = FindObjectOfType<AudioPlayer>();

        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        DamageDealer damageDealer = otherCollider.GetComponent<DamageDealer>();
        
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamageClip();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int amount)
    {
        if(isPlayer)
            Debug.Log("Health = " + health);

        health -= amount;

        if (isPlayer)
            Debug.Log("Health = " + health);

        if (isPlayer)
        {
            Debug.Log("Player Health = " + health);
        }

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        if(!isPlayer)
        {
            scoreKeeper.SetCurrentScore(score);
        }
        else
        {
            Debug.Log("Called Die on Player");
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem obj = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(obj.gameObject, obj.main.duration + obj.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
