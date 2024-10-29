using UnityEngine;

public class Pushable : MonoBehaviour
{
    public float pushStrength = 5f;  // Adjust this to control the pushing force

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the colliding object is the player (assuming it has a "Player" tag)
        if (collision.collider.CompareTag("Player"))
        {
            // Get the direction from the player to the object
            Vector2 direction = (transform.position - collision.transform.position).normalized;

            // Apply force to the object to simulate pushing
            rb.AddForce(direction * pushStrength, ForceMode2D.Force);
        }
    }
}
