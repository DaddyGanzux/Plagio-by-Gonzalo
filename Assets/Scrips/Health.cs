using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Configuraci�n de Vida")]
    [SerializeField]
    private float maxHealth = 50f;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        Debug.Log(gameObject.name + " recibi� " + damageAmount + " de da�o. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " ha sido derrotado.");

        Destroy(gameObject);
    }
}