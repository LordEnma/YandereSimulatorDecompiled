using UnityEngine;

public class ClockFaceScript : MonoBehaviour
{
	public Transform MinuteHand;

	public Transform HourHand;

	public ClockScript Clock;

	public void UpdateClockHands()
	{
		MinuteHand.localEulerAngles = new Vector3(MinuteHand.localEulerAngles.x, MinuteHand.localEulerAngles.y, Clock.Minute * 6f);
		HourHand.localEulerAngles = new Vector3(HourHand.localEulerAngles.x, HourHand.localEulerAngles.y, Clock.Hour * 30f);
	}
}
