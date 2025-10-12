using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Configuración de Vida")]
    // La vida máxima, visible y editable en el Inspector
    [SerializeField]
    private float maxHealth = 10f;

    // La vida actual, no visible en el Inspector (si es que no es necesario)
    private float currentHealth;

    // Se llama cuando el objeto inicia
    void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Función pública para recibir daño.
    /// Esta es la función que llamarás desde el script del ataque (SlashHitbox).
    /// </summary>
    /// <param name="damageAmount">La cantidad de daño a restar.</param>
    public void TakeDamage(float damageAmount)
    {
        // 1. Reducir la vida
        currentHealth -= damageAmount;

        // Opcional: Mostrar en la consola cuánto daño se hizo
        Debug.Log(gameObject.name + " recibió " + damageAmount + " de daño. Vida restante: " + currentHealth);

        // Opcional: Lógica visual/sonora (Ej. cambiar color, reproducir sonido de golpe)
        // Por ejemplo: GetComponent<SpriteRenderer>().color = Color.red;

        // 2. Comprobar si la vida llegó a cero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Lógica que se ejecuta cuando el personaje/enemigo muere.
    /// </summary>
    private void Die()
    {
        Debug.Log(gameObject.name + " ha sido derrotado.");

        // Opcional: Lógica de animación de muerte o efectos
        // Por ejemplo: GetComponent<Animator>().SetTrigger("Death");

        // Destruye el objeto del enemigo de la escena.
        Destroy(gameObject);
    }
}