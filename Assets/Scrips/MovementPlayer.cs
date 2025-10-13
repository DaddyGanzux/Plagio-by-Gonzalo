using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public Transform transformPlayer;
    public Rigidbody2D rigidBody2DPlayer;
    public float Velocidad = 1.5f;
    public float jump = 5f;
    private bool mirandoDerecha = true;
    private int VidaPersonaje = 0;
    public float numero = 15f;
    bool enSuelo;
    private Vector3 originalPosition;
    BoxCollider m_boxCollider;


    public void Jump()
    {
        enSuelo = false;
        rigidBody2DPlayer.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GameReferences.Tags.Suelo))
        {
            enSuelo = true;
        }

        if (other.gameObject.CompareTag(GameReferences.Tags.DeadZone))
        {
            ResetToOriginalPosition();
        }

        if (other.gameObject.CompareTag(GameReferences.Tags.Koopa))
        {
            ResetToOriginalPosition();
        }
    }

    void Start()
    {
        Debug.Log("Start empieza aqui");

        rigidBody2DPlayer = GetComponent<Rigidbody2D>();
        m_boxCollider = GetComponent<BoxCollider>();
        enSuelo = true;
        originalPosition = transformPlayer.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody2DPlayer.AddForce(Vector2.left * Velocidad);
            Debug.Log("Vamos a la izquierda");

            if (!mirandoDerecha)
            {
                Flip();
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody2DPlayer.AddForce(Vector2.right * Velocidad);
            Debug.Log("Vamos a la Derecha");

            if (mirandoDerecha)
            {
                Flip();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo == true)
        { 
            Jump();
            Debug.Log("Saltemos");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameReferences.Tags.CheckPoint))
        {
            originalPosition = collision.gameObject.transform.position;
        }
    }

    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void FixedUpdate()
    {

    }

    private void ResetToOriginalPosition()
    {
        transformPlayer.position = originalPosition;

    }
}
