using UnityEngine;

public class ElevatingFloors : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;     // Speed of movement
    [SerializeField] float moveRange = 2f;     // Max range to move up and down

	Vector3 initialPosition;  // Store the initial position of the parent

	void Start()
    {
        initialPosition = transform.position;  // Save starting point
    }

    void FixedUpdate()
    {
        ElevatorFloor();
    }

    void ElevatorFloor()
    {
        foreach (Transform floor in transform)
		{
			float movement = Mathf.PingPong(Time.fixedTime * moveSpeed, moveRange);
			float newY = initialPosition.y + movement;
			floor.position = new Vector3(floor.position.x, newY, floor.position.z);
		}
    }
}
