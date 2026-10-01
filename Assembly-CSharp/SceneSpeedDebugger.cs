using UnityEngine;

public class SceneSpeedDebugger : MonoBehaviour
{
	public AudioSource audioSource;

	private float timer;

	private void Update()
	{
		if (Input.GetKeyDown("="))
		{
			Time.timeScale++;
			if (audioSource != null)
			{
				audioSource.pitch = Time.timeScale;
			}
			Debug.Log($"[SpeedUp] TimeScale: {Time.timeScale}");
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale--;
			if (audioSource != null)
			{
				audioSource.pitch = Time.timeScale;
			}
			Debug.Log($"[SlowDown] TimeScale: {Time.timeScale}");
		}
		timer += Time.deltaTime;
		Mathf.FloorToInt(timer * 30f);
	}
}
