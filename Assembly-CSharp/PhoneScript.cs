using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneScript : MonoBehaviour
{
	public OsanaTextMessageScript OsanaMessages;

	public OsanaTextMessageScript AmaiMessages;

	public InputDeviceScript InputDevice;

	public GameObject[] RightMessage;

	public GameObject[] LeftMessage;

	public AudioClip[] VoiceClips;

	public AudioClip SubtleWhoosh;

	public AudioClip AppInstall;

	public GameObject NewMessage;

	public AudioSource Jukebox;

	public Transform OldMessages;

	public Transform PauseMenu;

	public Transform InfoIcon;

	public Transform Buttons;

	public Transform Panel;

	public Vignetting Vignette;

	public UITexture OsanaCover;

	public UISprite Darkness;

	public UISprite Sprite;

	public int[] Speaker;

	public string[] Text;

	public int[] Height;

	public AudioClip[] KidnapClip;

	public int[] KidnapSpeaker;

	public string[] KidnapText;

	public int[] KidnapHeight;

	public AudioClip[] BefriendClip;

	public int[] BefriendSpeaker;

	public string[] BefriendText;

	public int[] BefriendHeight;

	public AudioClip[] NonlethalClip;

	public string[] NonlethalText;

	public int[] NonlethalHeight;

	public bool ManuallyAdvance;

	public bool MeetingInfoChan;

	public bool PostElimination;

	public bool ShowPauseMenu;

	public bool FadeOut;

	public bool Auto;

	public float PauseMenuTimer;

	public float AutoLimit;

	public float AutoTimer;

	public float Timer;

	public int PauseMenuPhase;

	public int ID;

	private void Start()
	{
		Time.timeScale = 1f;
		Buttons.localPosition = new Vector3(Buttons.localPosition.x, -135f, Buttons.localPosition.z);
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
		if (DateGlobals.Week > 1 && DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			Darkness.color = new Color(0f, 0f, 0f, 0f);
			if (DateGlobals.Week == 3)
			{
				VoiceClips = AmaiMessages.OsanaClips;
				Speaker = AmaiMessages.OsanaSpeakers;
				Text = AmaiMessages.OsanaTexts;
				Height = AmaiMessages.OsanaHeights;
				NonlethalClip = AmaiMessages.AltClips;
				NonlethalText = AmaiMessages.AltTexts;
				NonlethalHeight = AmaiMessages.AltHeights;
			}
		}
		if (EventGlobals.KidnapConversation)
		{
			VoiceClips = KidnapClip;
			Speaker = KidnapSpeaker;
			Text = KidnapText;
			Height = KidnapHeight;
			EventGlobals.BefriendConversation = true;
			EventGlobals.KidnapConversation = false;
		}
		else if (EventGlobals.BefriendConversation)
		{
			VoiceClips = BefriendClip;
			Speaker = BefriendSpeaker;
			Text = BefriendText;
			Height = BefriendHeight;
			EventGlobals.LivingRoom = true;
			EventGlobals.BefriendConversation = false;
		}
		else if (EventGlobals.OsanaConversation)
		{
			Debug.Log("The game believes that, right now, we're supposed to be seeing a text message conversation with a rival.");
			if (DateGlobals.Week == 1)
			{
				Debug.Log("It's Week 1, so we should be having a conversation with Osana about her cat...");
				VoiceClips = OsanaMessages.OsanaClips;
				Speaker = OsanaMessages.OsanaSpeakers;
				Text = OsanaMessages.OsanaTexts;
				Height = OsanaMessages.OsanaHeights;
			}
			else if (DateGlobals.Week == 2)
			{
				Debug.Log("It's Week 2, so we should be having a conversation with Amai about rats...");
				VoiceClips = AmaiMessages.OsanaClips;
				Speaker = AmaiMessages.OsanaSpeakers;
				Text = AmaiMessages.OsanaTexts;
				Height = AmaiMessages.OsanaHeights;
			}
			EventGlobals.OsanaConversation = true;
			EventGlobals.LivingRoom = true;
		}
		else
		{
			MeetingInfoChan = true;
		}
		if (GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = Color.black;
			LoveSickColorSwap();
		}
		if (PostElimination && ((GameGlobals.RivalEliminationID != 3 && GameGlobals.NonlethalElimination) || GameGlobals.RivalEliminationID == 9))
		{
			VoiceClips[1] = NonlethalClip[1];
			VoiceClips[2] = NonlethalClip[2];
			VoiceClips[3] = NonlethalClip[3];
			Text[1] = NonlethalText[1];
			Text[2] = NonlethalText[2];
			Text[3] = NonlethalText[3];
			Height[1] = NonlethalHeight[1];
			Height[2] = NonlethalHeight[2];
			Height[3] = NonlethalHeight[3];
		}
	}

	private void Update()
	{
		if (!FadeOut)
		{
			if (Timer > 0f && Buttons.gameObject.activeInHierarchy)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
				if (Darkness.color.a == 0f)
				{
					if (!Jukebox.isPlaying)
					{
						Jukebox.Play();
					}
					if (NewMessage == null)
					{
						SpawnMessage();
					}
				}
			}
			if (ShowPauseMenu)
			{
				PauseMenuTimer += Time.deltaTime;
				if (PauseMenuPhase == 0)
				{
					PauseMenu.localPosition = Vector3.Lerp(PauseMenu.localPosition, new Vector3(0f, -15f, 0f), Time.deltaTime * 10f);
					if (PauseMenuTimer > 1f)
					{
						GetComponent<AudioSource>().clip = AppInstall;
						GetComponent<AudioSource>().Play();
						PauseMenuPhase++;
					}
				}
				else if (PauseMenuPhase == 1)
				{
					InfoIcon.localScale = Vector3.Lerp(InfoIcon.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if (PauseMenuTimer > 2f)
					{
						GetComponent<AudioSource>().clip = SubtleWhoosh;
						GetComponent<AudioSource>().Play();
						PauseMenuPhase++;
					}
				}
				else if (PauseMenuPhase == 2)
				{
					PauseMenu.localPosition = Vector3.Lerp(PauseMenu.localPosition, new Vector3(-485f, -15f, 0f), Time.deltaTime * 10f);
					if (PauseMenuTimer > 3f)
					{
						GetComponent<AudioSource>().volume = 1f;
						ShowPauseMenu = false;
						ManuallyAdvance = true;
					}
				}
			}
			else
			{
				if (NewMessage != null)
				{
					Buttons.localPosition = new Vector3(Buttons.localPosition.x, Mathf.Lerp(Buttons.localPosition.y, 0f, Time.deltaTime * 10f), Buttons.localPosition.z);
					AutoTimer += Time.deltaTime;
					if (OsanaCover != null)
					{
						if (MeetingInfoChan && ID > 5 && ID < 11)
						{
							OsanaCover.alpha = Mathf.MoveTowards(OsanaCover.alpha, 0f, Time.deltaTime);
						}
						else
						{
							OsanaCover.alpha = Mathf.MoveTowards(OsanaCover.alpha, 1f, Time.deltaTime);
						}
					}
					if ((Auto && AutoTimer > VoiceClips[ID].length + 1f) || Input.GetButtonDown(InputNames.Xbox_A) || ManuallyAdvance)
					{
						ManuallyAdvance = false;
						if (MeetingInfoChan && ID == 16 && PauseMenuPhase == 0 && !PostElimination)
						{
							GetComponent<AudioSource>().clip = SubtleWhoosh;
							GetComponent<AudioSource>().volume = 0.5f;
							GetComponent<AudioSource>().Play();
							ShowPauseMenu = true;
						}
						else
						{
							AutoTimer = 0f;
							if (ID < Text.Length - 1)
							{
								ID++;
								SpawnMessage();
							}
							else
							{
								Darkness.color = new Color(0f, 0f, 0f, 0f);
								FadeOut = true;
								if (!Buttons.gameObject.activeInHierarchy)
								{
									Darkness.color = new Color(0f, 0f, 0f, 1f);
								}
							}
						}
					}
				}
				if (Input.GetButtonDown(InputNames.Xbox_X) && Buttons.localPosition.y > -1f)
				{
					FadeOut = true;
				}
			}
		}
		else
		{
			Buttons.localPosition = new Vector3(Buttons.localPosition.x, Mathf.Lerp(Buttons.localPosition.y, -135f, Time.deltaTime * 10f), Buttons.localPosition.z);
			GetComponent<AudioSource>().volume = 1f - Darkness.color.a;
			Jukebox.volume = 0.25f - Darkness.color.a * 0.25f;
			if (Darkness.color.a >= 1f)
			{
				GameGlobals.LastInputType = (int)InputDevice.Type;
				if (!EventGlobals.OsanaConversation && DateGlobals.Week == 2)
				{
					SceneManager.LoadScene("PostCreditsScene");
				}
				else if (!EventGlobals.OsanaConversation && DateGlobals.Week == 3)
				{
					GameGlobals.DarkEnding = true;
					SceneManager.LoadScene("CreditsScene");
				}
				else if (DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					HomeGlobals.Night = true;
					GameGlobals.CorkboardScene = false;
					SceneManager.LoadScene("HomeScene");
				}
				else if (!EventGlobals.BefriendConversation && !EventGlobals.LivingRoom)
				{
					if (DateGlobals.PassDays < 1)
					{
						DateGlobals.PassDays = 1;
					}
					SceneManager.LoadScene("CalendarScene");
				}
				else if (EventGlobals.LivingRoom)
				{
					if (DateGlobals.Week == 1)
					{
						SceneManager.LoadScene("LivingRoomScene");
					}
					else
					{
						SceneManager.LoadScene("VisualNovelScene");
					}
				}
				else
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a + Time.deltaTime);
		}
		Timer += Time.deltaTime;
	}

	private void SpawnMessage()
	{
		if (NewMessage != null)
		{
			NewMessage.transform.parent = OldMessages;
			OldMessages.localPosition = new Vector3(OldMessages.localPosition.x, OldMessages.localPosition.y + (72f + (float)Height[ID] * 32f), OldMessages.localPosition.z);
		}
		AudioSource component = GetComponent<AudioSource>();
		component.clip = VoiceClips[ID];
		component.Play();
		if (Speaker[ID] == 1)
		{
			NewMessage = UnityEngine.Object.Instantiate(LeftMessage[Height[ID]]);
			NewMessage.transform.parent = Panel;
			NewMessage.transform.localPosition = new Vector3(-225f, -375f, 0f);
			NewMessage.transform.localScale = Vector3.zero;
		}
		else
		{
			NewMessage = UnityEngine.Object.Instantiate(RightMessage[Height[ID]]);
			NewMessage.transform.parent = Panel;
			NewMessage.transform.localPosition = new Vector3(225f, -375f, 0f);
			NewMessage.transform.localScale = Vector3.zero;
			if (Speaker == KidnapSpeaker && Height[ID] == 8)
			{
				NewMessage.GetComponent<TextMessageScript>().Attachment = true;
			}
		}
		if (Height[ID] == 9 && Speaker[ID] == 2)
		{
			Buttons.gameObject.SetActive(value: false);
			Darkness.enabled = true;
			Jukebox.Stop();
			Timer = -99999f;
		}
		AutoLimit = Height[ID] + 1;
		NewMessage.GetComponent<TextMessageScript>().Label.text = Text[ID];
	}

	private void LoveSickColorSwap()
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject obj in array)
		{
			UISprite component = obj.GetComponent<UISprite>();
			if (component != null && component.color != Color.black && (bool)component.transform.parent)
			{
				component.color = new Color(1f, 0f, 0f, component.color.a);
			}
			UILabel component2 = obj.GetComponent<UILabel>();
			if (component2 != null && component2.color != Color.black)
			{
				component2.color = new Color(1f, 0f, 0f, component2.color.a);
			}
			Darkness.color = Color.black;
		}
	}
}
