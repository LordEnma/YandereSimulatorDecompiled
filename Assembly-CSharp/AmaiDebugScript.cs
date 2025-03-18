using UnityEngine;

public class AmaiDebugScript : MonoBehaviour
{
	public float timeScaleStep = 0.1f;

	public float minTimeScale = 0.1f;

	public float maxTimeScale = 5f;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale = Mathf.Clamp(Time.timeScale + timeScaleStep, minTimeScale, maxTimeScale);
		}
		else if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale = Mathf.Clamp(Time.timeScale - timeScaleStep, minTimeScale, maxTimeScale);
		}
	}
}
