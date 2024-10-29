using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{

	[SerializeField] PlayerInput playerInput;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
        {
            playerInput.SetIsLadder(true);
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
        {
            playerInput.SetIsLadder(false);
            playerInput.SetIsClimbing(false);
        }
	}

}
