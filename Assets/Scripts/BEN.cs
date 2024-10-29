using UnityEngine;

public class BEN : MonoBehaviour
{

	[Header("Movement")]
	[SerializeField] float walkSpeed = 10;
	[SerializeField] float runSpeed = 20;
	
	[SerializeField] float jumpForce = 10;
	float gravity = 4f;

	[Header("Climbing")]
	[SerializeField] float climbSpeed = 10;

	Rigidbody2D rb;

	void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	public void Move(Vector3 movement)
	{

		// Movement without collisions but not with
		//transform.localPosition += movement * speed * Time.deltaTime;

		// Movement ways with collisions

		rb.velocity = new Vector2(movement.x, rb.velocity.y);

		// Simple and Easy
		//rb.velocity = movement * speed;
		// more consistent and more control
		//rb.MovePosition(transform.localPosition + (movement * speed * Time.fixedDeltaTime));
		// Adds a force that pushes object around. Useful for Glidey, Space-like movement
		//rb.AddForce(movement * speed);

	}

	void Update()
	{
		rb.velocity = new Vector2(5f, rb.velocity.y);  // Move character to the right
	}

	public float GetJumpForce()
	{
		return jumpForce;
	}

	public float GetRunSpeed()
	{
		return runSpeed;
	}

	public float GetGravity()
	{
		return gravity;
	}

	public float GetWalkSpeed()
	{
		return walkSpeed;
	}

	public float GetClimbSpeed()
	{
		return climbSpeed;
	}

}
