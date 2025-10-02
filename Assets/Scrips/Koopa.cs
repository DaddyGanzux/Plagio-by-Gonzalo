using UnityEngine;

public class Crowler : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float speed = 2f;
    public bool movingLeft = true;
    [Header("Detección")]
    public Transform groundCheck;
    public Transform wallCheck;
    public float checkDistanceX = 1f;
    public float checkDistanceY = 0.3f;
    public LayerMask ayerMaskWall;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    //
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        // Operador ternario para dirección, primer valor si es true, segundo si es false
        float moveDir = movingLeft ? -1f : 1f;
        rb.linearVelocity = new Vector2(moveDir * speed, rb.linearVelocity.y);

        // Detectar pared y falta de suelo  
        bool hitWall = Physics2D.Raycast(wallCheck.position, movingLeft ? Vector2.left : Vector2.right, checkDistanceX, ayerMaskWall);
        bool noGround = !Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistanceY, ayerMaskWall);

        // Cambiar dirección
        if (hitWall || noGround)
        {
            Flip();
        }
    }

    private void Update()
    {
        // Debug Rays
        Debug.DrawRay(wallCheck.position, (movingLeft ? Vector2.left : Vector2.right) * checkDistanceX, Color.red);
        //CircleCast
        Debug.DrawRay(groundCheck.position, Vector2.down * checkDistanceY, Color.blue);

    }

    private void Flip()
    {
        Debug.Log("Flip");
        movingLeft = !movingLeft;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}


/*
using UnityEngine;

public class MovimientoEnemigoConPared : MonoBehaviour
{
    public float velocidad = 2f;
    private int direccion = -1;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobar si el objeto con el que choco
        if (collision.gameObject.CompareTag(GameReferences.Tags.Wall))
        {
            // Invertir la direccion al chocar
            direccion *= -1;

            // Opcional: Voltear el sprite para que mire en la nueva direccion
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
}*/