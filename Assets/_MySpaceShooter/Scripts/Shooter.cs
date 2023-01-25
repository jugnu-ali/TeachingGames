using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.3f;
    
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVarience = 0.15f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector]
    public bool isFiring;

    Coroutine firingCoroutine;

    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject obj = Instantiate(projectilePrefab, transform.position, 
                                            Quaternion.identity);

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

            if(rb != null)
            {
                rb.velocity = transform.up *  projectileSpeed;
            }

            Destroy(gameObject, projectileLifetime);
            
            if(useAI)
            {
                yield return new WaitForSeconds(GetRandomSpawnTime());
            }
            else
            {
                yield return new WaitForSeconds(baseFiringRate);
            }
        }
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(baseFiringRate - firingRateVarience,
                                        baseFiringRate + firingRateVarience);

        return Mathf.Clamp(spawnTime, minimumFiringRate, float.MaxValue);
    }
}
