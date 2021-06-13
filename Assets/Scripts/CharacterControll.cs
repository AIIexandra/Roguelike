using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControll : MonoBehaviour
{
    public float speed = 4.0f;
    public float speedJump = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;

    public float currentHealthPlayer = 50;  //здоровье
    public Slider healthBar;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        healthBar.maxValue = currentHealthPlayer;
    }

    void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = speedJump;
        }

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
    public void DamagePlayer(float damageAmount)
    {
        currentHealthPlayer -= damageAmount;
        healthBar.value = currentHealthPlayer;

        if (currentHealthPlayer <= 0)
        {
            //Destroy(gameObject);
        }
    }
}
