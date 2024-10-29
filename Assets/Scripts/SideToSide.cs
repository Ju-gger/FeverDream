using UnityEngine;

public class SideToSide : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;     // Speed of movement
    [SerializeField] float moveRange = 2f;     // Max range to move up and down
	GameObject player;  // Store reference to player when on the platform

	Vector3 initialPosition;  // Store the initial position of the platform
    Vector3 lastPosition;  // Store the platform's last frame position


	void Start()
    {
        initialPosition = transform.position;  // Save starting point
    }

    void FixedUpdate()
    {
        TranslateFloor();
    }

    void TranslateFloor()
    {
        float movement = Mathf.PingPong(Time.fixedTime * moveSpeed, moveRange);
		float newX = initialPosition.x + movement;
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);

		// Update the platform's position
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        Vector3 deltaMovement = newPosition - lastPosition;  // Calculate the movement delta

        transform.position = newPosition;

        // If the player is on the platform, move the player by the same delta
        if (player != null)
        {
            player.transform.position += deltaMovement;
        }

        // Update last position for the next frame
        lastPosition = newPosition;
    }

	private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player lands on the platform, make the player a child of the platform
        if (collision.collider.CompareTag("Player"))
        {
            player = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // When the player leaves the platform, reset the parent to null
        if (collision.collider.CompareTag("Player"))
        {
            player = null;
        }
    }


}
