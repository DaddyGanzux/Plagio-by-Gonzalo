using UnityEngine;

public class MovimientoEnemigoConPared : MonoBehaviour
{
    public float velocidad = 3f;
    private int direccion = 1; // Direcci�n actual de movimiento (1 para derecha, -1 para izquierda)
    private Rigidbody2D rb;
    private bool mirandoDerecha = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Mover el enemigo en la direcci�n actual
        rb.linearVelocity = new Vector2(velocidad * direccion, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si el objeto con el que choc� tiene la etiqueta "Muro"
        if (collision.gameObject.CompareTag("Muro"))
        {
            // Invertir la direcci�n al chocar
            direccion *= -1;

            // Opcional: Voltear el sprite para que mire en la nueva direcci�n
            Flip();
        }
    }

    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}