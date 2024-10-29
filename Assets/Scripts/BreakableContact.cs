using System.Collections;
using UnityEngine;

public class BreakableContact : MonoBehaviour
{

	[SerializeField] float fallSpeed = 5f;  // Speed at which the object will fall.
	[SerializeField] float shakeDuration = 2f; // Duration for the shake effect.
    [SerializeField] float shakeMagnitude = 0.1f; // Magnitude of the shake effect.
    bool isFalling = false;  // Flag to check if the object should start falling.
	bool hasTriggered = false; // Ensures the shake-and-fall coroutine runs only once.

    void FixedUpdate()
    {
        // If the object is falling, move it downwards.
        if (isFalling)
        {
            // Move the platform downwards based on fall speed and time.
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

			Destroy(this,15);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player triggered the collision.
        if (other.gameObject.CompareTag("Player") && !hasTriggered)
        {
            Debug.Log("Player touched the platform. Activating shake and fall.");
            StartCoroutine(ShakeAndFall());
			hasTriggered = true; // Mark as triggered to prevent further activations.

        }
    }

	private IEnumerator ShakeAndFall()
    {
        Vector3 originalPosition = transform.position;  // Store the original position.

        // Shake the object for the specified duration.
        float timeElapsed = 0f;
        while (timeElapsed < shakeDuration)
        {
            // Calculate a random offset for shaking.
            float xOffset = Random.Range(-shakeMagnitude, shakeMagnitude);
            float yOffset = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.position = originalPosition + new Vector3(xOffset, yOffset, 0);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Reset position to the original after shaking.
        transform.position = originalPosition;

        // Start falling after shaking.
        isFalling = true;

    }

}
