using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Ovni : MonoBehaviour
{
    public float radius = 0.5f;
    public float distance = 2f;
    public Transform player;//Referencia al jugador 

    public float speed = 2f;
    private Rigidbody2D rb;
    private bool followPlayer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (followPlayer == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);// MoveTowards - Mueve un punto en una direcci?n espec?fica a una velocidad constante
        }

        /*
        // Detectar si el jugador est? dentro del rango de detecci?n
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(GameReferences.Tags.Player))
            {
                // Moverse hacia el jugador
                Vector2 direction = (hit.transform.position - transform.position).normalized;
                rb.linearVelocity = direction * speed;
                return;
            }
        }
        // Si el jugador no est? en rango, detener el movimiento
        rb.linearVelocity = Vector2.zero;
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameReferences.Tags.Player))
        {
            collision.transform.position = player.position;
            followPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameReferences.Tags.Player))
        {
            followPlayer = false;
        }
    }

}