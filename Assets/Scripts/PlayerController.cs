using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Camera cam;
    [SerializeField] GameObject book,pcUI,pc,pc1;
    [SerializeField] CameraController camController;
    CharacterController controller;
    RaycastHit hit;
    bool pcIsOpen;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        Movement();
        if(Physics.Raycast(cam.transform.position,transform.forward,out hit,10)){
            if(hit.collider.name.Equals("pc") && Input.GetKeyDown(KeyCode.F) && !pcIsOpen){
                pcIsOpen = true;
                StartCoroutine(UIController.Instance.OpenCloseUIObject(pc.GetComponent<RectTransform>(),null));
                pc1.SetActive(true);
                camController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }
            if(hit.collider.name.Equals("book") && Input.GetKeyDown(KeyCode.F)){
                book.SetActive(true);
                camController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.Locked;
            UIController.Instance.ClosePC();
            pc1.SetActive(false);
            book.SetActive(false);
            camController.enabled = true;
            pcIsOpen = false;
        }
    }

    private void Movement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveForward = transform.forward * verticalInput * moveSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveRight = transform.right * horizontalInput * moveSpeed;

        Vector3 moveDirection = moveForward + moveRight;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
