using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Arrastra tu Prefab de AttackPivot aqu� desde el Inspector
    public GameObject slashPrefab;
    public float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;

    // Asume que tu script de movimiento tiene una variable para la �ltima direcci�n de vista
    // Si no la tienes, simplemente usa la direcci�n del input como se muestra.
    // public Vector2 lastLookDirection = Vector2.right; 

    void Update()
    {
        // 1. Verificar el Cooldown
        if (Time.time < nextAttackTime)
        {
            return;
        }

        // 2. Verificar el Input de Ataque
        if (Input.GetMouseButtonDown(0)) // Clic izquierdo
        {
            Vector2 slashDirection = GetDirectionalInput();

            if (slashDirection != Vector2.zero)
            {
                // 3. Ejecutar el ataque
                PerformSlash(slashDirection);
                nextAttackTime = Time.time + attackCooldown;
                // Opcional: Detener movimiento o iniciar animaci�n de ataque aqu�
            }
        }
    }

    Vector2 GetDirectionalInput()
    {
        Vector2 inputVector = Vector2.zero;

        // Priorizar el input de movimiento
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        // Normalizar para que la diagonal no sea m�s r�pida/larga
        if (inputVector != Vector2.zero)
        {
            return inputVector.normalized;
        }
        else
        {
            // Si NO hay input direccional, usar la direcci�n que est� "viendo"
            // Para 2D, generalmente es la direcci�n horizontal actual. 
            // Esto es si el personaje no est� en movimiento.

            // Opcional: Usa la �ltima direcci�n de movimiento almacenada
            // return lastLookDirection; 

            // O la direcci�n de la escala para saber si est� volteado
            return (transform.localScale.x > 0) ? Vector2.right : Vector2.left;
        }
    }

    void PerformSlash(Vector2 direction)
    {
        // 1. Calcular el �ngulo de rotaci�n a partir del vector de direcci�n
        // Mathf.Atan2 da el �ngulo en radianes, * Mathf.Rad2Deg lo convierte a grados.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // La rotaci�n se aplica en el eje Z para 2D.
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // 2. Instanciar el Prefab
        GameObject slash = Instantiate(slashPrefab, transform.position, rotation);

        // 3. Opcional: Voltear el personaje horizontalmente si es necesario
        // Si el ataque va a la izquierda, aseg�rate de que el personaje est� mirando a la izquierda
        if (direction.x < 0)
        {
            // Voltear el sprite o modelo (ejemplo simple)
            // transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x > 0)
        {
            // transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
