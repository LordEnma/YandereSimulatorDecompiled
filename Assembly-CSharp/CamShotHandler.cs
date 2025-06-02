using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

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

	public UISprite SecondDarkness;

	public UISprite SkipCircle;

	public UILabel[] Subtitle;

	public UISprite Darkness;

	public UIPanel SkipPanel;

	public Animation[] YandereAnim;

	public Animation SwordAnim;

	public Transform SparksTarget;

	public Transform SakyuLines;

	public Transform InkyuLines;

	public Transform Sword;

	public Transform[] BlackBar;

	public Transform[] Camera;

	public Transform[] Head;

	public GameObject Sparks;

	public GameObject Dust;

	public AudioSource BGM;

	public AudioSource SFX;

	public float FinalLineTimer;

	public float BlackBarTimer;

	public float SkipTimer;

	public float Timer;

	public float Shot;

	public string[] Dialogue;

	public bool EndEarly;

	public bool FadeOut;

	public AudioSource AyanoMouth;

	public AudioClip[] AyanoSounds;

	public float[] AyanoVolumes;

	public float[] AyanoTimes;

	public int AyanoPhase;

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
		SkipTimer += Time.deltaTime;
		if (SkipTimer > 5f || EndEarly)
		{
			SkipPanel.alpha -= Time.deltaTime;
		}
		if (!EndEarly && Input.GetButton(InputNames.Xbox_X))
		{
			SkipPanel.alpha = 1f;
			SkipTimer = 0f;
			SkipCircle.fillAmount -= Time.deltaTime;
			if (SkipCircle.fillAmount == 0f)
			{
				EndEarly = true;
			}
		}
		else
		{
			SkipCircle.fillAmount = 1f;
		}
		if (YandereAnim[0].gameObject.activeInHierarchy)
		{
			Timer = YandereAnim[0]["f02_SwordCutscene_AyanoPart_01"].time;
		}
		else
		{
			Timer += Time.deltaTime;
		}
		AyanoMouth.pitch = Time.timeScale;
		if (Timer >= AyanoTimes[AyanoPhase])
		{
			Debug.Log("Should be playing a sound now.");
			AyanoMouth.volume = AyanoVolumes[AyanoPhase] * 0.75f;
			AyanoMouth.clip = AyanoSounds[AyanoPhase];
			AyanoMouth.Play();
			AyanoPhase++;
		}
		if (BGM.isPlaying)
		{
			BGM.pitch = Time.timeScale;
			SFX.pitch = Time.timeScale;
			if (Mathf.Abs(Timer - BGM.time) > 0.1f)
			{
				BGM.time = Timer;
				SFX.time = Timer;
			}
			int num = CountActiveChildren(SakyuLines) + CountActiveChildren(InkyuLines);
			Subtitle[1].text = Dialogue[num];
			Subtitle[2].text = Subtitle[1].text;
			if (num == 8)
			{
				FinalLineTimer += Time.deltaTime;
				if (FinalLineTimer >= 10f)
				{
					Subtitle[1].enabled = false;
					Subtitle[2].enabled = false;
				}
			}
		}
		if ((Darkness.alpha >= 0.999f && Timer > 155f) || EndEarly)
		{
			if (Darkness.alpha < 0.999f)
			{
				SecondDarkness.alpha += Time.deltaTime;
				Darkness.alpha += Time.deltaTime;
				BGM.volume -= Time.deltaTime * 0.25f;
				SFX.volume -= Time.deltaTime;
			}
			else
			{
				Debug.Log("Transitioning to visual novel cutscene now!");
				GameGlobals.SisterCutscene = true;
				SceneManager.LoadScene("VisualNovelScene");
			}
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
			if ((double)Timer > 76.25 && !Dust.activeInHierarchy)
			{
				Dust.SetActive(value: true);
			}
			if ((double)Timer > 96.45 && !Sparks.activeInHierarchy)
			{
				Sparks.transform.position = SparksTarget.position;
				Sparks.transform.rotation = SparksTarget.rotation;
				Sparks.SetActive(value: true);
			}
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
		else if (Shot == 11f && YandereAnim[1]["f02_SwordCutscene_AyanoPart_02"].time > YandereAnim[1]["f02_SwordCutscene_AyanoPart_02"].length - 4f)
		{
			YandereAnim[1]["f02_SwordCutscene_AyanoPart_02"].speed -= Time.deltaTime * 0.25f;
			SwordAnim["Sword_AyanoInteraction"].speed -= Time.deltaTime * 0.25f;
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

	private int CountActiveChildren(Transform parent)
	{
		int num = 0;
		foreach (Transform item in parent)
		{
			if (item.gameObject.activeSelf)
			{
				num++;
			}
		}
		return num;
	}
}
