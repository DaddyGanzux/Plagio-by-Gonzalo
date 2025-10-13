using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject slashPrefab;
    public float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;


    void Update()
    {
        if (Time.time < nextAttackTime)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 slashDirection = GetDirectionalInput();

            if (slashDirection != Vector2.zero)
            {
                PerformSlash(slashDirection);
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    Vector2 GetDirectionalInput()
    {
        Vector2 inputVector = Vector2.zero;

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

        if (inputVector != Vector2.zero)
        {
            return inputVector.normalized;
        }
        else
        {
            return (transform.localScale.x > 0) ? Vector2.left : Vector2.right;
        }
    }

    void PerformSlash(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        GameObject slash = Instantiate(slashPrefab, transform.position, rotation);

        if (direction.x < 0)
        {
        }
        else if (direction.x > 0)
        {
        }
    }
}
