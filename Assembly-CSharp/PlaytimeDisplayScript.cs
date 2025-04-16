using UnityEngine;

public class PlaytimeDisplayScript : MonoBehaviour
{
	public UILabel playtimeLabel;

	private const string PlaytimeKey = "TotalPlaytime";

	private float updateInterval = 60f;

	private float timer;

	private void Start()
	{
		timer = 0f;
		UpdatePlaytimeDisplay();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= updateInterval)
		{
			UpdatePlaytimeDisplay();
			timer -= updateInterval;
		}
	}

	private void UpdatePlaytimeDisplay()
	{
		float num = PlayerPrefs.GetFloat("TotalPlaytime", 0f);
		int num2 = Mathf.FloorToInt(num / 3600f);
		int num3 = Mathf.FloorToInt(num % 3600f / 60f);
		string text = $"Total Playtime: {num2} hours, {num3} minutes";
		if (playtimeLabel != null)
		{
			playtimeLabel.text = text;
		}
	}
}
