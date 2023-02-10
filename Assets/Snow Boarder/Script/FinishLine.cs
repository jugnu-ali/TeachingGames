using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float sceneDelay = 2f;
    ParticleSystem finishEffect;

    private void Start()
    {
        finishEffect = transform.Find("FinishEffect").GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("You Finished");
            finishEffect.Play();
            Invoke("ReloadScene", sceneDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
