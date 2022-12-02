using UnityEngine;

public class CountdownTimerScript : MonoBehaviour
{
	public UILabel CountdownLabel;

	public float Timer;

	private void Update()
	{
		Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
		DisplayTime(Timer);
	}

	private void DisplayTime(float timeToDisplay)
	{
		float num = Mathf.FloorToInt(timeToDisplay / 60f);
		float num2 = Mathf.FloorToInt(timeToDisplay % 60f);
		CountdownLabel.text = string.Format("{0:0}:{1:00}", num, num2);
	}
}
