using UnityEngine;

public class Note : Interactor
{

	public override void Interact()
	{
		Debug.Log("Note Read.");

		// Show the note and pause the game
		UIManager.Instance.ShowNote();

		//TODO stop movement
	}

	public override void Backout()
	{
		Debug.Log("Backed out of reading the note.");
		UIManager.Instance.CloseNote();
		//TODO continue movement
		
	}

}
