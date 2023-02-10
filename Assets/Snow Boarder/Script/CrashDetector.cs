using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float sceneDelay = 2f;
    ParticleSystem particle;
    CircleCollider2D headCollider;

    private void Start()
    {
        particle = transform.Find("CrashEffect").GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("Ouch, hit my Head");
            particle.Play();
            Invoke("ReloadScene", sceneDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
