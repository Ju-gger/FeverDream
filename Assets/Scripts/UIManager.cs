using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] GameObject notePanel; // A panel in your UI to show the note

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
			notePanel.SetActive(false); // Start with the note panel hidden
        }
        else
        {
            Destroy(gameObject);
        }
    }

	public void ShowNote()
	{
		notePanel.SetActive(true);  // Show the note popup
		//Time.timeScale = 0;         // Pause the game
	}

	public void CloseNote()
	{
		notePanel.SetActive(false); // Hide the note popup
		//Time.timeScale = 1;         // Resume the game
	}
}
