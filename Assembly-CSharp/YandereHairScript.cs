using UnityEngine;

public class YandereHairScript : MonoBehaviour
{
	public YandereScript Yandere;

	public int Frame;

	public int Limit;

	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + Yandere.Hairstyle + ".png");
		Limit = Yandere.Hairstyles.Length - 1;
	}

	private void Update()
	{
		if (Yandere.Hairstyle < Limit)
		{
			Frame++;
			if (Frame == 1)
			{
				Yandere.Hairstyle++;
				Yandere.UpdateHair();
			}
			if (Frame == 2)
			{
				ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + Yandere.Hairstyle + ".png");
				Frame = 0;
			}
		}
	}
}
