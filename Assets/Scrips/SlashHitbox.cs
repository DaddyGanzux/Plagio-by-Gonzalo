using UnityEngine;

public class SlashHitbox : MonoBehaviour
{
    [Header("Configuraci�n del Ataque")]
    [SerializeField]
    private float damage = 20f; // El da�o que har� este ataque (ajusta a tu gusto)

    [SerializeField]
    private float lifespan = 0.2f; // El ataque dura 0.2 segundos
    
    // Opcional: Para evitar que un slash golpee a un enemigo varias veces
    private bool hasHit = false; 

    void Start()
    {
        // Destruir el objeto del slash despu�s de un corto tiempo
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Intentamos obtener el componente de vida del objeto que golpeamos
        Health enemyHealth = other.GetComponent<Health>();

        // 1. Comprobar si el objeto golpeado tiene el script de vida
        if (enemyHealth != null) 
        {
            // 2. Llamar a la funci�n para aplicar da�o
            enemyHealth.TakeDamage(damage);

            // Opcional: Si quieres que el slash se destruya al golpear algo:
            // Destroy(gameObject);
        }
    }
}