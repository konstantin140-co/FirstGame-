using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float jump = 0;
    public float speed = 10.0f;
    private float movement;
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D
    private bool isGrounded; // Проверка, находится ли объект на земле
    public float jumpForce = 5.0f; // Сила прыжка

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        movement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(movement, 0, 0);

        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        // добавление прыжка
        if (jump < 2 && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump++; //двойной прыжок
        }
    }

    // Проверка, находится ли объект на земле
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Проверяем, что объект столкнулся с землей
        {
            jump = 0;
        }
    }
}