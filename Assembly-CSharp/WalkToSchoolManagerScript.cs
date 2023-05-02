using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkToSchoolManagerScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public CosmeticScript Yandere;

	public CosmeticScript Senpai;

	public CosmeticScript Rival;

	public UISprite Darkness;

	public Transform[] Neighborhood;

	public Transform Window;

	public Transform RivalNeck;

	public Transform RivalHead;

	public Transform RivalEyeR;

	public Transform RivalEyeL;

	public Transform RivalJaw;

	public Transform RivalLipL;

	public Transform RivalLipR;

	public Transform SenpaiNeck;

	public Transform SenpaiHead;

	public Transform SenpaiEyeR;

	public Transform SenpaiEyeL;

	public Transform SenpaiJaw;

	public Transform SenpaiLipL;

	public Transform SenpaiLipR;

	public Transform YandereNeck;

	public Transform YandereHead;

	public Transform YandereEyeR;

	public Transform YandereEyeL;

	public AudioSource MyAudio;

	public float ScrollSpeed = 1f;

	public float LipStrength = 0.0001f;

	public float TimerLimit = 0.1f;

	public float TalkSpeed = 10f;

	public float AutoTimer;

	public float Timer;

	public float MouthExtent = 5f;

	public float MouthTarget;

	public float MouthTimer;

	public float RivalNeckTarget;

	public float RivalHeadTarget;

	public float RivalEyeRTarget;

	public float RivalEyeLTarget;

	public float SenpaiNeckTarget;

	public float SenpaiHeadTarget;

	public float SenpaiEyeRTarget;

	public float SenpaiEyeLTarget;

	public float YandereNeckTarget;

	public float YandereHeadTarget;

	public bool ShowWindow;

	public bool Debugging;

	public bool FadeOut;

	public bool Ending;

	public bool Auto;

	public bool Talk;

	public TypewriterEffect Typewriter;

	public UILabel NameLabel;

	public AudioClip[] Speech;

	public string[] Lines;

	public bool[] Speakers;

	public int Frame;

	public int ID;

	public Renderer PonytailRenderer;

	public Texture BlondePony;

	private void Start()
	{
		Application.targetFrameRate = 60;
		if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick)
		{
			Darkness.color = new Color(0f, 0f, 0f, 1f);
		}
		else
		{
			Darkness.color = new Color(1f, 1f, 1f, 1f);
		}
		Window.localScale = new Vector3(0f, 0f, 0f);
		Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].time = Random.Range(0f, Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].length);
		Yandere.WearOutdoorShoes();
		Senpai.WearOutdoorShoes();
		Rival.WearOutdoorShoes();
		if (GameGlobals.BlondeHair)
		{
			PonytailRenderer.material.mainTexture = BlondePony;
		}
	}

	private void Update()
	{
		for (int i = 1; i < 3; i++)
		{
			Transform transform = Neighborhood[i];
			transform.position = new Vector3(transform.position.x - Time.deltaTime * ScrollSpeed, transform.position.y, transform.position.z);
			if (transform.position.x < -160f)
			{
				transform.position = new Vector3(transform.position.x + 320f, transform.position.y, transform.position.z);
			}
		}
		if (!FadeOut)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			if (Darkness.color.a == 0f)
			{
				if (!ShowWindow)
				{
					if (!Ending)
					{
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							Timer = 1f;
						}
						Timer += Time.deltaTime;
						if (Timer > 1f)
						{
							RivalEyeRTarget = RivalEyeR.localEulerAngles.y;
							RivalEyeLTarget = RivalEyeL.localEulerAngles.y;
							SenpaiEyeRTarget = SenpaiEyeR.localEulerAngles.y;
							SenpaiEyeLTarget = SenpaiEyeL.localEulerAngles.y;
							ShowWindow = true;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Continue";
							PromptBar.Label[2].text = "Skip";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
					}
					else
					{
						Window.localScale = Vector3.Lerp(Window.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
						if ((double)Window.localScale.x < 0.01)
						{
							Timer += Time.deltaTime;
							if (Timer > 1f)
							{
								FadeOut = true;
							}
						}
					}
				}
				else
				{
					Window.localScale = Vector3.Lerp(Window.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if ((double)Window.localScale.x > 0.99)
					{
						if (Frame > 3)
						{
							Typewriter.mLabel.color = new Color(1f, 1f, 1f, 1f);
						}
						Frame++;
					}
					if (!Talk)
					{
						if ((double)Window.localScale.x > 0.99)
						{
							Talk = true;
							UpdateNameLabel();
							Typewriter.enabled = true;
							Typewriter.ResetToBeginning();
							Typewriter.mFullText = Lines[ID];
							Typewriter.mLabel.text = Lines[ID];
							Typewriter.mLabel.color = new Color(1f, 1f, 1f, 0f);
							MyAudio.clip = Speech[ID];
							MyAudio.Play();
						}
					}
					else
					{
						if (Auto && !MyAudio.isPlaying)
						{
							AutoTimer += Time.deltaTime;
						}
						if (Input.GetButtonDown(InputNames.Xbox_A) || AutoTimer > 1f)
						{
							Debug.Log("Detected button press.");
							AutoTimer = 0f;
							if (ID < Lines.Length - 1)
							{
								if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
								{
									Debug.Log("Line not finished yet.");
									Typewriter.Finish();
									Typewriter.mCurrentOffset = Typewriter.mFullText.Length;
								}
								else
								{
									Debug.Log("Line finished.");
									ID++;
									Frame = 0;
									Typewriter.ResetToBeginning();
									Typewriter.mFullText = Lines[ID];
									Typewriter.mLabel.text = Lines[ID];
									Typewriter.mLabel.color = new Color(1f, 1f, 1f, 0f);
									MyAudio.clip = Speech[ID];
									MyAudio.Play();
									UpdateNameLabel();
								}
							}
							else if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
							{
								Typewriter.Finish();
							}
							else
							{
								End();
							}
						}
						if (Input.GetButtonDown(InputNames.Xbox_X))
						{
							End();
						}
					}
				}
			}
		}
		else
		{
			MyAudio.volume -= Time.deltaTime;
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a == 1f && !Debugging)
			{
				SceneManager.LoadScene("LoadingScene");
			}
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale += 10f;
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale -= 10f;
		}
	}

	private void LateUpdate()
	{
		if (!Talk)
		{
			return;
		}
		if (!Ending)
		{
			RivalNeckTarget = Mathf.Lerp(RivalNeckTarget, 15f, Time.deltaTime * 3.6f);
			RivalHeadTarget = Mathf.Lerp(RivalHeadTarget, 15f, Time.deltaTime * 3.6f);
			RivalEyeRTarget = Mathf.Lerp(RivalEyeRTarget, 95f, Time.deltaTime * 3.6f);
			RivalEyeLTarget = Mathf.Lerp(RivalEyeLTarget, 275f, Time.deltaTime * 3.6f);
			SenpaiNeckTarget = Mathf.Lerp(SenpaiNeckTarget, -15f, Time.deltaTime * 3.6f);
			SenpaiHeadTarget = Mathf.Lerp(SenpaiHeadTarget, -15f, Time.deltaTime * 3.6f);
			SenpaiEyeRTarget = Mathf.Lerp(SenpaiEyeRTarget, 85f, Time.deltaTime * 3.6f);
			SenpaiEyeLTarget = Mathf.Lerp(SenpaiEyeLTarget, 265f, Time.deltaTime * 3.6f);
			YandereNeckTarget = Mathf.Lerp(YandereNeckTarget, 7.5f, Time.deltaTime * 3.6f);
			YandereHeadTarget = Mathf.Lerp(YandereHeadTarget, 7.5f, Time.deltaTime * 3.6f);
		}
		else
		{
			RivalNeckTarget = Mathf.Lerp(RivalNeckTarget, 0f, Time.deltaTime * 3.6f);
			RivalHeadTarget = Mathf.Lerp(RivalHeadTarget, 0f, Time.deltaTime * 3.6f);
			RivalEyeRTarget = Mathf.Lerp(RivalEyeRTarget, 90f, Time.deltaTime * 3.6f);
			RivalEyeLTarget = Mathf.Lerp(RivalEyeLTarget, 270f, Time.deltaTime * 3.6f);
			SenpaiNeckTarget = Mathf.Lerp(SenpaiNeckTarget, 0f, Time.deltaTime * 3.6f);
			SenpaiHeadTarget = Mathf.Lerp(SenpaiHeadTarget, 0f, Time.deltaTime * 3.6f);
			SenpaiEyeRTarget = Mathf.Lerp(SenpaiEyeRTarget, 90f, Time.deltaTime * 3.6f);
			SenpaiEyeLTarget = Mathf.Lerp(SenpaiEyeLTarget, 270f, Time.deltaTime * 3.6f);
			YandereNeckTarget = Mathf.Lerp(YandereNeckTarget, 0f, Time.deltaTime * 3.6f);
			YandereHeadTarget = Mathf.Lerp(YandereHeadTarget, 0f, Time.deltaTime * 3.6f);
		}
		RivalNeck.localEulerAngles = new Vector3(RivalNeck.localEulerAngles.x, RivalNeckTarget, RivalNeck.localEulerAngles.z);
		RivalHead.localEulerAngles = new Vector3(RivalHead.localEulerAngles.x, RivalHeadTarget, RivalHead.localEulerAngles.z);
		RivalEyeR.localEulerAngles = new Vector3(RivalEyeR.localEulerAngles.x, RivalEyeRTarget, RivalEyeR.localEulerAngles.z);
		RivalEyeL.localEulerAngles = new Vector3(RivalEyeL.localEulerAngles.x, RivalEyeLTarget, RivalEyeL.localEulerAngles.z);
		SenpaiNeck.localEulerAngles = new Vector3(SenpaiNeck.localEulerAngles.x, SenpaiNeckTarget, SenpaiNeck.localEulerAngles.z);
		SenpaiHead.localEulerAngles = new Vector3(SenpaiHead.localEulerAngles.x, SenpaiHeadTarget, SenpaiHead.localEulerAngles.z);
		SenpaiEyeR.localEulerAngles = new Vector3(SenpaiEyeR.localEulerAngles.x, SenpaiEyeRTarget, SenpaiEyeR.localEulerAngles.z);
		SenpaiEyeL.localEulerAngles = new Vector3(SenpaiEyeL.localEulerAngles.x, SenpaiEyeLTarget, SenpaiEyeL.localEulerAngles.z);
		YandereNeck.localEulerAngles = new Vector3(YandereNeck.localEulerAngles.x, YandereNeckTarget, YandereNeck.localEulerAngles.z);
		YandereHead.localEulerAngles = new Vector3(YandereHead.localEulerAngles.x, YandereHeadTarget, YandereHead.localEulerAngles.z);
		if (MyAudio.isPlaying)
		{
			MouthTimer += Time.deltaTime;
			if (MouthTimer > TimerLimit)
			{
				MouthTarget = Random.Range(40f, 40f + MouthExtent);
				MouthTimer = 0f;
			}
			if (Speakers[ID])
			{
				RivalJaw.localEulerAngles = new Vector3(RivalJaw.localEulerAngles.x, RivalJaw.localEulerAngles.y, Mathf.Lerp(RivalJaw.localEulerAngles.z, MouthTarget, Time.deltaTime * TalkSpeed));
				RivalLipL.localPosition = new Vector3(RivalLipL.localPosition.x, Mathf.Lerp(RivalLipL.localPosition.y, 0.02632812f + MouthTarget * LipStrength, Time.deltaTime * TalkSpeed), RivalLipL.localPosition.z);
				RivalLipR.localPosition = new Vector3(RivalLipR.localPosition.x, Mathf.Lerp(RivalLipR.localPosition.y, 0.02632812f + MouthTarget * LipStrength, Time.deltaTime * TalkSpeed), RivalLipR.localPosition.z);
			}
			else
			{
				SenpaiJaw.localEulerAngles = new Vector3(SenpaiJaw.localEulerAngles.x, SenpaiJaw.localEulerAngles.y, Mathf.Lerp(SenpaiJaw.localEulerAngles.z, MouthTarget, Time.deltaTime * TalkSpeed));
				SenpaiLipL.localPosition = new Vector3(SenpaiLipL.localPosition.x, Mathf.Lerp(SenpaiLipL.localPosition.y, 0.02632812f + MouthTarget * LipStrength, Time.deltaTime * TalkSpeed), SenpaiLipL.localPosition.z);
				SenpaiLipR.localPosition = new Vector3(SenpaiLipR.localPosition.x, Mathf.Lerp(SenpaiLipR.localPosition.y, 0.02632812f + MouthTarget * LipStrength, Time.deltaTime * TalkSpeed), SenpaiLipR.localPosition.z);
			}
		}
	}

	public void UpdateNameLabel()
	{
		if (Speakers[ID])
		{
			NameLabel.text = "Osana-chan";
		}
		else
		{
			NameLabel.text = "Senpai-kun";
		}
	}

	public void End()
	{
		PromptBar.Show = false;
		ShowWindow = false;
		Ending = true;
		Timer = 0f;
	}
}
