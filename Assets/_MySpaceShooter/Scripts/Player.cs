using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MySpaceShooter
{
    public class Player : MonoBehaviour
    {
        Vector2 rawInput;
        [SerializeField]
        float moveSpeed = 5.0f;

        Vector2 minBounds;
        Vector2 maxBounds;

        [SerializeField] float paddingLeft;
        [SerializeField] float paddingRight;
        [SerializeField] float paddingTop;
        [SerializeField] float paddingBottom;

        Shooter shooter;

        private void Awake()
        {
            shooter = GetComponent<Shooter>();
        }

        private void Start()
        {
            InitBounds();
        }

        void InitBounds()
        {
            Camera mainCamera = Camera.main;
            minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
            maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));


        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            Vector2 newPos = new Vector2();

            Vector2 delta = rawInput * Time.deltaTime * moveSpeed;

            newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
            newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

            transform.position = newPos;
        }

        private void OnMove(InputValue value)
        {
            rawInput = value.Get<Vector2>();
            //Debug.Log(rawInput);
        }

        void OnFire(InputValue value)
        {
            if(shooter != null)
            {
                shooter.isFiring = value.isPressed;
            }
        }
    }
}

