using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class OsanaWarningScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public Transform RightHand;

	public UISprite Darkness;

	public float Alpha = 1f;

	public bool FadeOut;

	private void Start()
	{
		Darkness.color = new Color(0f, 0f, 0f, 1f);
		ColorGradingModel.Settings settings = Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 11.2f;
		Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		Profile.bloom.settings = settings3;
	}

	private void Update()
	{
		if (FadeOut)
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
		}
		else
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
		}
		Darkness.color = new Color(0f, 0f, 0f, Alpha);
		if (Alpha == 0f)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				FadeOut = true;
			}
		}
		else if (Alpha == 1f)
		{
			SceneManager.LoadScene("CalendarScene");
		}
	}

	private void LateUpdate()
	{
		RightHand.localEulerAngles += new Vector3(Random.Range(1f, -1f), Random.Range(1f, -1f), Random.Range(1f, -1f));
	}
}
