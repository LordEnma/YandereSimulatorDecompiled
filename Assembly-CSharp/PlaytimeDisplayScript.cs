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
		float @float = PlayerPrefs.GetFloat("TotalPlaytime", 0f);
		int num = Mathf.FloorToInt(@float / 3600f);
		int num2 = Mathf.FloorToInt(@float % 3600f / 60f);
		string text = $"Total Playtime: {num} hours, {num2} minutes";
		if (playtimeLabel != null)
		{
			playtimeLabel.text = text;
		}
	}
}
