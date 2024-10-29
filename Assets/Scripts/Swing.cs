using UnityEngine;

public class Swing : MonoBehaviour
{
	[SerializeField] private float swingAngle = 45f;      // Maximum swing angle in degrees
	[SerializeField] private float swingSpeed = 2f;       // Speed of swinging

	private Quaternion startRotation;                      // Starting rotation
	private Quaternion targetRotation;                     // Target rotation for swinging

	void Start()
	{
		// Store the original rotation of the object
		startRotation = transform.rotation;

		// Calculate the target rotation based on swing angle
		targetRotation = Quaternion.Euler(0, 0, swingAngle) * startRotation;
	}

	void Update()
	{
		// Calculate the rotation based on the direction and speed
		float t = Mathf.PingPong(Time.deltaTime * swingSpeed, 1f); // Oscillates t between 0 and 1

		// Determine the current swing direction
		Quaternion currentRotation = Quaternion.Lerp(startRotation, targetRotation, t);

		// If t is greater than 0.5, we need to switch to the opposite direction
		if (t > 0.5f)
		{
			// Calculate the new target rotation for the opposite swing
			targetRotation = Quaternion.Euler(0, 0, -swingAngle) * startRotation;
		}
		else
		{
			// Calculate the new target rotation for the original swing
			targetRotation = Quaternion.Euler(0, 0, swingAngle) * startRotation;
		}

		// Apply the current rotation to the transform
		transform.rotation = currentRotation;
	}
}
