using System;
using UnityEngine;

// Token: 0x02000257 RID: 599
public class ConfessionSceneScript : MonoBehaviour
{
	// Token: 0x060012AC RID: 4780 RVA: 0x00098A4C File Offset: 0x00096C4C
	private void Start()
	{
		Time.timeScale = 1f;
		if (this.StudentManager.Eighties)
		{
			this.MyAudio.clip = this.EightiesConfessionMusic;
		}
	}

	// Token: 0x060012AD RID: 4781 RVA: 0x00098A78 File Offset: 0x00096C78
	private void Update()
	{
		if (this.Phase == 1)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
			this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
			if (this.Darkness.color.a == 1f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Yandere.CameraEffects.UpdateBloom(1f);
					this.Yandere.CameraEffects.UpdateThreshold(1f);
					this.Yandere.CameraEffects.UpdateBloomKnee(1f);
					this.Yandere.CameraEffects.UpdateBloomRadius(7f);
					this.Suitor = this.StudentManager.Students[this.LoveManager.SuitorID];
					this.Rival = this.StudentManager.Students[this.LoveManager.RivalID];
					this.Rival.transform.position = this.RivalSpot.position;
					this.Rival.transform.eulerAngles = this.RivalSpot.eulerAngles;
					this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
					this.Suitor.transform.eulerAngles = this.StudentManager.SuitorConfessionSpot.eulerAngles;
					this.Suitor.transform.position = this.StudentManager.SuitorConfessionSpot.position;
					this.Suitor.CharacterAnimation.Play(this.Suitor.IdleAnim);
					this.Suitor.EmptyHands();
					this.MythBlossoms.emission.rateOverTime = 100f;
					this.HeartBeatCamera.SetActive(false);
					base.GetComponent<AudioSource>().Play();
					this.MainCamera.position = this.CameraDestinations[1].position;
					this.MainCamera.eulerAngles = this.CameraDestinations[1].eulerAngles;
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Darkness.color.a == 0f)
			{
				if (!this.ShowLabel)
				{
					this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, 0f, Time.deltaTime));
					if (this.Label.color.a == 0f)
					{
						if (this.TextPhase < 5)
						{
							this.MainCamera.position = this.CameraDestinations[this.TextPhase].position;
							this.MainCamera.eulerAngles = this.CameraDestinations[this.TextPhase].eulerAngles;
							if (this.TextPhase == 4 && !this.Kissing)
							{
								ParticleSystem.EmissionModule emission = this.Suitor.Hearts.emission;
								emission.enabled = true;
								emission.rateOverTime = 10f;
								this.Suitor.Hearts.Play();
								ParticleSystem.EmissionModule emission2 = this.Rival.Hearts.emission;
								emission2.enabled = true;
								emission2.rateOverTime = 10f;
								this.Rival.Hearts.Play();
								this.Suitor.Character.transform.localScale = new Vector3(1f, 1f, 1f);
								this.Suitor.CharacterAnimation.Play("kiss_00");
								this.Suitor.transform.position = this.KissSpot.position;
								this.Rival.CharacterAnimation[this.Rival.ShyAnim].weight = 0f;
								this.Rival.CharacterAnimation.Play("f02_kiss_00");
								this.Kissing = true;
							}
							this.Label.text = this.Text[this.TextPhase];
							this.ShowLabel = true;
						}
						else
						{
							this.Jingle.Play();
							this.Phase++;
						}
					}
				}
				else
				{
					this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, 1f, Time.deltaTime));
					if (this.Label.color.a == 1f)
					{
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Continue";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (Input.GetButtonDown("A"))
						{
							this.TextPhase++;
							this.ShowLabel = false;
						}
					}
				}
			}
		}
		else if (this.Phase == 3)
		{
			this.LetterTimer += Time.deltaTime;
			if (this.LetterTimer > 0.1f && this.LetterID < this.Letters.Length)
			{
				this.Letters[this.LetterID].SetActive(true);
				this.LetterTimer = 0f;
				this.LetterID++;
			}
			if (this.LetterTimer > 5f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 4)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					DatingGlobals.SuitorProgress = 2;
					this.StudentManager.RivalEliminated = true;
					this.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Matchmade;
					this.Suitor.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
					this.PromptBar.ClearButtons();
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = false;
					this.ConfessionBG.SetActive(false);
					this.Yandere.FixCamera();
					this.Phase++;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 1f, Time.deltaTime);
			if (this.Darkness.color.a == 0f)
			{
				this.StudentManager.ComeBack();
				this.Suitor.enabled = false;
				this.Suitor.Prompt.enabled = false;
				this.Suitor.Pathfinding.canMove = false;
				this.Suitor.Pathfinding.canSearch = false;
				this.Rival.enabled = false;
				this.Rival.Prompt.enabled = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Pathfinding.canSearch = false;
				this.Yandere.RPGCamera.enabled = true;
				this.Yandere.CanMove = true;
				this.HeartBeatCamera.SetActive(true);
				this.MythBlossoms.emission.rateOverTime = 20f;
				this.Clock.Police.gameObject.SetActive(true);
				this.Clock.StopTime = false;
				base.enabled = false;
				this.Suitor.CoupleID = this.LoveManager.SuitorID;
				this.Rival.CoupleID = this.LoveManager.RivalID;
				this.Suitor.CharacterAnimation.CrossFade("holdHandsLoop_00");
				this.Rival.CharacterAnimation.CrossFade("f02_holdHandsLoop_00");
			}
		}
		if (this.Kissing)
		{
			if (this.Suitor.CharacterAnimation["kiss_00"].time >= this.Suitor.CharacterAnimation["kiss_00"].length * 0.66666f)
			{
				this.Suitor.Character.transform.localScale = Vector3.Lerp(this.Suitor.Character.transform.localScale, new Vector3(0.94f, 0.94f, 0.94f), Time.deltaTime);
			}
			if (this.Suitor.CharacterAnimation["kiss_00"].time >= this.Suitor.CharacterAnimation["kiss_00"].length)
			{
				this.Rival.CharacterAnimation.CrossFade("f02_introHoldHands_00");
				this.Suitor.CharacterAnimation.CrossFade("introHoldHands_00");
				this.Kissing = false;
				this.MoveSuitor = true;
				return;
			}
		}
		else if (this.Suitor != null)
		{
			this.Suitor.gameObject.SetActive(true);
			this.Suitor.Character.transform.localScale = Vector3.Lerp(this.Suitor.Character.transform.localScale, new Vector3(0.94f, 0.94f, 0.94f), Time.deltaTime);
			if (this.MoveSuitor)
			{
				this.Speed += Time.deltaTime;
				this.Suitor.Character.transform.position = Vector3.Lerp(this.Suitor.Character.transform.position, new Vector3(0f, 6.6f, 119.2f), Time.deltaTime * this.Speed);
			}
		}
	}

	// Token: 0x040018B0 RID: 6320
	public Transform[] CameraDestinations;

	// Token: 0x040018B1 RID: 6321
	public StudentManagerScript StudentManager;

	// Token: 0x040018B2 RID: 6322
	public LoveManagerScript LoveManager;

	// Token: 0x040018B3 RID: 6323
	public PromptBarScript PromptBar;

	// Token: 0x040018B4 RID: 6324
	public JukeboxScript Jukebox;

	// Token: 0x040018B5 RID: 6325
	public YandereScript Yandere;

	// Token: 0x040018B6 RID: 6326
	public ClockScript Clock;

	// Token: 0x040018B7 RID: 6327
	public Bloom BloomEffect;

	// Token: 0x040018B8 RID: 6328
	public StudentScript Suitor;

	// Token: 0x040018B9 RID: 6329
	public StudentScript Rival;

	// Token: 0x040018BA RID: 6330
	public ParticleSystem MythBlossoms;

	// Token: 0x040018BB RID: 6331
	public GameObject HeartBeatCamera;

	// Token: 0x040018BC RID: 6332
	public GameObject ConfessionBG;

	// Token: 0x040018BD RID: 6333
	public Transform MainCamera;

	// Token: 0x040018BE RID: 6334
	public Transform RivalSpot;

	// Token: 0x040018BF RID: 6335
	public Transform KissSpot;

	// Token: 0x040018C0 RID: 6336
	public string[] Text;

	// Token: 0x040018C1 RID: 6337
	public GameObject[] Letters;

	// Token: 0x040018C2 RID: 6338
	public UISprite Darkness;

	// Token: 0x040018C3 RID: 6339
	public UILabel Label;

	// Token: 0x040018C4 RID: 6340
	public UIPanel Panel;

	// Token: 0x040018C5 RID: 6341
	public AudioSource MyAudio;

	// Token: 0x040018C6 RID: 6342
	public AudioSource Jingle;

	// Token: 0x040018C7 RID: 6343
	public AudioClip EightiesConfessionMusic;

	// Token: 0x040018C8 RID: 6344
	public bool MoveSuitor;

	// Token: 0x040018C9 RID: 6345
	public bool ShowLabel;

	// Token: 0x040018CA RID: 6346
	public bool Kissing;

	// Token: 0x040018CB RID: 6347
	public int TextPhase = 1;

	// Token: 0x040018CC RID: 6348
	public int LetterID = 1;

	// Token: 0x040018CD RID: 6349
	public int Phase = 1;

	// Token: 0x040018CE RID: 6350
	public float LetterTimer = 0.1f;

	// Token: 0x040018CF RID: 6351
	public float Speed;

	// Token: 0x040018D0 RID: 6352
	public float Timer;
}
