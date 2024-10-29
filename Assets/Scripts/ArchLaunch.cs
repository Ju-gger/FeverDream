using UnityEngine;

public class ArchLaunch : Interactor
{

	[SerializeField] GameObject notePrefab;  // The note to shoot out
    [SerializeField] Transform spawnPoint;   // Where the note spawns from
    [SerializeField] float launchForce = 5f; // Force to launch the note
    [SerializeField] Vector2 launchDirection = new Vector2(1f, 1f); // Direction of the arch
	bool hasTriggered = false; // Ensures the shake-and-fall coroutine runs only once.


	public override void Interact(){
		if (!hasTriggered){
			LaunchNote();
		}
	}

    void LaunchNote()
    {
		hasTriggered = true;
        // Create the note at the spawn point
        GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);

        // Apply a force to the note's Rigidbody2D for arched motion
        Rigidbody2D rb = note.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(launchDirection.normalized * launchForce, ForceMode2D.Impulse);
		}
    }
}
