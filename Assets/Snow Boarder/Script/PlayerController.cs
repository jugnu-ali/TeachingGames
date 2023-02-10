using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 15f;
    Rigidbody2D rigidbody2D;

    SurfaceEffector2D terrainEffector;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        terrainEffector = FindObjectOfType<SurfaceEffector2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();

        RespondToBoost();
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            terrainEffector.speed = boostSpeed;
        }
        else
        {
            terrainEffector.speed = baseSpeed;
        }
    }
}
