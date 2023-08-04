using UnityEngine;

public class GrandfatherScript : MonoBehaviour
{
	public ClockScript Clock;

	public Transform MinuteHand;

	public Transform HourHand;

	public Transform Pendulum;

	public float Rotation;

	public float Force;

	public float Speed;

	public bool Flip;

	private void Update()
	{
		if (!Flip)
		{
			if ((double)Force < 0.1)
			{
				Force += Time.deltaTime * 0.1f * Speed;
			}
		}
		else if ((double)Force > -0.1)
		{
			Force -= Time.deltaTime * 0.1f * Speed;
		}
		Rotation += Force;
		if (Rotation > 1f)
		{
			Flip = true;
		}
		else if (Rotation < -1f)
		{
			Flip = false;
		}
		if (Rotation > 5f)
		{
			Rotation = 5f;
		}
		else if (Rotation < -5f)
		{
			Rotation = -5f;
		}
		Pendulum.localEulerAngles = new Vector3(0f, 0f, Rotation);
	}

	public void UpdateClockHands()
	{
		MinuteHand.localEulerAngles = new Vector3(MinuteHand.localEulerAngles.x, MinuteHand.localEulerAngles.y, Clock.Minute * 6f);
		HourHand.localEulerAngles = new Vector3(HourHand.localEulerAngles.x, HourHand.localEulerAngles.y, Clock.Hour * 30f);
	}
}
