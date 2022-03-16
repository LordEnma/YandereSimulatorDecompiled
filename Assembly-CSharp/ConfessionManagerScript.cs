using System;
using UnityEngine;

// Token: 0x02000256 RID: 598
public class ConfessionManagerScript : MonoBehaviour
{
	// Token: 0x060012A7 RID: 4775 RVA: 0x00097364 File Offset: 0x00095564
	private void Start()
	{
		this.StudentManager.Yandere.Class.Portal.EndEvents();
		this.StudentManager.Students[this.StudentManager.RivalID].BookBag.SetActive(false);
		this.Senpai["SenpaiConfession"].speed = 0.9f;
		this.TimelessDarkness.color = new Color(0f, 0f, 0f, 0f);
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.SubtitleLabel.text = "";
		this.Eighties = this.StudentManager.Eighties;
		if (this.Eighties)
		{
			this.ConfessionMusic[1] = this.ConfessionMusic[5];
			this.ConfessionMusic[2] = this.ConfessionMusic[5];
			this.ConfessionMusic[3] = this.ConfessionMusic[5];
			this.ConfessionMusic[4] = this.ConfessionMusic[5];
			this.Jukebox.clip = this.ConfessionMusic[5];
		}
		Time.timeScale = 1f;
	}

	// Token: 0x060012A8 RID: 4776 RVA: 0x00097498 File Offset: 0x00095698
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Phase == -1)
		{
			this.TimelessDarkness.color = new Color(this.TimelessDarkness.color.r, this.TimelessDarkness.color.g, this.TimelessDarkness.color.b, Mathf.MoveTowards(this.TimelessDarkness.color.a, 1f, Time.deltaTime));
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
			this.OriginalJukebox.Volume = Mathf.MoveTowards(this.OriginalJukebox.Volume, 0f, Time.deltaTime);
			if (this.TimelessDarkness.color.a == 1f && this.Timer > 2f)
			{
				this.TimelessDarkness.color = new Color(0f, 0f, 0f, 0f);
				this.Darkness.color = new Color(0f, 0f, 0f, 1f);
				this.ConfessionCamera.gameObject.SetActive(true);
				this.MainCamera.SetActive(false);
				this.OsanaCosmetic = this.StudentManager.Students[this.StudentManager.RivalID].Cosmetic;
				this.Osana = this.StudentManager.Students[this.StudentManager.RivalID].CharacterAnimation;
				this.Tears = this.StudentManager.Students[this.StudentManager.RivalID].Tears;
				this.Senpai = this.StudentManager.Students[1].CharacterAnimation;
				this.SenpaiNeck = this.StudentManager.Students[1].Neck;
				this.Osana[this.OsanaCosmetic.Student.ShyAnim].weight = 0f;
				this.Senpai["SenpaiConfession"].speed = 0.9f;
				this.OriginalBlossoms.SetActive(false);
				this.Tears.gameObject.SetActive(true);
				this.Osana.transform.position = new Vector3(0f, 6.6f, 119.5f);
				this.Senpai.transform.position = new Vector3(0f, 6.6f, 119.5f);
				this.Osana.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				this.Senpai.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				this.OsanaCosmetic.MyRenderer.materials[this.OsanaCosmetic.FaceID].SetFloat("_BlendAmount", 1f);
				this.OsanaCosmetic.MyRenderer.materials[this.OsanaCosmetic.SkinID].SetFloat("_BlendAmount", 0f);
				this.OsanaCosmetic.MyRenderer.materials[this.OsanaCosmetic.UniformID].SetFloat("_BlendAmount", 0f);
				Debug.Log("The characters were told to perform their confession animations.");
				this.Senpai.Play("SenpaiConfession");
				this.Osana.Play("OsanaConfession");
				this.OriginalBlossoms.SetActive(false);
				this.HeartBeatCamera.SetActive(false);
				if (!this.Eighties)
				{
					this.MyAudio.Play();
				}
				this.Jukebox.Play();
				this.Timer = 0f;
				this.Phase++;
				this.Yandere.transform.parent.position = new Vector3(5f, 5.73f, 119f);
				this.Yandere.transform.parent.eulerAngles = new Vector3(0f, -90f, 0f);
			}
		}
		else if (this.Phase == 0)
		{
			if (this.Eighties && this.Darkness.color.a == 0f)
			{
				this.ContinueButton.SetActive(true);
				if (Input.GetButtonDown("A"))
				{
					this.Timer = 11f;
				}
			}
			if (this.Timer > 11f)
			{
				if (!this.CheatRejection)
				{
					this.ContinueButton.SetActive(false);
					this.FadeOut = true;
					this.Timer = 0f;
					this.Phase++;
				}
				else if (this.Osana["OsanaConfessionRejected"].time < 45f)
				{
					this.Senpai.CrossFade("SenpaiConfessionRejected", 1f);
					this.Osana["OsanaConfessionRejected"].time = 45f;
					this.Osana.CrossFade("OsanaConfessionRejected", 1f);
				}
			}
			else
			{
				this.StudentManager.Students[this.StudentManager.RivalID].MyRenderer.enabled = true;
				this.StudentManager.Students[1].MyRenderer.enabled = true;
			}
		}
		else if (this.Phase == 1)
		{
			if (this.Timer > 2f)
			{
				this.ConfessionCamera.eulerAngles = this.SenpaiPOV.eulerAngles;
				this.ConfessionCamera.position = this.SenpaiPOV.position;
				this.Senpai.gameObject.SetActive(false);
				this.Osana["OsanaConfession"].time = 11f;
				this.MyAudio.volume = 1f;
				this.MyAudio.time = 8f;
				this.FadeOut = false;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.SubID < this.ConfessTimes.Length && this.Osana["OsanaConfession"].time > this.ConfessTimes[this.SubID] + 3f)
			{
				if (!this.Eighties)
				{
					this.SubtitleLabel.text = (this.ConfessSubs[this.SubID] ?? "");
				}
				else
				{
					this.SubtitleLabel.text = "(Your rival confesses her feelings to Senpai...)";
					if (this.SubID > 0)
					{
						this.ContinueButton.SetActive(true);
					}
				}
				this.SubID++;
			}
			this.RotateSpeed += Time.deltaTime * 0.2f;
			this.ConfessionCamera.eulerAngles = Vector3.Lerp(this.ConfessionCamera.eulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * this.RotateSpeed);
			this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(0f, 7.85f, 118f), Time.deltaTime * this.RotateSpeed);
			if (this.Eighties && this.ContinueButton.activeInHierarchy && Input.GetButtonDown("A"))
			{
				this.Osana["OsanaConfession"].time = this.Osana["OsanaConfession"].length;
				this.ContinueButton.SetActive(false);
			}
			if (this.Osana["OsanaConfession"].time >= this.Osana["OsanaConfession"].length)
			{
				this.ContinueButton.SetActive(false);
				if (this.StudentManager.SabotageProgress > 4)
				{
					this.Reject = true;
				}
				if (!this.Reject)
				{
					this.Osana.CrossFade("OsanaConfessionAccepted");
					this.MyAudio.clip = this.ConfessionAccepted;
				}
				else
				{
					this.Osana.CrossFade("OsanaConfessionRejected");
					this.MyAudio.clip = this.ConfessionRejected;
				}
				this.MyAudio.time = 0f;
				this.MyAudio.Play();
				this.Jukebox.Stop();
				if (this.Eighties)
				{
					this.MyAudio.volume = 0f;
				}
				this.SubtitleLabel.text = "";
				this.RotateSpeed = 0f;
				this.SubID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if (!this.Reject)
			{
				if (this.SubID < this.AcceptTimes.Length && this.Osana["OsanaConfessionAccepted"].time > this.AcceptTimes[this.SubID])
				{
					if (!this.Eighties)
					{
						this.SubtitleLabel.text = (this.AcceptSubs[this.SubID] ?? "");
					}
					else
					{
						this.SubtitleLabel.text = "Senpai accepts your rival's confession...";
						if (this.SubID > 0)
						{
							this.ContinueButton.SetActive(true);
						}
					}
					this.SubID++;
				}
				if (this.TearPhase == 0)
				{
					if (this.Timer > 26f)
					{
						this.ReverseTears = true;
						this.TearSpeed = 5f;
						this.TearPhase++;
					}
				}
				else if (this.TearPhase == 1)
				{
					if ((double)this.Timer > 33.33333)
					{
						this.ReverseTears = true;
						this.TearSpeed = 5f;
						this.TearPhase++;
					}
				}
				else if (this.TearPhase == 2)
				{
					if (this.Timer > 39f)
					{
						this.ReverseTears = true;
						this.TearSpeed = 5f;
						this.TearPhase++;
					}
				}
				else if (this.TearPhase == 3 && this.Timer > 40f)
				{
					this.TearPhase++;
				}
				if (this.Timer > 10f)
				{
					if (!this.Jukebox.isPlaying)
					{
						this.Jukebox.clip = this.ConfessionMusic[4];
						this.Jukebox.loop = true;
						this.Jukebox.volume = 0f;
						this.Jukebox.Play();
					}
					this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.05f, Time.deltaTime * 0.01f);
					if (!this.ReverseTears)
					{
						this.TearTimer = Mathf.MoveTowards(this.TearTimer, 1f, Time.deltaTime * this.TearSpeed);
					}
					else
					{
						this.TearTimer = Mathf.MoveTowards(this.TearTimer, 0f, Time.deltaTime * this.TearSpeed);
						if (this.TearTimer == 0f)
						{
							this.ReverseTears = false;
							this.TearSpeed = 0.2f;
						}
					}
					if (this.TearPhase < 4)
					{
						this.Tears.materials[0].SetFloat("_TearReveal", this.TearTimer);
					}
					this.Tears.materials[1].SetFloat("_TearReveal", this.TearTimer);
				}
				if (this.Eighties && this.ContinueButton.activeInHierarchy && Input.GetButtonDown("A"))
				{
					this.Timer = 43f;
				}
				if (this.Timer > 43f)
				{
					this.ContinueButton.SetActive(false);
					this.TearSpeed = 0.1f;
					this.FadeOut = true;
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else
			{
				if (this.SubID < this.RejectTimes.Length && this.Osana["OsanaConfessionRejected"].time > this.RejectTimes[this.SubID])
				{
					if (!this.Eighties)
					{
						this.SubtitleLabel.text = (this.RejectSubs[this.SubID] ?? "");
					}
					else
					{
						this.SubtitleLabel.text = "(Senpai rejects your rival's confession!)";
						if (this.SubID > 0)
						{
							this.ContinueButton.SetActive(true);
						}
					}
					this.SubID++;
				}
				if (this.Eighties && this.Timer < 41f)
				{
					this.Osana["OsanaConfessionRejected"].time = 41f;
					this.Timer = 41f;
				}
				if (this.Timer > 41f)
				{
					this.TearTimer = Mathf.MoveTowards(this.TearTimer, 1f, Time.deltaTime * this.TearSpeed);
					this.Tears.materials[0].SetFloat("_TearReveal", this.TearTimer);
					this.Tears.materials[1].SetFloat("_TearReveal", this.TearTimer);
				}
				if (this.Timer > 47f)
				{
					this.RotateSpeed += Time.deltaTime * 0.01f;
					this.ConfessionCamera.eulerAngles = new Vector3(this.ConfessionCamera.eulerAngles.x, this.ConfessionCamera.eulerAngles.y - this.RotateSpeed * 2f, this.ConfessionCamera.eulerAngles.z);
					this.ConfessionCamera.position = new Vector3(this.ConfessionCamera.position.x, this.ConfessionCamera.position.y, this.ConfessionCamera.position.z - this.RotateSpeed * 0.05f);
				}
				if (this.Eighties && this.ContinueButton.activeInHierarchy && Input.GetButtonDown("A"))
				{
					this.Timer = 51f;
				}
				if (this.Timer > 51f)
				{
					this.ContinueButton.SetActive(false);
					this.FadeOut = true;
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 4)
		{
			if (this.Reject)
			{
				this.RotateSpeed += Time.deltaTime * 0.01f;
				this.ConfessionCamera.eulerAngles = new Vector3(this.ConfessionCamera.eulerAngles.x, this.ConfessionCamera.eulerAngles.y - this.RotateSpeed * 2f, this.ConfessionCamera.eulerAngles.z);
				this.ConfessionCamera.position = new Vector3(this.ConfessionCamera.position.x, this.ConfessionCamera.position.y, this.ConfessionCamera.position.z - this.RotateSpeed * 0.05f);
			}
			if (this.Timer > 2f)
			{
				this.ConfessionCamera.eulerAngles = this.OriginalPOV.eulerAngles;
				this.ConfessionCamera.position = this.OriginalPOV.position;
				this.Senpai.gameObject.SetActive(true);
				if (!this.Reject)
				{
					this.Senpai.Play("SenpaiConfessionAccepted");
					this.Senpai["SenpaiConfessionAccepted"].time = this.Osana["OsanaConfessionAccepted"].time;
					this.Senpai.Play("SenpaiConfessionAccepted");
					this.Yandere.Play("YandereConfessionAccepted");
					this.StudentManager.Yandere.LoseGentleEyes();
				}
				else
				{
					this.Senpai.Play("SenpaiConfessionRejected");
					this.Senpai["SenpaiConfessionRejected"].time += 2f;
				}
				this.SubtitleLabel.text = "";
				this.FadeOut = false;
				this.RotateSpeed = 0f;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			if (this.Timer > 5f)
			{
				if (this.Reject)
				{
					this.Yandere.Play("YandereConfessionRejected");
				}
				this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0f, Time.deltaTime * 0.1f);
				this.RotateSpeed += Time.deltaTime * 0.5f;
				this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(7f, 7f, 118.5f), Time.deltaTime * this.RotateSpeed);
				if (this.Timer > 10f)
				{
					if (this.Reject)
					{
						AudioSource.PlayClipAtPoint(this.ConfessionGiggle, this.Yandere.transform.position);
					}
					this.ConfessionCamera.eulerAngles = this.ReactionPOV.eulerAngles;
					this.ConfessionCamera.position = this.ReactionPOV.position;
					this.RotateSpeed = 0f;
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 6)
		{
			this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0f, Time.deltaTime * 0.1f);
			if (!this.Reject)
			{
				if (!this.Heartbroken.Confessed)
				{
					this.MainCamera.transform.eulerAngles = this.ConfessionCamera.eulerAngles;
					this.MainCamera.transform.position = this.ConfessionCamera.position;
					this.Heartbroken.Confessed = true;
					this.MainCamera.SetActive(true);
					Camera.main.enabled = true;
					this.ShoulderCamera.enabled = true;
					this.ShoulderCamera.Noticed = true;
					this.ShoulderCamera.Skip = true;
				}
				this.ConfessionCamera.position = this.MainCamera.transform.position;
			}
			else
			{
				this.RotateSpeed += Time.deltaTime * 0.5f;
				this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(4f, 7f, 119f), Time.deltaTime * this.RotateSpeed);
				if (this.Timer > 5f)
				{
					this.FadeOut = true;
					if (this.Darkness.color.a == 1f)
					{
						this.StudentManager.RivalEliminated = true;
						this.StudentManager.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Rejected;
						this.MainCamera.SetActive(true);
						base.gameObject.SetActive(false);
						this.StudentManager.Clock.PresentTime = 1080f;
						this.StudentManager.Clock.StopTime = false;
						this.StudentManager.Yandere.HUD.alpha = 1f;
						this.StudentManager.Police.Darkness.color = new Color(0f, 0f, 0f, 1f);
						this.StudentManager.Police.gameObject.SetActive(true);
						this.StudentManager.Police.BeginConfession = false;
						this.StudentManager.Police.enabled = true;
					}
				}
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 0.5f));
			return;
		}
		this.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime * 0.5f));
	}

	// Token: 0x060012A9 RID: 4777 RVA: 0x00098920 File Offset: 0x00096B20
	private void LateUpdate()
	{
		if (this.Phase > 4 && this.Reject)
		{
			this.SenpaiNeck.eulerAngles = new Vector3(this.SenpaiNeck.eulerAngles.x + 15f, this.SenpaiNeck.eulerAngles.y, this.SenpaiNeck.eulerAngles.z);
		}
	}

	// Token: 0x04001880 RID: 6272
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x04001881 RID: 6273
	public StudentManagerScript StudentManager;

	// Token: 0x04001882 RID: 6274
	public HeartbrokenScript Heartbroken;

	// Token: 0x04001883 RID: 6275
	public JukeboxScript OriginalJukebox;

	// Token: 0x04001884 RID: 6276
	public CosmeticScript OsanaCosmetic;

	// Token: 0x04001885 RID: 6277
	public AudioClip ConfessionAccepted;

	// Token: 0x04001886 RID: 6278
	public AudioClip ConfessionRejected;

	// Token: 0x04001887 RID: 6279
	public AudioClip ConfessionGiggle;

	// Token: 0x04001888 RID: 6280
	public AudioClip[] ConfessionMusic;

	// Token: 0x04001889 RID: 6281
	public GameObject OriginalBlossoms;

	// Token: 0x0400188A RID: 6282
	public GameObject HeartBeatCamera;

	// Token: 0x0400188B RID: 6283
	public GameObject ContinueButton;

	// Token: 0x0400188C RID: 6284
	public GameObject MainCamera;

	// Token: 0x0400188D RID: 6285
	public Transform ConfessionCamera;

	// Token: 0x0400188E RID: 6286
	public Transform OriginalPOV;

	// Token: 0x0400188F RID: 6287
	public Transform ReactionPOV;

	// Token: 0x04001890 RID: 6288
	public Transform SenpaiNeck;

	// Token: 0x04001891 RID: 6289
	public Transform SenpaiPOV;

	// Token: 0x04001892 RID: 6290
	public string[] ConfessSubs;

	// Token: 0x04001893 RID: 6291
	public string[] AcceptSubs;

	// Token: 0x04001894 RID: 6292
	public string[] RejectSubs;

	// Token: 0x04001895 RID: 6293
	public float[] ConfessTimes;

	// Token: 0x04001896 RID: 6294
	public float[] AcceptTimes;

	// Token: 0x04001897 RID: 6295
	public float[] RejectTimes;

	// Token: 0x04001898 RID: 6296
	public UISprite TimelessDarkness;

	// Token: 0x04001899 RID: 6297
	public UILabel SubtitleLabel;

	// Token: 0x0400189A RID: 6298
	public UISprite Darkness;

	// Token: 0x0400189B RID: 6299
	public UIPanel Panel;

	// Token: 0x0400189C RID: 6300
	public AudioSource MyAudio;

	// Token: 0x0400189D RID: 6301
	public AudioSource Jukebox;

	// Token: 0x0400189E RID: 6302
	public Animation Yandere;

	// Token: 0x0400189F RID: 6303
	public Animation Senpai;

	// Token: 0x040018A0 RID: 6304
	public Animation Osana;

	// Token: 0x040018A1 RID: 6305
	public Renderer Tears;

	// Token: 0x040018A2 RID: 6306
	public float RotateSpeed;

	// Token: 0x040018A3 RID: 6307
	public float TearSpeed;

	// Token: 0x040018A4 RID: 6308
	public float TearTimer;

	// Token: 0x040018A5 RID: 6309
	public float Timer;

	// Token: 0x040018A6 RID: 6310
	public bool CheatRejection;

	// Token: 0x040018A7 RID: 6311
	public bool ReverseTears;

	// Token: 0x040018A8 RID: 6312
	public bool Eighties;

	// Token: 0x040018A9 RID: 6313
	public bool FadeOut;

	// Token: 0x040018AA RID: 6314
	public bool Reject;

	// Token: 0x040018AB RID: 6315
	public int TearPhase;

	// Token: 0x040018AC RID: 6316
	public int Phase;

	// Token: 0x040018AD RID: 6317
	public int MusicID;

	// Token: 0x040018AE RID: 6318
	public int SubID;
}
