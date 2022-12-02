using UnityEngine;

public class SpeedrunTimerScript : MonoBehaviour
{
	public PoliceScript Police;

	public UILabel Label;

	public float Timer;

	private void Start()
	{
		Label.enabled = false;
	}

	private void Update()
	{
		if (!Police.FadeOut)
		{
			Timer += Time.unscaledDeltaTime;
			if (Label.enabled)
			{
				Label.text = FormatTime(Timer) ?? "";
			}
			if (Input.GetKeyDown(KeyCode.Delete))
			{
				Label.enabled = !Label.enabled;
			}
		}
	}

	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}
}
