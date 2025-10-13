using UnityEngine;

public class SlashHitbox : MonoBehaviour
{
    [Header("Configuración del Ataque")]
    [SerializeField]
    private float damage = 30f; 

    [SerializeField]
    private float lifespan = 0.2f; 
    
    private bool hasHit = false; 

    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health enemyHealth = other.GetComponent<Health>();

        if (enemyHealth != null) 
        {
            enemyHealth.TakeDamage(damage);

        }
    }
}