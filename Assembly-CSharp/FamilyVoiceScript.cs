using UnityEngine;

public class FamilyVoiceScript : MonoBehaviour
{
	public StalkerPromptScript BreakerDoor;

	public StalkerYandereScript Yandere;

	public DetectionMarkerScript Marker;

	public AudioClip GameOverSound;

	public AudioClip GameOverLine;

	public AudioClip CrunchSound;

	public GameObject Heartbroken;

	public GameObject Lights;

	public Animation MyAnimation;

	public Transform YandereHead;

	public Transform Door;

	public Transform Head;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public Renderer Darkness;

	public UILabel Subtitle;

	public AudioClip[] SpeechClip;

	public AudioClip DoorOpen;

	public AudioClip PowerOn;

	public Transform[] Boundary;

	public Transform[] Node;

	public string[] SpeechText;

	public float[] SpeechTime;

	public string GameOverText;

	public float MinimumDistance;

	public float NoticeSpeed;

	public float Distance;

	public float FixTimer;

	public float Alpha;

	public float Scale;

	public float Timer;

	public float TargetRotation;

	public float Rotation;

	public int GameOverPhase;

	public int CurrentNode;

	public int SpeechPhase;

	public int AnimPhase;

	public bool Investigating;

	public bool OpenFrontDoor;

	public bool MultiClip;

	public bool GameOver;

	public bool Started;

	public bool Return;

	public bool ProximityGameOver;

	private void Start()
	{
		Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	private void Update()
	{
		if (!GameOver)
		{
			if (!Investigating)
			{
				if (Yandere.transform.position.y > base.transform.position.y - 1f && Yandere.transform.position.y < base.transform.position.y + 1f)
				{
					Distance = Vector3.Distance(Yandere.transform.position, base.transform.position);
					if (Distance < MinimumDistance)
					{
						if (!Started)
						{
							Subtitle.text = SpeechText[0];
							MyAudio.Play();
							Started = true;
						}
						else
						{
							MyAudio.pitch = Time.timeScale;
							if (MultiClip)
							{
								if (MyAnimation["fatherFixing_00"].time > MyAnimation["fatherFixing_00"].length)
								{
									MyAnimation["fatherFixing_00"].time = MyAnimation["fatherFixing_00"].time - MyAnimation["fatherFixing_00"].length;
								}
								if (AnimPhase == 0)
								{
									if (MyAnimation["fatherFixing_00"].time > 18f && MyAnimation["fatherFixing_00"].time < 18.1f)
									{
										Subtitle.text = SpeechText[SpeechPhase];
										MyAudio.clip = SpeechClip[SpeechPhase];
										MyAudio.Play();
										SpeechPhase++;
										AnimPhase = 1;
									}
								}
								else if (MyAnimation["fatherFixing_00"].time < 1f)
								{
									Subtitle.text = SpeechText[SpeechPhase];
									MyAudio.clip = SpeechClip[SpeechPhase];
									MyAudio.Play();
									SpeechPhase++;
									AnimPhase = 0;
								}
							}
							else if (SpeechPhase < SpeechTime.Length && MyAudio.time > SpeechTime[SpeechPhase])
							{
								Subtitle.text = SpeechText[SpeechPhase];
								SpeechPhase++;
							}
							Scale = Mathf.Abs(1f - (Distance - 1f) / (MinimumDistance - 1f));
							if (Scale < 0f)
							{
								Scale = 0f;
							}
							if (Scale > 1f)
							{
								Scale = 1f;
							}
							Jukebox.volume = 1f - 0.9f * Scale;
							Subtitle.transform.localScale = new Vector3(Scale, Scale, Scale);
							MyAudio.volume = Scale;
						}
						for (int i = 0; i < Boundary.Length; i++)
						{
							Transform transform = Boundary[i];
							if (transform != null && Vector3.Distance(Yandere.transform.position, transform.position) < 0.33333f)
							{
								Debug.Log("Got a ''proximity'' game over from " + base.gameObject.name);
								ProximityGameOver = true;
								TransitionToGameOver();
							}
						}
						LookForYandere();
					}
					else if (Distance < MinimumDistance + 1f)
					{
						Jukebox.volume = 1f;
						MyAudio.volume = 0f;
						Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
					}
				}
				if (Node.Length != 0)
				{
					Quaternion b = Quaternion.LookRotation(new Vector3(5.4f, 0f, -100f) - base.transform.parent.position);
					base.transform.parent.rotation = Quaternion.Slerp(base.transform.parent.rotation, b, Time.deltaTime * 10f);
				}
				return;
			}
			LookForYandere();
			base.transform.parent.position = Vector3.MoveTowards(base.transform.parent.position, Node[CurrentNode].position, Time.deltaTime);
			if (FixTimer == 0f || FixTimer == 5f)
			{
				Quaternion b2 = Quaternion.LookRotation(Node[CurrentNode].position - base.transform.parent.position);
				base.transform.parent.rotation = Quaternion.Slerp(base.transform.parent.rotation, b2, Time.deltaTime * 10f);
			}
			if (Vector3.Distance(base.transform.parent.position, Node[CurrentNode].position) < 0.1f)
			{
				if (CurrentNode == Node.Length - 1)
				{
					Return = true;
				}
				if (!Return)
				{
					CurrentNode++;
					if (CurrentNode == 3)
					{
						AudioSource.PlayClipAtPoint(DoorOpen, Door.transform.position);
						OpenFrontDoor = true;
					}
				}
				else if (FixTimer == 5f)
				{
					BreakerDoor.Label.text = "Open";
					BreakerDoor.Open = false;
					MyAnimation.CrossFade("walkConfident_00");
					CurrentNode--;
					if (CurrentNode == 1)
					{
						AudioSource.PlayClipAtPoint(DoorOpen, Door.transform.position);
						OpenFrontDoor = false;
					}
					if (CurrentNode < 0)
					{
						MyAnimation.CrossFade("fatherFixing_00");
						BreakerDoor.ServedPurpose = false;
						Investigating = false;
						Return = false;
						CurrentNode = 1;
						FixTimer = 0f;
					}
				}
				else
				{
					FixTimer = Mathf.MoveTowards(FixTimer, 5f, Time.deltaTime);
					if (FixTimer >= 4f && !Lights.activeInHierarchy)
					{
						AudioSource.PlayClipAtPoint(PowerOn, Camera.main.transform.position);
						Lights.SetActive(value: true);
					}
					MyAnimation.CrossFade("rummage_00");
				}
			}
			if (OpenFrontDoor)
			{
				Rotation = Mathf.Lerp(Rotation, TargetRotation, Time.deltaTime * 3.6f);
			}
			else
			{
				Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 3.6f);
			}
			Door.transform.localEulerAngles = new Vector3(Door.transform.localEulerAngles.x, Rotation, Door.transform.localEulerAngles.z);
			return;
		}
		MyAudio.pitch = Time.timeScale;
		if (GameOverPhase == 0)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f && !MyAudio.isPlaying)
			{
				Debug.Log("Should be updating the subtitle with the Game Over text.");
				Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				Subtitle.text = GameOverText ?? "";
				MyAudio.clip = GameOverLine;
				MyAudio.Play();
				GameOverPhase++;
			}
		}
		else if (!MyAudio.isPlaying || Input.GetButton("A"))
		{
			Heartbroken.SetActive(value: true);
			Subtitle.text = "";
			base.enabled = false;
			MyAudio.Stop();
		}
	}

	private bool YandereIsInFOV()
	{
		Vector3 to = Yandere.transform.position - Head.position;
		float num = 90f;
		return Vector3.Angle(Head.forward, to) <= num;
	}

	private bool YandereIsInLOS()
	{
		Debug.DrawLine(Head.position, new Vector3(Yandere.transform.position.x, YandereHead.position.y, Yandere.transform.position.z), Color.red);
		if (Physics.Linecast(Head.position, new Vector3(Yandere.transform.position.x, YandereHead.position.y, Yandere.transform.position.z), out var hitInfo) && hitInfo.collider.gameObject.layer == 13)
		{
			return true;
		}
		return false;
	}

	private void TransitionToGameOver()
	{
		Yandere.RPGCamera.transform.position += new Vector3(0f, 100f, 0f);
		if (!ProximityGameOver)
		{
			AudioSource.PlayClipAtPoint(GameOverSound, Yandere.RPGCamera.transform.position);
		}
		else
		{
			AudioSource.PlayClipAtPoint(CrunchSound, Camera.main.transform.position);
		}
		Marker.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		Marker.Tex.color = new Color(1f, 0f, 0f, 0f);
		Darkness.material.color = new Color(0f, 0f, 0f, 1f);
		Yandere.RPGCamera.enabled = false;
		Yandere.CanMove = false;
		Time.timeScale = 1f;
		Subtitle.text = "";
		GameOver = true;
		Jukebox.Stop();
		MyAudio.Stop();
		Alpha = 0f;
	}

	private void LookForYandere()
	{
		if (Yandere.Hidden && Yandere.Stance.Current == StanceType.Crouching)
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * NoticeSpeed);
		}
		else
		{
			if (YandereIsInFOV())
			{
				if (YandereIsInLOS())
				{
					Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * NoticeSpeed);
				}
				else
				{
					Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * NoticeSpeed);
				}
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * NoticeSpeed);
			}
			if (Investigating && Vector3.Distance(Yandere.transform.position, base.transform.parent.position) < 1f)
			{
				Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * NoticeSpeed * 2f);
			}
		}
		if (Alpha == 1f)
		{
			Debug.Log("Got a ''witnessed'' game over from " + base.gameObject.name);
			TransitionToGameOver();
		}
		Marker.Tex.transform.localScale = new Vector3(1f, Alpha, 1f);
		Marker.Tex.color = new Color(1f, 0f, 0f, Alpha);
	}
}
