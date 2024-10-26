using UnityEngine;
using UnityEngine.PostProcessing;

public class CamShotHandler : MonoBehaviour
{
	public GameObject PostProcessingSC;

	public GameObject CameraShot_1;

	public GameObject CameraShot_2;

	public float CurentCamera;

	public GameObject AyanoAnimPart2;

	public GameObject AyanoAnimPart1;

	public GameObject InteractableObjectsStatic;

	public GameObject InteractableObjectsAnimated;

	public GameObject BasuBGnoise;

	private HeartBeatEffects TargetScript;

	private bool isDarknessEnabled;

	public GameObject DarknessCubes;

	public PostProcessingProfile Profile;

	public Animation YandereAnim;

	public AudioSource Jukebox;

	public UISprite Darkness;

	public Transform[] BlackBar;

	public Transform[] Camera;

	public Transform[] Head;

	public Transform Sword;

	public bool FadeOut;

	public float BlackBarTimer;

	public float Timer;

	public float Shot;

	public GameObject SisterVc1;

	public GameObject SisterVc2;

	public GameObject SisterVc3;

	public GameObject SisterVc4;

	public GameObject SisterVc5;

	public GameObject SisterVc6;

	public GameObject SisterVc7;

	public GameObject SisterVc8;

	public GameObject HeartbeatSFX;

	private void Start()
	{
		CameraShot_1.SetActive(value: true);
		CameraShot_2.SetActive(value: false);
		AyanoAnimPart2.SetActive(value: false);
		AyanoAnimPart1.SetActive(value: true);
		InteractableObjectsAnimated.SetActive(value: false);
		InteractableObjectsStatic.SetActive(value: true);
		BasuBGnoise.SetActive(value: false);
		TargetScript = GameObject.Find("1LGT_SFX-heartbeat").GetComponent<HeartBeatEffects>();
		Darkness.alpha = 1f;
	}

	public void ChangeCamera()
	{
		if (CurentCamera == 0f)
		{
			CurentCamera = 1f;
		}
		else if (CurentCamera == 1f)
		{
			CurentCamera = 0f;
		}
		Shot += 1f;
		Debug.Log("We just advanced to Shot #" + Shot);
		if (Shot == 1f)
		{
			BlackBar[0].gameObject.SetActive(value: false);
			BlackBar[1].gameObject.SetActive(value: false);
		}
	}

	private void AnimationChange()
	{
		AyanoAnimPart2.SetActive(value: true);
		AyanoAnimPart1.SetActive(value: false);
		InteractableObjectsAnimated.SetActive(value: true);
		InteractableObjectsStatic.SetActive(value: false);
	}

	public void TimingFixInOut()
	{
	}

	private void PlayBasuBGNoise()
	{
		BasuBGnoise.SetActive(value: true);
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Mathf.Abs(Timer - Jukebox.time) > 1f)
		{
			Jukebox.time = Timer;
		}
		if (Shot == 1f)
		{
			UpdateDOF(Vector3.Distance(Camera[(int)CurentCamera].position, Head[0].position), 1f);
		}
		else if (Shot < 3f || Shot == 7f)
		{
			UpdateDOF(Vector3.Distance(Camera[(int)CurentCamera].position, Head[0].position), 5.6f);
		}
		else if (Shot > 2f && Shot < 7f)
		{
			UpdateDOF(Vector3.Distance(Camera[(int)CurentCamera].position, Sword.position), 5.6f);
		}
		else if (Shot == 9f)
		{
			UpdateDOF(0.25f, 32f);
		}
		else if (Shot == 10f)
		{
			UpdateDOF(0.15f, 32f);
		}
		else
		{
			UpdateDOF(Vector3.Distance(Camera[(int)CurentCamera].position, Head[1].position), 5.6f);
		}
		if (CurentCamera == 0f)
		{
			CameraShot_1.SetActive(value: true);
			CameraShot_2.SetActive(value: false);
		}
		else if (CurentCamera == 1f)
		{
			CameraShot_1.SetActive(value: false);
			CameraShot_2.SetActive(value: true);
		}
		if (Shot == 10f)
		{
			Debug.Log("We're seeing a close-up of Ayano's eyes.");
			BlackBarTimer += Time.deltaTime;
			if (BlackBarTimer > 0.4f)
			{
				Debug.Log("Attempting to make black bars appear.");
				BlackBar[0].localPosition = Vector3.Lerp(BlackBar[0].localPosition, new Vector3(0f, 5200f, 0f), Time.deltaTime * 10f);
				BlackBar[1].localPosition = Vector3.Lerp(BlackBar[1].localPosition, new Vector3(0f, -5200f, 0f), Time.deltaTime * 10f);
			}
		}
		else if (Shot == 11f && YandereAnim["f02_SwordCutscene_AyanoPart_02"].time > YandereAnim["f02_SwordCutscene_AyanoPart_02"].length - 4f)
		{
			Debug.Log("We are now in the final 4 seconds of the animation.");
			YandereAnim["f02_SwordCutscene_AyanoPart_02"].speed -= Time.deltaTime * 0.25f;
			FadeOut = true;
		}
		if (!FadeOut)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.2f);
		}
		else
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 0.2f);
		}
	}

	public void DarkScene()
	{
		DarknessCubes.SetActive(value: true);
		if (!isDarknessEnabled)
		{
			isDarknessEnabled = true;
		}
		else
		{
			isDarknessEnabled = false;
		}
	}

	private void sisterVoices()
	{
		if (SisterVc7.activeSelf)
		{
			SisterVc8.SetActive(value: true);
		}
		if (SisterVc6.activeSelf)
		{
			SisterVc7.SetActive(value: true);
		}
		if (SisterVc5.activeSelf)
		{
			SisterVc6.SetActive(value: true);
		}
		if (SisterVc4.activeSelf)
		{
			SisterVc5.SetActive(value: true);
		}
		if (SisterVc3.activeSelf)
		{
			SisterVc4.SetActive(value: true);
		}
		if (SisterVc2.activeSelf)
		{
			SisterVc3.SetActive(value: true);
		}
		if (SisterVc1.activeSelf)
		{
			SisterVc2.SetActive(value: true);
		}
		SisterVc1.SetActive(value: true);
	}

	private void DestroyHeatbeat()
	{
		Object.Destroy(HeartbeatSFX);
	}

	private void HeartbeatSpeed()
	{
		TargetScript.SpeedupHeartBeat();
	}

	private void UpdateDOF(float Value, float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Value;
		Profile.depthOfField.settings = settings;
		UpdateAperture(Aperture);
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}
}
