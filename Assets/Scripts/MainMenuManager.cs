using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{

	// Starts game
	public void StartGame()
	{
		SceneManager.LoadScene("Level1"); // Loads Scene
	}


	public void Quit()
	{
		Application.Quit(); // Loads Scene
	}
}
