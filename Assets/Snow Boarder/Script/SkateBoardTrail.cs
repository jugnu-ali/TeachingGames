using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateBoardTrail : MonoBehaviour
{
    ParticleSystem skateParticles;

    // Start is called before the first frame update
    void Start()
    {
        skateParticles = transform.Find("Trail").GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            skateParticles.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            skateParticles.Stop();
        }
    }
}
