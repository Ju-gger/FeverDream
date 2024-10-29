using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfKO : MonoBehaviour
{/*
    [SerializeField] float pushForce = 25f;  // Force applied when player pushes
	[SerializeField] float torqueForce = 5f;  // Force applied when player pushes

	
	bool isPlayerNearby;
	bool hasInteractedOnce = false;


    Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D from the parent GameObject (ShelfPivot)
        rb = GetComponentInParent<Rigidbody2D>();
		rb.isKinematic = true;  // Start as kinematic to prevent movement before interaction
		//rb.AddTorque(-pushForce, ForceMode2D.Impulse);
    }

	/*
	void FixedUpdate()
    {
        // Check if the player is nearby, presses E, and hasn't interacted yet
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !hasInteractedOnce)
        {
            Interact();
        }
    }
	

    public void Interact()
    {
		Debug.Log("Pushing Shelf...");

		// Mark as interacted to prevent further interactions
        hasInteractedOnce = true;

		// Make the shelf affected by physics when interacted with
        rb.isKinematic = false;

		// Apply torque to tip the shelf over
        rb.AddTorque(-torqueForce, ForceMode2D.Impulse);

		// Apply a downward force to counteract any floating effect
        rb.AddForce(Vector2.down * pushForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
*/
}
