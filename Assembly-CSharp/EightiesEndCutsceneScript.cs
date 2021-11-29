using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200029B RID: 667
public class EightiesEndCutsceneScript : MonoBehaviour
{
	// Token: 0x060013FC RID: 5116 RVA: 0x000BDADC File Offset: 0x000BBCDC
	private void Start()
	{
		this.MainCamera.transform.localPosition = new Vector3(0f, 1.482f, -10f);
		this.MainCamera.clearFlags = CameraClearFlags.Color;
		this.MainCamera.backgroundColor = new Color(1f, 1f, 1f, 1f);
		this.MainCamera.farClipPlane = 150f;
		this.Clock.BloomFadeSpeed = 5f;
		this.Clock.StopTime = true;
		this.Clock.BloomWait = 1f;
		this.SkipPanel.alpha = 0f;
		this.Subtitle.text = "";
		for (int i = 1; i < 11; i++)
		{
			if (GameGlobals.GetRivalEliminations(i) == 1 || GameGlobals.GetRivalEliminations(i) == 2)
			{
				Debug.Log("Rival #" + i.ToString() + " was killed.");
				this.Deaths++;
			}
			else
			{
				Debug.Log("Apparently, Rival #" + i.ToString() + " does not appear to have bee killed.");
			}
			if (GameGlobals.GetRivalEliminations(i) == 11)
			{
				this.Disappearances++;
			}
		}
		if (this.Deaths == 10)
		{
			this.Text[6] = "...and your connection to at least one other person's death.";
			this.Text[12] = "...and every single one of those girls is dead now!";
			this.Clip[6] = this.DeadClip;
			this.Clip[12] = this.AllDeadClip;
		}
		else if (this.Disappearances == 10)
		{
			this.Text[6] = "...and your connection to at least one other person's disappearance.";
			this.Text[12] = "...and every single one of those girls has gone missing!";
			this.Clip[6] = this.MissingClip;
			this.Clip[12] = this.AllMissingClip;
		}
		else if (this.Deaths + this.Disappearances == 10)
		{
			this.Text[6] = "...and your connection to several other deaths and disappearances over the past 10 weeks.";
			this.Text[12] = "...and every single one of those girls is dead or missing!";
			this.Clip[6] = this.DeadOrMissingClip;
			this.Clip[12] = this.AllDeadOrMissingClip;
		}
		else if (this.Deaths > 0)
		{
			this.Text[6] = "...and your connection to at least one other person's death.";
			this.Text[12] = "Some of those girls are dead now! And the others? They're conveniently...out of the picture.";
			this.Clip[6] = this.DeadClip;
			this.Clip[12] = this.SomeDeadOrMissingClip;
		}
		else if (this.Disappearances > 0)
		{
			this.Text[6] = "...and your connection to at least one other person's disappearance.";
			this.Text[12] = "And some of those girls have gone missing. Tch...how convenient for you.";
			this.Clip[6] = this.MissingClip;
			this.Clip[12] = this.SomeMissingClip;
		}
		else if (this.Deaths + this.Disappearances == 0)
		{
			this.SkipLine6 = true;
			this.Text[12] = "...and from what I've heard, you've been doing everything in your power to keep girls away from him.";
			this.Clip[6] = this.Clip[0];
			this.Clip[12] = this.PacifistClip;
		}
		if (SchoolGlobals.SchoolAtmosphere < 0.5f)
		{
			this.Darkness.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	// Token: 0x060013FD RID: 5117 RVA: 0x000BDDF0 File Offset: 0x000BBFF0
	private void Update()
	{
		if (this.WarmUp)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.MyAudio.Play();
				this.Jukebox.Play();
				this.WarmUp = false;
				this.Timer = 0f;
				return;
			}
		}
		else
		{
			this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.1f, Time.deltaTime);
			if (!this.MyAudio.isPlaying || (this.Debugging && Input.GetButtonDown("A") && this.Phase < 16))
			{
				this.Timer = 1.1f;
				if (this.Timer > 1f)
				{
					this.Timer = 0f;
					this.Phase++;
					if (this.Phase == 6 && this.SkipLine6)
					{
						this.Phase++;
					}
					if (this.Phase < this.Text.Length)
					{
						this.Subtitle.text = this.Text[this.Phase];
						this.MyAudio.clip = this.Clip[this.Phase];
						this.MyAudio.Play();
						if (this.Phase == 2 || this.Phase == 3)
						{
							if (this.Phase == 3)
							{
								this.MainCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							}
							this.MainCamera.transform.localPosition = new Vector3(0f, 1.482f, 0f);
							this.Cops.SetActive(true);
							this.Speed = 0f;
						}
						else if (this.Phase == 16)
						{
							this.FadeOut = true;
							this.Darkness.color = new Color(0f, 0f, 0f, 0f);
						}
					}
					else if (this.Darkness.alpha == 1f)
					{
						SceneManager.LoadScene("CourtroomScene");
					}
				}
			}
			if (this.Phase < 2)
			{
				this.Speed += Time.deltaTime * 0.05f;
				this.MainCamera.transform.localPosition = Vector3.Lerp(this.MainCamera.transform.localPosition, new Vector3(0f, 1.482f, 0f), Time.deltaTime * this.Speed);
				this.Rotation = Mathf.Lerp(this.Rotation, -15f, Time.deltaTime * this.Speed);
				this.MainCamera.transform.localEulerAngles = new Vector3(this.Rotation, 0f, 0f);
			}
			else if (this.Phase == 2)
			{
				this.Speed += Time.deltaTime * 3f;
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * this.Speed);
				this.MainCamera.transform.localEulerAngles = new Vector3(this.Rotation, 0f, 0f);
			}
			else if (this.Phase > 2 && this.Phase < this.Text.Length)
			{
				this.Speed += Time.deltaTime;
				this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * this.Speed);
				this.MainCamera.transform.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
			}
			int phase = this.Phase;
			if (this.FadeOut)
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.33333f);
				this.SkipPanel.alpha = Mathf.MoveTowards(this.SkipPanel.alpha, 0f, Time.deltaTime * 0.33333f);
				this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0f, Time.deltaTime * 2f);
				return;
			}
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime * 0.33333f);
			if (!this.WarmUp)
			{
				this.SkipTimer += Time.deltaTime;
				if (this.SkipTimer > 2f)
				{
					this.SkipPanel.alpha = Mathf.MoveTowards(this.SkipPanel.alpha, 1f, Time.deltaTime * 0.33333f);
				}
			}
			if (this.SkipPanel.alpha == 1f)
			{
				if (Input.GetButton("X"))
				{
					this.SkipCircle.fillAmount -= Time.deltaTime;
					if (this.SkipCircle.fillAmount == 0f)
					{
						this.MyAudio.Stop();
						this.FadeOut = true;
						this.Phase = this.Text.Length;
						this.Darkness.color = new Color(0f, 0f, 0f, 0f);
						return;
					}
				}
				else
				{
					this.SkipCircle.fillAmount = 1f;
				}
			}
		}
	}

	// Token: 0x04001DC7 RID: 7623
	public UISprite SkipCircle;

	// Token: 0x04001DC8 RID: 7624
	public UIPanel SkipPanel;

	// Token: 0x04001DC9 RID: 7625
	public AudioSource Jukebox;

	// Token: 0x04001DCA RID: 7626
	public AudioSource MyAudio;

	// Token: 0x04001DCB RID: 7627
	public ClockScript Clock;

	// Token: 0x04001DCC RID: 7628
	public UISprite Darkness;

	// Token: 0x04001DCD RID: 7629
	public Camera MainCamera;

	// Token: 0x04001DCE RID: 7630
	public UILabel Subtitle;

	// Token: 0x04001DCF RID: 7631
	public GameObject Cops;

	// Token: 0x04001DD0 RID: 7632
	public AudioClip[] Clip;

	// Token: 0x04001DD1 RID: 7633
	public string[] Text;

	// Token: 0x04001DD2 RID: 7634
	public float SkipTimer;

	// Token: 0x04001DD3 RID: 7635
	public float Rotation;

	// Token: 0x04001DD4 RID: 7636
	public float Speed;

	// Token: 0x04001DD5 RID: 7637
	public float Timer;

	// Token: 0x04001DD6 RID: 7638
	public int Phase;

	// Token: 0x04001DD7 RID: 7639
	public int Disappearances;

	// Token: 0x04001DD8 RID: 7640
	public int Deaths;

	// Token: 0x04001DD9 RID: 7641
	public bool Debugging;

	// Token: 0x04001DDA RID: 7642
	public bool SkipLine6;

	// Token: 0x04001DDB RID: 7643
	public bool FadeOut;

	// Token: 0x04001DDC RID: 7644
	public bool WarmUp;

	// Token: 0x04001DDD RID: 7645
	public AudioClip DeadClip;

	// Token: 0x04001DDE RID: 7646
	public AudioClip AllDeadClip;

	// Token: 0x04001DDF RID: 7647
	public AudioClip MissingClip;

	// Token: 0x04001DE0 RID: 7648
	public AudioClip AllMissingClip;

	// Token: 0x04001DE1 RID: 7649
	public AudioClip SomeMissingClip;

	// Token: 0x04001DE2 RID: 7650
	public AudioClip DeadOrMissingClip;

	// Token: 0x04001DE3 RID: 7651
	public AudioClip AllDeadOrMissingClip;

	// Token: 0x04001DE4 RID: 7652
	public AudioClip SomeDeadOrMissingClip;

	// Token: 0x04001DE5 RID: 7653
	public AudioClip PacifistClip;
}
