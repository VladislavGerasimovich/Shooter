using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpSpeed = 7f;
        [SerializeField] private float _gravityFactor = 2f;

        public Vector3 VerticalVelocity { get; private set; }

        public void Falling()
        {
            VerticalVelocity += Physics.gravity * Time.deltaTime * _gravityFactor;
        }

        public void Flying()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                VerticalVelocity = Vector3.up * _jumpSpeed;
            }
            else
            {
                VerticalVelocity = Vector3.down;
            }
        }
    }
}