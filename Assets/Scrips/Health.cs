using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Configuraci�n de Vida")]
    // La vida m�xima, visible y editable en el Inspector
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
    /// Funci�n p�blica para recibir da�o.
    /// Esta es la funci�n que llamar�s desde el script del ataque (SlashHitbox).
    /// </summary>
    /// <param name="damageAmount">La cantidad de da�o a restar.</param>
    public void TakeDamage(float damageAmount)
    {
        // 1. Reducir la vida
        currentHealth -= damageAmount;

        // Opcional: Mostrar en la consola cu�nto da�o se hizo
        Debug.Log(gameObject.name + " recibi� " + damageAmount + " de da�o. Vida restante: " + currentHealth);

        // Opcional: L�gica visual/sonora (Ej. cambiar color, reproducir sonido de golpe)
        // Por ejemplo: GetComponent<SpriteRenderer>().color = Color.red;

        // 2. Comprobar si la vida lleg� a cero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// L�gica que se ejecuta cuando el personaje/enemigo muere.
    /// </summary>
    private void Die()
    {
        Debug.Log(gameObject.name + " ha sido derrotado.");

        // Opcional: L�gica de animaci�n de muerte o efectos
        // Por ejemplo: GetComponent<Animator>().SetTrigger("Death");

        // Destruye el objeto del enemigo de la escena.
        Destroy(gameObject);
    }
}