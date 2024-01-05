using UnityEngine;
using UnityEngine.PostProcessing;

public class TrueEndingScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public GameObject TrueEndingPanel;

	public GameObject TimelinePanel;

	public AudioSource Ambience;

	public AudioSource MyAudio;

	public AudioSource BuildUp;

	public AudioSource SFX;

	public Transform RyobaPonytail;

	public Transform RyobaTarget;

	public Transform RyobaHand;

	public Transform Letter;

	public Transform Target;

	public Transform[] Vantages;

	public Animation RyobaAnim;

	public UISprite Darkness;

	public UISprite DarkBG;

	public Texture DarkLogo;

	public UILabel Subtitle;

	public AudioClip[] Clip;

	public Rigidbody Plate;

	public UITexture Logo;

	public string[] Text;

	public float[] Times;

	public float PauseTimer;

	public float FadeTimer;

	public float WaitTimer;

	public float Timer;

	public float PauseLimit;

	public float Intensity;

	public float LastTime;

	public bool FadeOut;

	public bool Pause;

	public bool Shake;

	public int Pauses;

	public int Phase;

	private void Start()
	{
		base.transform.position = Vantages[0].position;
		base.transform.eulerAngles = Vantages[0].eulerAngles;
		Darkness.alpha = 1f;
		Subtitle.text = "";
		UpdateDOF(1f);
	}

	private void Update()
	{
		if (Pause)
		{
			PauseTimer += Time.deltaTime;
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				PauseTimer += 5f;
			}
			if (PauseTimer > PauseLimit)
			{
				Debug.Log("Ending pause.");
				base.transform.position = Vantages[Phase].position;
				base.transform.eulerAngles = Vantages[Phase].eulerAngles;
				RyobaAnim.Play();
				RyobaAnim["f02_trueEnding_00"].time = LastTime;
				RyobaAnim["f02_trueEnding_00"].speed = 1f;
				MyAudio.pitch = 1f;
				SFX.pitch = 1f;
				PauseTimer = 0f;
				Pause = false;
			}
			return;
		}
		Timer += Time.deltaTime;
		Ambience.volume = Mathf.MoveTowards(Ambience.volume, 0.25f, Time.deltaTime * 0.25f);
		if (Timer > 1f)
		{
			if (FadeOut)
			{
				Logo.alpha = Mathf.MoveTowards(Logo.alpha, 0f, Time.deltaTime * 0.33333f);
				if (Logo.alpha == 0f)
				{
					End();
				}
			}
			else
			{
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
				WaitTimer += Time.deltaTime;
				if (WaitTimer > 2f)
				{
					if (!MyAudio.isPlaying && !BuildUp.isPlaying)
					{
						if (Phase == 0)
						{
							RyobaAnim.Play();
							MyAudio.Play();
							SFX.Play();
						}
						else if (WaitTimer > 75.25f)
						{
							MyAudio.clip = Clip[16];
							MyAudio.time = 0f;
							MyAudio.Play();
							Logo.mainTexture = DarkLogo;
							DarkBG.alpha = 1f;
							Ambience.Stop();
							BuildUp.Stop();
							Shake = true;
						}
					}
					if (WaitTimer > 4.9f && base.transform.position == Vantages[0].position)
					{
						base.transform.position = Vantages[2].position;
						base.transform.eulerAngles = Vantages[2].eulerAngles;
					}
					if (WaitTimer > 11.25f && base.transform.position == Vantages[2].position)
					{
						base.transform.position = Vantages[17].position;
						base.transform.eulerAngles = Vantages[17].eulerAngles;
					}
					if (Phase > 6)
					{
						Target.position = Vector3.Lerp(Target.position, RyobaTarget.position, Time.deltaTime);
						base.transform.LookAt(Target);
						UpdateDOF(Vector3.Distance(base.transform.position, RyobaTarget.position));
						if (SFX.volume > 0f)
						{
							SFX.volume = 0f;
						}
					}
					if (WaitTimer > 7.5f && Pauses == 0)
					{
						PauseCutscene();
					}
					if (WaitTimer > 9f && Plate.transform.parent != null)
					{
						Plate.transform.parent = null;
						Plate.useGravity = true;
						Plate.isKinematic = false;
					}
					if (WaitTimer > 27.5f && Letter.transform.parent == null)
					{
						Letter.parent = RyobaHand;
						Letter.localPosition = new Vector3(-0.033333f, 0.008f, 0.0225f);
						Letter.localEulerAngles = new Vector3(-90f, 180f, 0f);
					}
					if (Input.GetButtonDown(InputNames.Xbox_A) && Phase < Times.Length - 2)
					{
						WaitTimer = Times[Phase] + 2f;
						MyAudio.time = Times[Phase];
						SFX.time = Times[Phase];
						RyobaAnim["f02_trueEnding_00"].time = Times[Phase];
					}
					if (MyAudio.time > Times[Phase])
					{
						RyobaAnim.transform.position = new Vector3(0f, 0f, 0f);
						Phase++;
						Subtitle.text = Text[Phase];
						base.transform.position = Vantages[Phase].position;
						if (Phase < 8)
						{
							base.transform.eulerAngles = Vantages[Phase].eulerAngles;
						}
						if (Phase == 15)
						{
							BuildUp.Play();
						}
					}
				}
			}
		}
		if (!Shake)
		{
			return;
		}
		Logo.transform.localPosition = new Vector3(Random.Range(-1f, 1f) * Intensity, Random.Range(-1f, 1f) * Intensity, Random.Range(-1f, 1f) * Intensity);
		Intensity = Mathf.MoveTowards(Intensity, 0f, Time.deltaTime * 100f);
		if (Intensity == 0f)
		{
			FadeTimer += Time.deltaTime;
			if (FadeTimer > 5f && !FadeOut)
			{
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				FadeOut = true;
			}
		}
	}

	private void LateUpdate()
	{
		RyobaPonytail.transform.eulerAngles = new Vector3(0f, RyobaPonytail.transform.eulerAngles.y, RyobaPonytail.transform.eulerAngles.z);
	}

	public void PauseCutscene()
	{
		Debug.Log("Beginning pause.");
		LastTime = RyobaAnim["f02_trueEnding_00"].time;
		RyobaAnim.Stop();
		MyAudio.pitch = 0.0001f;
		SFX.pitch = 0.0001f;
		Pause = true;
		Pauses++;
		if (Pauses == 1)
		{
			base.transform.position = new Vector3(-0.5f, 1f, 0f);
			base.transform.eulerAngles = new Vector3(15f, -15f, 0f);
			PauseLimit = 3f;
		}
	}

	public void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
		UpdateAperture(5.6f);
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}

	public void End()
	{
		base.transform.position = new Vector3(0f, -3f, 0f);
		base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		TrueEndingPanel.SetActive(value: false);
		TimelinePanel.SetActive(value: true);
		base.enabled = false;
	}
}
