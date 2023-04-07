using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    CharacterController controller;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveForward = transform.forward * verticalInput * moveSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveRight = transform.right * horizontalInput * moveSpeed;

        Vector3 moveDirection = moveForward + moveRight;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
