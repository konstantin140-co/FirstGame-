using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D
    private bool isDead; // Проверка, мёртв ли
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Если объект мёртв, уничтожаем его
        if (isDead)
        {
            if (gameObject.tag == "Player") // Если столкнулись с объектом с тегом "Player"
            {
                Destroy(gameObject); // Уничтожаем текущий объект
            }
            else if (gameObject.tag == "Ground") // Если столкнулись с объектом с тегом "Ground"
            {
                isDead = false; // Сбрасываем состояние "мёртв"
                MoveToNewPosition(); // Перемещаем текущий объект
                rb.linearVelocity = Vector2.zero; // Сбрасываем линейную скорость
                rb.angularVelocity = 0f;   // Сбрасываем угловую скорость
            }
        }
    }

    // Проверка, касается ли объект лавы
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava")) // Проверяем, что объект входит в лаву
        {
            isDead = true; // Устанавливаем состояние "мёртв"
        }
        else 
        {
            isDead = false; // Сбрасываем состояние "мёртв"
        }
    }

    void MoveToNewPosition()
    {
        float randomX = Random.Range(-10f, 10f); // Случайная координата X
        float BasedY = 40; // корда Y
        transform.position = new Vector3(randomX, BasedY, 0); // Перемещаем объект
    }
}