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
            // L�gica de destrucci�n espec�fica para el muro
            Debug.Log("Muro destruido!");
            Destroy(gameObject);
        }
    }
}