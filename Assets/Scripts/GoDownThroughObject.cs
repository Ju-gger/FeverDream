using System.Collections;
using UnityEngine;

public class GoDownThroughObject : MonoBehaviour
{
	[SerializeField] EdgeCollider2D topCollider;
	public bool playerOnPlatform;

	void Awake()
	{
		topCollider = GetComponent<EdgeCollider2D>();
	}

	void Update()
	{
		if (playerOnPlatform && Input.GetAxis("Vertical") < 0){
			Debug.Log("StartingDescent");
			topCollider.enabled = false;
			StartCoroutine(EnableCollider());
		}
	}

	IEnumerator EnableCollider()
	{
		yield return new WaitForSeconds(0.5f);
		topCollider.enabled = true;
	}

	void SetPlayerOnPlatform(Collision2D other, bool value){
		// Checks if the collided object is the player by looking for a 'BEN' component.
        var player = other.gameObject.GetComponent<BEN>();

        if (player != null)
        {
            // If the player is detected, update the 'playerOnPlatform' flag.
            playerOnPlatform = value;
        }
	}

	void OnCollisionEnter2D(Collision2D other){
		// TODO When the player lands on the platform, set 'playerOnPlatform' to true.
        SetPlayerOnPlatform(other, true);
	}

	void OnCollisionExit2D(Collision2D other){
		SetPlayerOnPlatform(other,true);
	}

}
