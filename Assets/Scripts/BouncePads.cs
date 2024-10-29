using UnityEngine;

public class BouncePads : MonoBehaviour
{
    public float bounceForce = 10f;  // Strength of the bounce
	Vector2 bounceDirection;
	//[SerializeField] PlayerInput playerInput;

    private void OnCollisionStay2D(Collision2D collision)
    {

        // Check if the object has a Rigidbody2D (needed to apply force)
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
			// Disable jump input while on the bounce pad
            //playerInput.SetCanJump(false);

			// Add Directional Bounces
			/*
			if (playerInput.GetHorizontal() > 0){ // going right
				Vector2 bounceDirection = new Vector2(1f, 1f).normalized;  // Diagonal bounce
			}
			else if (playerInput.GetHorizontal() < 0){ // going right
				Vector2 bounceDirection = new Vector2(1f, -1f).normalized;  // Diagonal bounce
			}
			*/

			// Calculate the bounce direction (upward by default)
            Vector2 bounceDirection = new Vector2(2f, 1f).normalized;  // Diagonal bounce
            // Apply an impulse force to make the object bounce
            rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }

	/*
	private void OnCollisionExit2D(Collision2D collision)
    {
        // Re-enable jump input when the player leaves the bounce pad
        if (collision.collider.CompareTag("Player"))
        {
            // Disable jump input while on the bounce pad
            playerInput.SetCanJump(true);
        }
    }
	*/

}
