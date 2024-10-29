using System.Collections;
using UnityEngine;

public class Clock : Interactor
{
	[SerializeField] GameObject doorBlocker;

	[Header("Clock Hands")]
	[SerializeField] Transform minuteHand;  // Long hand (minutes)
	[SerializeField] Transform hourHand;    // Short hand (hours)


	[Header("Rotation Speeds")]
	public float minuteHandSpeed = 6f;  // 6 degrees per second (360 / 60)
	public float hourHandSpeed = 0.5f;  // 0.5 degrees per second (360 / 12 / 60)

	[Header("Target Time (Hour, Minute)")]
	public int currentHour = 3;   // Start at 12 o'clock
	public int currentMinute = 40;  // Start at 00 minutes

	public int TargetHour = 6;   // Start at 12 o'clock
	public int TargetMinute = 30;  // Start at 00 minutes

	bool puzzleComplete = false;

	[Header("Cooldowns")]
	bool inputCooldown = false;  // Cooldown flag
    float cooldownTime = 0.1f;   // 100ms input delay

	// Initialize the clock with the currentHour and currentMinute on Awake
	void Awake()
	{
		SetClockToCurrentTime();
	}

	void Update()
	{
		//ConfirmTargetTime();


		if (puzzleComplete)
		{
			Destroy(doorBlocker); // Opens access to door
		}
	}

	// Cooldown function to prevent skipping
	private IEnumerator HandleMinuteIncrement()
    {
        inputCooldown = true;  // Start cooldown

        IncrementMinute();

        yield return new WaitForSeconds(cooldownTime);  // Wait for cooldown time
        inputCooldown = false;  // Reset cooldown
    }

	public override void Interact()
	{
		if (!inputCooldown)
        {
            StartCoroutine(HandleMinuteIncrement());
        }
	}

	private void SetClockToCurrentTime()
	{
		float minuteRotation = currentMinute * 6f;  // 6 degrees per minute
		float hourRotation = (currentHour % 12) * 30f + (currentMinute / 2f);
		// Add minute/2 to account for gradual hour hand movement

		minuteHand.localRotation = Quaternion.Euler(0, 0, -minuteRotation);
		hourHand.localRotation = Quaternion.Euler(0, 0, -hourRotation);

		Debug.Log("Clock initialized to " + currentHour + ":" + currentMinute);
	}

	private void IncrementHour()
	{
		currentHour = (currentHour % 12) + 1;  // Loop back to 1 after 12
		float newHourRotation = currentHour * 30f;  // 30 degrees per hour
		hourHand.localRotation = Quaternion.Euler(0, 0, -newHourRotation);

		Debug.Log("Hour set to: " + currentHour);
	}

	private void IncrementMinute()
	{
		currentMinute = (currentMinute + 5) % 60;  // Loop back to 0 after 55
		float newMinuteRotation = currentMinute * 6f;  // 6 degrees per 5 minutes
		minuteHand.localRotation = Quaternion.Euler(0, 0, -newMinuteRotation);

		Debug.Log("Minute set to: " + currentMinute);

		// Check if a new hour has passed when minutes wrap back to 0
		if (currentMinute == 0)
		{
			IncrementHour();
		}

		// Call confirmation after updating time
    	ConfirmTargetTime();

	}

	public bool TargetCheck()
	{
		// return true if the target time is hit
		Debug.Log($"Checking target: Current - {currentHour}:{currentMinute}, Target - {TargetHour}:{TargetMinute}");
		return (currentHour == TargetHour) && (currentMinute == TargetMinute);
	}

	public void ConfirmTargetTime()
	{
		if (TargetCheck())
		{
			StartCoroutine(PauseClockForConfirmation());
		}
	}

	// Wait 3 seconds for confirmation
	private IEnumerator PauseClockForConfirmation()
	{
		Debug.Log("Target time reached! Pausing for 3 seconds...");
		yield return new WaitForSeconds(3);  // Wait for 3 seconds

		if (TargetCheck())
		{
			puzzleComplete = true;
			Debug.Log("Confirmation complete! Clock resumed.");
		}
	}

}
