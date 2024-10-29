using UnityEngine;

public interface IInteractable{
	void Interact();
	void Backout();
}

public class Interactor : MonoBehaviour, IInteractable
{

	public string interactMessage = "Press 'E' to interact"; // interact message
    public bool isPlayerNearby = false;


    void FixedUpdate()
    {
        // Check if the player is nearby and presses E
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

		// Check for the ESC key press to close the note
        if (Input.GetKeyDown(KeyCode.Q))
        {
			Debug.Log("Recognized.");
            Backout();
        }
    }

    // This function triggers when the player interacts with the object
    public virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        // Override this method in child scripts for specific interactions
    }

	// This function triggers when the player wants to leave the object
	public virtual void Backout()
    {
        Debug.Log("Backed out of " + gameObject.name);
        // Override this method in child scripts for specific interactions
    }

    // Detect when the player enters the object's trigger zone
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log(interactMessage);
        }
    }

    // Detect when the player leaves the object's trigger zone
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
