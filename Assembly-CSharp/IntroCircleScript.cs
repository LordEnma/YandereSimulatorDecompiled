using UnityEngine;

public class IntroCircleScript : MonoBehaviour
{
	public UISprite Sprite;

	public UILabel Label;

	public float[] StartTime;

	public float[] Duration;

	public string[] Text;

	public float CurrentTime;

	public float LastTime;

	public float Timer;

	public int ID;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (ID < StartTime.Length && Timer > StartTime[ID])
		{
			CurrentTime = Duration[ID];
			LastTime = Duration[ID];
			Label.text = Text[ID];
			ID++;
		}
		if (CurrentTime > 0f)
		{
			CurrentTime -= Time.deltaTime;
		}
		if (Timer > 1f)
		{
			Sprite.fillAmount = CurrentTime / LastTime;
			if (Sprite.fillAmount == 0f)
			{
				Label.text = string.Empty;
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CurrentTime -= 5f;
			Timer += 5f;
		}
	}
}
