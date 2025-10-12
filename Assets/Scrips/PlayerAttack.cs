using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Arrastra tu Prefab de AttackPivot aquí desde el Inspector
    public GameObject slashPrefab;
    public float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;

    // Asume que tu script de movimiento tiene una variable para la última dirección de vista
    // Si no la tienes, simplemente usa la dirección del input como se muestra.
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
                // Opcional: Detener movimiento o iniciar animación de ataque aquí
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

        // Normalizar para que la diagonal no sea más rápida/larga
        if (inputVector != Vector2.zero)
        {
            return inputVector.normalized;
        }
        else
        {
            // Si NO hay input direccional, usar la dirección que está "viendo"
            // Para 2D, generalmente es la dirección horizontal actual. 
            // Esto es si el personaje no está en movimiento.

            // Opcional: Usa la última dirección de movimiento almacenada
            // return lastLookDirection; 

            // O la dirección de la escala para saber si está volteado
            return (transform.localScale.x > 0) ? Vector2.right : Vector2.left;
        }
    }

    void PerformSlash(Vector2 direction)
    {
        // 1. Calcular el ángulo de rotación a partir del vector de dirección
        // Mathf.Atan2 da el ángulo en radianes, * Mathf.Rad2Deg lo convierte a grados.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // La rotación se aplica en el eje Z para 2D.
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // 2. Instanciar el Prefab
        GameObject slash = Instantiate(slashPrefab, transform.position, rotation);

        // 3. Opcional: Voltear el personaje horizontalmente si es necesario
        // Si el ataque va a la izquierda, asegúrate de que el personaje esté mirando a la izquierda
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
