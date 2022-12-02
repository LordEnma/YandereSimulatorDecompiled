using UnityEngine;

public class FramerateScript : MonoBehaviour
{
	public float updateInterval = 0.5f;

	private float accum;

	private int frames;

	private float timeleft;

	public float FpsAverage;

	public float FpsCurrent;

	public UILabel FPSLabel;

	private void Start()
	{
		timeleft = updateInterval;
	}

	private void Update()
	{
		FpsCurrent = 1f / Time.unscaledDeltaTime;
		timeleft -= Time.unscaledDeltaTime;
		accum += FpsCurrent;
		frames++;
		if (timeleft <= 0f)
		{
			FpsAverage = accum / (float)frames;
			timeleft = updateInterval;
			accum = 0f;
			frames = 0;
			int num = Mathf.Clamp((int)FpsAverage, 0, Application.targetFrameRate);
			Mathf.Clamp((int)FpsCurrent, 0, Application.targetFrameRate);
			FPSLabel.text = "FPS: " + num;
		}
	}
}
