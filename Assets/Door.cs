using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactor
{

	public override void Interact()
	{
		SceneManager.LoadScene("MainMenu");
	}

}
