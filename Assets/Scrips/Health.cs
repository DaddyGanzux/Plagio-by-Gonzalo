using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Configuración de Vida")]
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

        Debug.Log(gameObject.name + " recibió " + damageAmount + " de daño. Vida restante: " + currentHealth);

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