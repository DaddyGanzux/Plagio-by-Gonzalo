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
    BoxCollider m_boxCollider; // Referencia al collider del Game Object
    public string DeadSoneTag = "DeadSone";


    public void Jump()
    {
        enSuelo = false;
        rigidBody2DPlayer.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        //transformPlayer.position += new Vector3(0, 500, 0) * Time.deltaTime;
    }

    // Verificamos las colisiones
    void OnCollisionEnter2D(Collision2D other)
    {
        // Hemos puesto un tag "Ground" sobre el suelo
        if (other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        if (other.gameObject.CompareTag("DeadSone"))
        {
            ResetToOriginalPosition();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start empieza aqui");

        rigidBody2DPlayer = GetComponent<Rigidbody2D>();   //Jala el rb del objeto 
        m_boxCollider = GetComponent<BoxCollider>();
        enSuelo = true;
        originalPosition = transformPlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Moverse a la izquierda
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody2DPlayer.AddForce(Vector2.left * Velocidad);
            Debug.Log("Vamos a la izquierda");

            if (!mirandoDerecha)
            {
                Flip();
            }
        }

        // Moverse a la derecha
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody2DPlayer.AddForce(Vector2.right * Velocidad);
            Debug.Log("Vamos a la Derecha");

            if (mirandoDerecha)
            {
                Flip();
            }
        }

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo == true)
        { 
            Jump();
            Debug.Log("Saltemos");
        }
    }

    // Este es el método Flip
    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    // Da una taza fija de frames
    private void FixedUpdate()
    {

    }

    private void ResetToOriginalPosition()
    {
        transformPlayer.position = originalPosition;

    }
}
