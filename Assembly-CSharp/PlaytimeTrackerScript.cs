using UnityEngine;

public class PlaytimeTrackerScript : MonoBehaviour
{
	private float playtime;

	private float saveInterval = 60f;

	private float timer;

	private const string PlaytimeKey = "TotalPlaytime";

	private void Start()
	{
		playtime = PlayerPrefs.GetFloat("TotalPlaytime", 0f);
		timer = 0f;
	}

	private void Update()
	{
		float unscaledDeltaTime = Time.unscaledDeltaTime;
		playtime += unscaledDeltaTime;
		timer += unscaledDeltaTime;
		if (timer >= saveInterval)
		{
			SavePlaytime();
			timer -= saveInterval;
		}
	}

	private void SavePlaytime()
	{
		PlayerPrefs.SetFloat("TotalPlaytime", playtime);
		PlayerPrefs.Save();
	}

	private void OnApplicationQuit()
	{
		SavePlaytime();
	}

	public float GetTotalPlaytime()
	{
		return playtime;
	}
}
