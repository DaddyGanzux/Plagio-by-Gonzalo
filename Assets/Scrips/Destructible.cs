using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    private float health = 10f;

    public void Hit(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Debug.Log("Muro destruido!");
            Destroy(gameObject);
        }
    }
}