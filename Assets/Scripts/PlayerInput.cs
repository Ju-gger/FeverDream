using UnityEngine;

public class PlayerInput : MonoBehaviour
{

	[Header("References")]
	[SerializeField] BEN playerCharacter;
	[SerializeField] Rigidbody2D playerRB;
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundLayer;
	[SerializeField] LayerMask jumpInteractLayer;
	[SerializeField] Animator anim;
	

	[Header("Movement")]
	public bool canJump = true;
	bool isRunning;
	float horizontal;


	[Header("Climbing")]
	float vertical;
	bool isLadder;
	bool isClimbing;

	void Awake()
	{
		playerRB = playerCharacter.GetComponent<Rigidbody2D>();
		anim = playerCharacter.GetComponent<Animator>();
		anim.SetBool("playerRun",false);
		isRunning = false;
    }

    void Update()
    {
		HandleJumpInput();
		IsClimbing();
		//Debug.Log("IsGrounded: " + IsGrounded());
    }

	void FixedUpdate()
	{
		HandleMovement();
		PlayerClimb();
	}

	private void HandleMovement()
    {
		horizontal = Input.GetAxis("Horizontal"); // Get continuous input

		// Check if Shift key is held for running
    	//isRunning = Input.GetKey(KeyCode.LeftShift);

		// Set speed based on whether player is running or walking
    	float currentSpeed = isRunning ? playerCharacter.GetRunSpeed() : playerCharacter.GetWalkSpeed();

		Vector3 movement = new Vector3(horizontal * currentSpeed, 0, 0); // Movement vector

        // Rotate character based on movement direction
        if (horizontal < 0)
        {
            playerCharacter.transform.rotation = Quaternion.Euler(0, 0, 0); // Face left
        }
        else if (horizontal > 0)
        {
            playerCharacter.transform.rotation = Quaternion.Euler(0, 180, 0); // Face right
        }

		anim.SetBool("playerRun", horizontal != 0);

        playerCharacter.Move(movement);

    }


	private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && canJump)
        {
            playerRB.AddForce(Vector2.up * playerCharacter.GetJumpForce(), ForceMode2D.Impulse);
		}

        if (Input.GetKeyUp(KeyCode.Space) && playerRB.velocity.y > 0)
        {
            playerRB.AddForce(Vector2.down * 0.5f, ForceMode2D.Impulse);
        }
    }

	// Checks if climbing
	private bool IsClimbing(){
		vertical = Input.GetAxis("Vertical");

        // Start climbing if player is on a ladder and pressing up/down
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

		/* OPTIONAL: No vertical INput stops climb
		else
		{
			isClimbing = false;
		}
		*/

		return isClimbing;
	}

	// Change player physics for climb
	private void PlayerClimb() 
	{
		if (isClimbing){
			playerRB.gravityScale = 0f; // Stops downward force
			playerRB.velocity = new Vector2(playerRB.velocity.x, vertical * playerCharacter.GetClimbSpeed());
		}
		else{
			playerRB.gravityScale = playerCharacter.GetGravity(); // re-input grav value
		}
	}

	public bool IsGrounded()
	{
		// Combine ground and jumpInteract layers using bitwise OR
        LayerMask combinedLayerMask = groundLayer | jumpInteractLayer;

		// Use raycasting to check for ground beneath the player
    	RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, 
							Vector2.down, 0.5f, combinedLayerMask);
    
		//Debug.DrawRay(groundCheck.position, Vector2.down * 0.5f, hit.collider != null ? Color.green : Color.red);
    
    	return hit.collider != null; // Return true if the ray hit a collider
	}

	// returns object playerCharacter
	public BEN GetBEN()
	{
		return playerCharacter;
	}

	public void SetIsLadder(bool value){
		isLadder = value;
	}

	public void SetIsClimbing(bool value){
		isClimbing = value;
	}

	public float GetVertical()
	{
		return vertical;
	}

	public float GetHorizontal()
	{
		return horizontal;
	}

	public void SetCanJump(bool value){
		canJump = value;
	}


}
