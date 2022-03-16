using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200039C RID: 924
public class PhoneScript : MonoBehaviour
{
	// Token: 0x06001A7C RID: 6780 RVA: 0x0011BD78 File Offset: 0x00119F78
	private void Start()
	{
		Time.timeScale = 1f;
		this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, -135f, this.Buttons.localPosition.z);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		if (DateGlobals.Week > 1 && DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			this.Darkness.color = new Color(0f, 0f, 0f, 0f);
		}
		if (EventGlobals.KidnapConversation)
		{
			this.VoiceClips = this.KidnapClip;
			this.Speaker = this.KidnapSpeaker;
			this.Text = this.KidnapText;
			this.Height = this.KidnapHeight;
			EventGlobals.BefriendConversation = true;
			EventGlobals.KidnapConversation = false;
		}
		else if (EventGlobals.BefriendConversation)
		{
			this.VoiceClips = this.BefriendClip;
			this.Speaker = this.BefriendSpeaker;
			this.Text = this.BefriendText;
			this.Height = this.BefriendHeight;
			EventGlobals.LivingRoom = true;
			EventGlobals.BefriendConversation = false;
		}
		else if (EventGlobals.OsanaConversation)
		{
			Debug.Log("The game believes that, right now, we're supposed to be seeing Osana's text message conversation.");
			this.VoiceClips = this.OsanaMessages.OsanaClips;
			this.Speaker = this.OsanaMessages.OsanaSpeakers;
			this.Text = this.OsanaMessages.OsanaTexts;
			this.Height = this.OsanaMessages.OsanaHeights;
			EventGlobals.OsanaConversation = true;
			EventGlobals.LivingRoom = true;
		}
		else
		{
			this.MeetingInfoChan = true;
		}
		if (GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = Color.black;
			this.LoveSickColorSwap();
		}
		if (this.PostElimination && ((GameGlobals.RivalEliminationID != 3 && GameGlobals.NonlethalElimination) || GameGlobals.RivalEliminationID == 9))
		{
			this.VoiceClips[1] = this.NonlethalClip[1];
			this.VoiceClips[2] = this.NonlethalClip[2];
			this.VoiceClips[3] = this.NonlethalClip[3];
			this.Text[1] = this.NonlethalText[1];
			this.Text[2] = this.NonlethalText[2];
			this.Text[3] = this.NonlethalText[3];
			this.Height[1] = this.NonlethalHeight[1];
			this.Height[2] = this.NonlethalHeight[2];
			this.Height[3] = this.NonlethalHeight[3];
		}
	}

	// Token: 0x06001A7D RID: 6781 RVA: 0x0011C008 File Offset: 0x0011A208
	private void Update()
	{
		if (!this.FadeOut)
		{
			if (this.Timer > 0f && this.Buttons.gameObject.activeInHierarchy)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					if (!this.Jukebox.isPlaying)
					{
						this.Jukebox.Play();
					}
					if (this.NewMessage == null)
					{
						this.SpawnMessage();
					}
				}
			}
			if (this.ShowPauseMenu)
			{
				this.PauseMenuTimer += Time.deltaTime;
				if (this.PauseMenuPhase == 0)
				{
					this.PauseMenu.localPosition = Vector3.Lerp(this.PauseMenu.localPosition, new Vector3(0f, -15f, 0f), Time.deltaTime * 10f);
					if (this.PauseMenuTimer > 1f)
					{
						base.GetComponent<AudioSource>().clip = this.AppInstall;
						base.GetComponent<AudioSource>().Play();
						this.PauseMenuPhase++;
					}
				}
				else if (this.PauseMenuPhase == 1)
				{
					this.InfoIcon.localScale = Vector3.Lerp(this.InfoIcon.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if (this.PauseMenuTimer > 2f)
					{
						base.GetComponent<AudioSource>().clip = this.SubtleWhoosh;
						base.GetComponent<AudioSource>().Play();
						this.PauseMenuPhase++;
					}
				}
				else if (this.PauseMenuPhase == 2)
				{
					this.PauseMenu.localPosition = Vector3.Lerp(this.PauseMenu.localPosition, new Vector3(-485f, -15f, 0f), Time.deltaTime * 10f);
					if (this.PauseMenuTimer > 3f)
					{
						base.GetComponent<AudioSource>().volume = 1f;
						this.ShowPauseMenu = false;
						this.ManuallyAdvance = true;
					}
				}
			}
			else
			{
				if (this.NewMessage != null)
				{
					this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, Mathf.Lerp(this.Buttons.localPosition.y, 0f, Time.deltaTime * 10f), this.Buttons.localPosition.z);
					this.AutoTimer += Time.deltaTime;
					if (this.OsanaCover != null)
					{
						if (this.MeetingInfoChan && this.ID > 5 && this.ID < 11)
						{
							this.OsanaCover.alpha = Mathf.MoveTowards(this.OsanaCover.alpha, 0f, Time.deltaTime);
						}
						else
						{
							this.OsanaCover.alpha = Mathf.MoveTowards(this.OsanaCover.alpha, 1f, Time.deltaTime);
						}
					}
					if ((this.Auto && this.AutoTimer > this.VoiceClips[this.ID].length + 1f) || Input.GetButtonDown("A") || this.ManuallyAdvance)
					{
						this.ManuallyAdvance = false;
						if (this.MeetingInfoChan && this.ID == 16 && this.PauseMenuPhase == 0 && !this.PostElimination)
						{
							base.GetComponent<AudioSource>().clip = this.SubtleWhoosh;
							base.GetComponent<AudioSource>().volume = 0.5f;
							base.GetComponent<AudioSource>().Play();
							this.ShowPauseMenu = true;
						}
						else
						{
							this.AutoTimer = 0f;
							if (this.ID < this.Text.Length - 1)
							{
								this.ID++;
								this.SpawnMessage();
							}
							else
							{
								this.Darkness.color = new Color(0f, 0f, 0f, 0f);
								this.FadeOut = true;
								if (!this.Buttons.gameObject.activeInHierarchy)
								{
									this.Darkness.color = new Color(0f, 0f, 0f, 1f);
								}
							}
						}
					}
				}
				if (Input.GetButtonDown("X") && this.Buttons.localPosition.y > -1f)
				{
					this.FadeOut = true;
				}
			}
		}
		else
		{
			this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, Mathf.Lerp(this.Buttons.localPosition.y, -135f, Time.deltaTime * 10f), this.Buttons.localPosition.z);
			base.GetComponent<AudioSource>().volume = 1f - this.Darkness.color.a;
			this.Jukebox.volume = 0.25f - this.Darkness.color.a * 0.25f;
			if (this.Darkness.color.a >= 1f)
			{
				if (DateGlobals.Week == 2)
				{
					GameGlobals.TransitionToPostCredits = true;
					SceneManager.LoadScene("CreditsScene");
				}
				else if (DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					if (DateGlobals.PassDays < 1)
					{
						DateGlobals.PassDays = 1;
					}
					SceneManager.LoadScene("CalendarScene");
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
					SceneManager.LoadScene("LivingRoomScene");
				}
				else
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
		}
		this.Timer += Time.deltaTime;
	}

	// Token: 0x06001A7E RID: 6782 RVA: 0x0011C680 File Offset: 0x0011A880
	private void SpawnMessage()
	{
		if (this.NewMessage != null)
		{
			this.NewMessage.transform.parent = this.OldMessages;
			this.OldMessages.localPosition = new Vector3(this.OldMessages.localPosition.x, this.OldMessages.localPosition.y + (72f + (float)this.Height[this.ID] * 32f), this.OldMessages.localPosition.z);
		}
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.VoiceClips[this.ID];
		component.Play();
		if (this.Speaker[this.ID] == 1)
		{
			this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.LeftMessage[this.Height[this.ID]]);
			this.NewMessage.transform.parent = this.Panel;
			this.NewMessage.transform.localPosition = new Vector3(-225f, -375f, 0f);
			this.NewMessage.transform.localScale = Vector3.zero;
		}
		else
		{
			this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.RightMessage[this.Height[this.ID]]);
			this.NewMessage.transform.parent = this.Panel;
			this.NewMessage.transform.localPosition = new Vector3(225f, -375f, 0f);
			this.NewMessage.transform.localScale = Vector3.zero;
			if (this.Speaker == this.KidnapSpeaker && this.Height[this.ID] == 8)
			{
				this.NewMessage.GetComponent<TextMessageScript>().Attachment = true;
			}
		}
		if (this.Height[this.ID] == 9 && this.Speaker[this.ID] == 2)
		{
			this.Buttons.gameObject.SetActive(false);
			this.Darkness.enabled = true;
			this.Jukebox.Stop();
			this.Timer = -99999f;
		}
		this.AutoLimit = (float)(this.Height[this.ID] + 1);
		this.NewMessage.GetComponent<TextMessageScript>().Label.text = this.Text[this.ID];
	}

	// Token: 0x06001A7F RID: 6783 RVA: 0x0011C8D8 File Offset: 0x0011AAD8
	private void LoveSickColorSwap()
	{
		foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
		{
			UISprite component = gameObject.GetComponent<UISprite>();
			if (component != null && component.color != Color.black && component.transform.parent)
			{
				component.color = new Color(1f, 0f, 0f, component.color.a);
			}
			UILabel component2 = gameObject.GetComponent<UILabel>();
			if (component2 != null && component2.color != Color.black)
			{
				component2.color = new Color(1f, 0f, 0f, component2.color.a);
			}
			this.Darkness.color = Color.black;
		}
	}

	// Token: 0x04002BCC RID: 11212
	public OsanaTextMessageScript OsanaMessages;

	// Token: 0x04002BCD RID: 11213
	public GameObject[] RightMessage;

	// Token: 0x04002BCE RID: 11214
	public GameObject[] LeftMessage;

	// Token: 0x04002BCF RID: 11215
	public AudioClip[] VoiceClips;

	// Token: 0x04002BD0 RID: 11216
	public AudioClip SubtleWhoosh;

	// Token: 0x04002BD1 RID: 11217
	public AudioClip AppInstall;

	// Token: 0x04002BD2 RID: 11218
	public GameObject NewMessage;

	// Token: 0x04002BD3 RID: 11219
	public AudioSource Jukebox;

	// Token: 0x04002BD4 RID: 11220
	public Transform OldMessages;

	// Token: 0x04002BD5 RID: 11221
	public Transform PauseMenu;

	// Token: 0x04002BD6 RID: 11222
	public Transform InfoIcon;

	// Token: 0x04002BD7 RID: 11223
	public Transform Buttons;

	// Token: 0x04002BD8 RID: 11224
	public Transform Panel;

	// Token: 0x04002BD9 RID: 11225
	public Vignetting Vignette;

	// Token: 0x04002BDA RID: 11226
	public UITexture OsanaCover;

	// Token: 0x04002BDB RID: 11227
	public UISprite Darkness;

	// Token: 0x04002BDC RID: 11228
	public UISprite Sprite;

	// Token: 0x04002BDD RID: 11229
	public int[] Speaker;

	// Token: 0x04002BDE RID: 11230
	public string[] Text;

	// Token: 0x04002BDF RID: 11231
	public int[] Height;

	// Token: 0x04002BE0 RID: 11232
	public AudioClip[] KidnapClip;

	// Token: 0x04002BE1 RID: 11233
	public int[] KidnapSpeaker;

	// Token: 0x04002BE2 RID: 11234
	public string[] KidnapText;

	// Token: 0x04002BE3 RID: 11235
	public int[] KidnapHeight;

	// Token: 0x04002BE4 RID: 11236
	public AudioClip[] BefriendClip;

	// Token: 0x04002BE5 RID: 11237
	public int[] BefriendSpeaker;

	// Token: 0x04002BE6 RID: 11238
	public string[] BefriendText;

	// Token: 0x04002BE7 RID: 11239
	public int[] BefriendHeight;

	// Token: 0x04002BE8 RID: 11240
	public AudioClip[] NonlethalClip;

	// Token: 0x04002BE9 RID: 11241
	public string[] NonlethalText;

	// Token: 0x04002BEA RID: 11242
	public int[] NonlethalHeight;

	// Token: 0x04002BEB RID: 11243
	public bool ManuallyAdvance;

	// Token: 0x04002BEC RID: 11244
	public bool MeetingInfoChan;

	// Token: 0x04002BED RID: 11245
	public bool PostElimination;

	// Token: 0x04002BEE RID: 11246
	public bool ShowPauseMenu;

	// Token: 0x04002BEF RID: 11247
	public bool FadeOut;

	// Token: 0x04002BF0 RID: 11248
	public bool Auto;

	// Token: 0x04002BF1 RID: 11249
	public float PauseMenuTimer;

	// Token: 0x04002BF2 RID: 11250
	public float AutoLimit;

	// Token: 0x04002BF3 RID: 11251
	public float AutoTimer;

	// Token: 0x04002BF4 RID: 11252
	public float Timer;

	// Token: 0x04002BF5 RID: 11253
	public int PauseMenuPhase;

	// Token: 0x04002BF6 RID: 11254
	public int ID;
}
