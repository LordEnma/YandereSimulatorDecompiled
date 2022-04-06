using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000263 RID: 611
public class CourtroomScript : MonoBehaviour
{
	// Token: 0x060012F1 RID: 4849 RVA: 0x000A678C File Offset: 0x000A498C
	private void Start()
	{
		this.Subtitle.text = "";
		this.Polaroid.alpha = 0f;
		this.Darkness.alpha = 1f;
		this.RankPanel.alpha = 0f;
		GameGlobals.TrueEnding = false;
		this.Scale.localPosition = new Vector3(0f, 0.645f, 1f);
		base.transform.position = new Vector3(0f, 5f, 15f);
		base.transform.eulerAngles = new Vector3(15f, 180f, 0f);
		this.Jukebox.volume = 0f;
		this.ResetBloom();
		this.VtuberCheck();
	}

	// Token: 0x060012F2 RID: 4850 RVA: 0x000A6858 File Offset: 0x000A4A58
	public void UpdateFactLabels()
	{
		this.Fact[1] = this.RivalNames[1] + " " + this.Eliminations[this.Stats.EliminationIDs[1]];
		this.GuiltyPoints[1] = this.EliminationSuspicion[this.Stats.EliminationIDs[1]];
		this.Fact[2] = this.Details[this.Stats.DetailIDs[1]];
		this.GuiltyPoints[2] = this.DetailSuspicion[this.Stats.DetailIDs[1]];
		this.Fact[3] = this.RivalNames[2] + " " + this.Eliminations[this.Stats.EliminationIDs[2]];
		this.GuiltyPoints[3] = this.EliminationSuspicion[this.Stats.EliminationIDs[2]];
		this.Fact[4] = this.Details[this.Stats.DetailIDs[2]];
		this.GuiltyPoints[4] = this.DetailSuspicion[this.Stats.DetailIDs[2]];
		this.Fact[5] = this.RivalNames[3] + " " + this.Eliminations[this.Stats.EliminationIDs[3]];
		this.GuiltyPoints[5] = this.EliminationSuspicion[this.Stats.EliminationIDs[3]];
		this.Fact[6] = this.Details[this.Stats.DetailIDs[3]];
		this.GuiltyPoints[6] = this.DetailSuspicion[this.Stats.DetailIDs[3]];
		this.Fact[7] = this.RivalNames[4] + " " + this.Eliminations[this.Stats.EliminationIDs[4]];
		this.GuiltyPoints[7] = this.EliminationSuspicion[this.Stats.EliminationIDs[4]];
		this.Fact[8] = this.Details[this.Stats.DetailIDs[4]];
		this.GuiltyPoints[8] = this.DetailSuspicion[this.Stats.DetailIDs[4]];
		this.Fact[9] = this.RivalNames[5] + " " + this.Eliminations[this.Stats.EliminationIDs[5]];
		this.GuiltyPoints[9] = this.EliminationSuspicion[this.Stats.EliminationIDs[5]];
		this.Fact[10] = this.Details[this.Stats.DetailIDs[5]];
		this.GuiltyPoints[10] = this.DetailSuspicion[this.Stats.DetailIDs[5]];
		this.Fact[11] = this.RivalNames[6] + " " + this.Eliminations[this.Stats.EliminationIDs[6]];
		this.GuiltyPoints[11] = this.EliminationSuspicion[this.Stats.EliminationIDs[6]];
		this.Fact[12] = this.Details[this.Stats.DetailIDs[6]];
		this.GuiltyPoints[12] = this.DetailSuspicion[this.Stats.DetailIDs[6]];
		this.Fact[13] = this.RivalNames[7] + " " + this.Eliminations[this.Stats.EliminationIDs[7]];
		this.GuiltyPoints[13] = this.EliminationSuspicion[this.Stats.EliminationIDs[7]];
		this.Fact[14] = this.Details[this.Stats.DetailIDs[7]];
		this.GuiltyPoints[14] = this.DetailSuspicion[this.Stats.DetailIDs[7]];
		this.Fact[15] = this.RivalNames[8] + " " + this.Eliminations[this.Stats.EliminationIDs[8]];
		this.GuiltyPoints[15] = this.EliminationSuspicion[this.Stats.EliminationIDs[8]];
		this.Fact[16] = this.Details[this.Stats.DetailIDs[8]];
		this.GuiltyPoints[16] = this.DetailSuspicion[this.Stats.DetailIDs[8]];
		this.Fact[17] = this.RivalNames[9] + " " + this.Eliminations[this.Stats.EliminationIDs[9]];
		this.GuiltyPoints[17] = this.EliminationSuspicion[this.Stats.EliminationIDs[9]];
		this.Fact[18] = this.Details[this.Stats.DetailIDs[9]];
		this.GuiltyPoints[18] = this.DetailSuspicion[this.Stats.DetailIDs[9]];
		this.Fact[19] = this.RivalNames[10] + " " + this.Eliminations[this.Stats.EliminationIDs[10]];
		this.GuiltyPoints[19] = this.EliminationSuspicion[this.Stats.EliminationIDs[10]];
		this.Fact[20] = this.Details[this.Stats.DetailIDs[10]];
		this.GuiltyPoints[20] = this.DetailSuspicion[this.Stats.DetailIDs[10]];
		this.Fact[21] = "After Sumire's disappearance, the police were called to Akademi a total of " + PlayerGlobals.PoliceVisits.ToString() + " times.";
		this.GuiltyPoints[21] = PlayerGlobals.PoliceVisits;
		this.Fact[22] = "The police discovered a total of " + PlayerGlobals.CorpsesDiscovered.ToString() + " corpses at Akademi.";
		this.GuiltyPoints[22] = PlayerGlobals.CorpsesDiscovered;
		this.Fact[23] = "Ryoba made " + PlayerGlobals.Friends.ToString() + " friends at Akademi.";
		this.GuiltyPoints[23] = PlayerGlobals.Friends * -1;
		this.Fact[24] = "Ryoba's reputation at school is " + Mathf.RoundToInt(PlayerGlobals.Reputation).ToString() + ".";
		this.GuiltyPoints[24] = Mathf.RoundToInt(PlayerGlobals.Reputation) * -1;
		this.Fact[25] = "Ryoba's classmates witnessed her doing something suspicious " + PlayerGlobals.Alerts.ToString() + " times.";
		this.GuiltyPoints[25] = PlayerGlobals.Alerts;
		this.Fact[26] = "Ryoba's classmates witnessed her carrying a dangerous weapon around school " + PlayerGlobals.WeaponWitnessed.ToString() + " times.";
		this.GuiltyPoints[26] = PlayerGlobals.WeaponWitnessed;
		this.Fact[27] = "Ryoba's classmates witnessed her walking around in blood-stained clothing " + PlayerGlobals.BloodWitnessed.ToString() + " times.";
		this.GuiltyPoints[27] = PlayerGlobals.BloodWitnessed;
		if (this.Stats.Grudges == 0)
		{
			this.Fact[28] = this.Stats.Grudges.ToString() + " students testified that they witnessed Ryoba commit murder.";
		}
		else if (this.Stats.Grudges == 1)
		{
			this.Fact[28] = this.Stats.Grudges.ToString() + " student testified that they witnessed Ryoba commit murder, but had no evidence.";
		}
		else
		{
			this.Fact[28] = this.Stats.Grudges.ToString() + " students testified that they witnessed Ryoba commit murder, but had no evidence.";
		}
		this.GuiltyPoints[28] = this.Stats.Grudges * 20;
	}

	// Token: 0x060012F3 RID: 4851 RVA: 0x000A6FB0 File Offset: 0x000A51B0
	private void Update()
	{
		if (this.Phase == 0)
		{
			this.Timer += Time.deltaTime;
			this.Speed += Time.deltaTime * 0.2f;
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime * 0.2f);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 2f, 2f), Time.deltaTime * this.Speed);
			if (Input.GetButtonDown("A"))
			{
				this.Timer = 11f;
			}
			else if (Input.GetButtonDown("X"))
			{
				this.Timer = 0f;
				this.Phase = 66;
				this.Darkness.alpha = 0f;
				base.transform.position = this.CameraPosition[65].position;
				base.transform.eulerAngles = this.CameraPosition[65].eulerAngles;
			}
			if (this.Timer > 10f)
			{
				this.Phase++;
				this.Timer = 0f;
				this.Darkness.alpha = 0f;
				this.Subtitle.text = this.OpeningStatement[this.Phase];
				this.MyAudio.clip = this.Voice[this.Phase];
				this.MyAudio.Play();
				base.transform.position = this.CameraPosition[this.Phase].position;
				base.transform.eulerAngles = this.CameraPosition[this.Phase].eulerAngles;
			}
		}
		else if (this.Phase < 66)
		{
			if (Input.GetButtonDown("A"))
			{
				this.Phase++;
				if (this.Phase < 66)
				{
					this.Subtitle.text = this.OpeningStatement[this.Phase];
					this.MyAudio.clip = this.Voice[this.Phase];
					this.MyAudio.Play();
					base.transform.position = this.CameraPosition[this.Phase].position;
					base.transform.eulerAngles = this.CameraPosition[this.Phase].eulerAngles;
				}
				else
				{
					this.Subtitle.text = "";
				}
			}
			else if (Input.GetButtonDown("X"))
			{
				this.Phase = 66;
				this.Subtitle.text = "";
				base.transform.position = this.CameraPosition[65].position;
				base.transform.eulerAngles = this.CameraPosition[65].eulerAngles;
			}
		}
		else if (this.Phase == 66)
		{
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.5f, Time.deltaTime * 0.5f);
			this.Scale.localPosition = Vector3.Lerp(this.Scale.localPosition, new Vector3(0f, -0.2f, 1f), Time.deltaTime * 10f);
			if (this.Darkness.alpha == 0.5f)
			{
				this.Scale.localPosition = new Vector3(0f, -0.2f, 1f);
				if (this.Fact[this.FactID] == "")
				{
					this.Fact[this.FactID] = "Huh? The game could not identify how this character was eliminated. Tell YandereDev about this, and let him know exactly how you eliminated her.";
				}
				this.FactLabel.text = this.Fact[this.FactID];
				this.Guilt += this.GuiltyPoints[this.FactID];
				this.SkipButton.SetActive(false);
				this.Phase++;
			}
		}
		else if (this.Phase == 67)
		{
			if (Input.GetButtonDown("A"))
			{
				if (this.FactID < this.Fact.Length - 1)
				{
					this.FactID++;
					if (this.Fact[this.FactID] == "")
					{
						this.Fact[this.FactID] = "Huh? The game could not identify how this character was eliminated. Tell YandereDev about this, and let him know exactly how you eliminated her.";
					}
					this.FactLabel.text = this.Fact[this.FactID];
					if (this.GuiltyPoints[this.FactID] > 0)
					{
						this.Guilt += this.GuiltyPoints[this.FactID];
					}
					else
					{
						this.Innocence -= this.GuiltyPoints[this.FactID];
					}
				}
				else
				{
					this.FactLabel.text = "";
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 68)
		{
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime * 0.5f);
			this.Scale.localPosition = Vector3.Lerp(this.Scale.localPosition, new Vector3(0f, 0.645f, 1f), Time.deltaTime * 10f);
			if (this.Darkness.alpha == 0f)
			{
				this.Scale.localPosition = new Vector3(0f, 0.645f, 1f);
				this.Subtitle.text = "Taking all of the facts into consideration, it is clear beyond any shadow of a doubt...";
				this.MyAudio.clip = this.Voice[66];
				this.MyAudio.Play();
				this.Phase++;
			}
		}
		else if (this.Phase == 69)
		{
			if (Input.GetButtonDown("A"))
			{
				if (this.Guilt - this.Innocence > 0)
				{
					if (this.Stats.Deaths == 10)
					{
						this.Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven deaths over the past eleven weeks.";
						this.MyAudio.clip = this.Deaths;
					}
					else if (this.Stats.Disappearances == 10)
					{
						this.Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven disappearances over the past eleven weeks.";
						this.MyAudio.clip = this.Disappearances;
					}
					else if (this.Stats.Deaths + this.Stats.Disappearances == 10)
					{
						this.Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven deaths and disappearances over the past eleven weeks.";
						this.MyAudio.clip = this.DeathsAndDisappearances;
					}
					else if (this.Stats.Deaths > 0)
					{
						this.Subtitle.text = "...that Ryoba Aishi is responsible for at least one death over the past eleven weeks.";
						this.MyAudio.clip = this.SomeDeaths;
					}
					else if (this.Stats.Disappearances > 0)
					{
						this.Subtitle.text = "...that Ryoba Aishi is responsible for at least one disappearance over the past eleven weeks.";
						this.MyAudio.clip = this.SomeDisappearances;
					}
					else if (this.Stats.Deaths + this.Stats.Disappearances == 0)
					{
						this.Subtitle.text = "...that Ryoba Aishi is responsible for Sumire Saitozaki's death.";
						this.MyAudio.clip = this.GuiltyClip;
					}
				}
				else
				{
					this.Subtitle.text = "...that Ryoba Aishi is innocent of all charges.";
					this.MyAudio.clip = this.InnocentClip;
					this.Innocent = true;
				}
				this.MyAudio.Play();
				this.Phase++;
			}
		}
		else if (this.Phase == 70)
		{
			if (Input.GetButtonDown("A"))
			{
				this.Speed = 0f;
				this.Subtitle.text = "";
				base.transform.position = this.CameraPosition[15].position;
				base.transform.eulerAngles = this.CameraPosition[15].eulerAngles;
				if (this.Innocent)
				{
					this.Yandere["YandereConfessionRejected"].time = 4.5f;
					this.Yandere.CrossFade("YandereConfessionRejected");
				}
				else
				{
					this.Yandere.transform.position = new Vector3(0f, 0f, 0.15f);
					this.Yandere.CrossFade("YandereConfessionAccepted");
				}
				this.PopulateRankPanel();
				AudioSource.PlayClipAtPoint(this.ScoreJingles[this.Rank], base.transform.position);
				this.Phase++;
			}
		}
		else if (this.Phase == 71)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 2.5f)
			{
				if (this.Innocent)
				{
					this.Yandere.CrossFade("YandereConfessionRejectedLoop");
				}
				else
				{
					this.Yandere.CrossFade("f02_down_22");
				}
				if (this.Timer > 3f)
				{
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 72)
		{
			this.RankPanel.alpha = Mathf.MoveTowards(this.RankPanel.alpha, 1f, Time.deltaTime);
			if (this.RankPanel.alpha == 1f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 73)
		{
			this.RankIcon.transform.localScale = Vector3.Lerp(this.RankIcon.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.RankIcon.transform.localScale.x > 0.999f)
			{
				this.RankDesc.alpha = Mathf.MoveTowards(this.RankDesc.alpha, 1f, Time.deltaTime);
				if (this.RankDesc.alpha == 1f && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 74)
		{
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
			if (this.Darkness.alpha == 1f)
			{
				if (this.Innocent)
				{
					GameGlobals.EightiesCutsceneID = 12;
					SceneManager.LoadScene("EightiesCutsceneScene");
				}
				else
				{
					SceneManager.LoadScene("CreditsScene");
				}
			}
		}
		if (this.Phase < 68)
		{
			this.MusicTimer += Time.deltaTime;
			if (this.MusicTimer > 1f)
			{
				this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.033333f, Time.deltaTime * 0.01f);
			}
		}
		else
		{
			this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0f, Time.deltaTime * 0.1f);
		}
		if (this.Phase > 70)
		{
			this.Speed += Time.deltaTime;
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.6666667f, 1.33333f, -1f), Time.deltaTime * this.Speed);
		}
		if (this.Phase == 27 || this.Phase == 47 || this.Phase == 63)
		{
			if (this.Walla.volume == 0f)
			{
				for (int i = 1; i < this.SpeechLines.Length; i++)
				{
					this.SpeechLines[i].Play();
				}
			}
			this.Walla.volume = Mathf.MoveTowards(this.Walla.volume, 0.5f, Time.deltaTime * 0.2f);
		}
		else
		{
			if (this.SpeechLines[1].isPlaying)
			{
				for (int j = 1; j < this.SpeechLines.Length; j++)
				{
					this.SpeechLines[j].Stop();
				}
			}
			this.Walla.volume = Mathf.MoveTowards(this.Walla.volume, 0f, Time.deltaTime * 0.2f);
		}
		if (this.Phase == 9 || this.Phase == 10)
		{
			this.Polaroid.transform.localPosition = Vector3.Lerp(this.Polaroid.transform.localPosition, new Vector3(700f, 200f, 0f), Time.deltaTime);
			this.Polaroid.alpha = Mathf.MoveTowards(this.Polaroid.alpha, 1f, Time.deltaTime);
		}
		else
		{
			this.Polaroid.transform.localPosition = Vector3.Lerp(this.Polaroid.transform.localPosition, new Vector3(700f, 0f, 0f), Time.deltaTime);
			this.Polaroid.alpha = Mathf.MoveTowards(this.Polaroid.alpha, 0f, Time.deltaTime);
		}
		this.TargetRotation = (float)(this.Guilt - this.Innocence) * 0.25f;
		if (this.TargetRotation > 25f)
		{
			this.TargetRotation = 25f;
		}
		if (this.TargetRotation < -25f)
		{
			this.TargetRotation = -25f;
		}
		this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime);
		this.BalanceBar.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
		this.RightScale.eulerAngles = new Vector3(0f, 0f, 0f);
		this.LeftScale.eulerAngles = new Vector3(0f, 0f, 0f);
		if (base.transform.position == this.CameraPosition[1].position || base.transform.position == this.CameraPosition[15].position || base.transform.position == this.CameraPosition[65].position || this.Phase > 70)
		{
			this.UpdateDOF(1f);
			return;
		}
		this.UpdateDOF(3f);
	}

	// Token: 0x060012F4 RID: 4852 RVA: 0x000A7E38 File Offset: 0x000A6038
	public void PopulateRankPanel()
	{
		this.RankIcon.transform.localScale = new Vector3(0f, 0f, 0f);
		this.Score = (this.Guilt - this.Innocence) * -1;
		if (!this.Innocent)
		{
			this.Rank = 0;
			this.RankDesc.text = "You successfully eliminated your rivals, but aroused so much suspicion that you were eventually judged to be guilty of murder.";
		}
		else if (this.Score >= 100)
		{
			this.Rank = 5;
			this.RankDesc.text = "Everyone loves you, and nobody has any reason to suspect that you might be a killer! You are a true yandere!";
			if (this.Stats.EliminationIDs[1] == 18 && this.Stats.EliminationIDs[2] == 5 && this.Stats.EliminationIDs[3] == 6 && this.Stats.EliminationIDs[4] == 15 && this.Stats.EliminationIDs[5] == 7 && this.Stats.EliminationIDs[6] == 8 && this.Stats.EliminationIDs[7] == 9 && this.Stats.EliminationIDs[8] == 4 && this.Stats.EliminationIDs[9] == 13 && this.Stats.EliminationIDs[10] == 2)
			{
				Debug.Log("True ending unlocked!");
				this.Rank = 6;
				GameGlobals.TrueEnding = true;
			}
		}
		else if (this.Score >= 75)
		{
			this.Rank = 4;
			this.RankDesc.text = "Nearly everyone is convinced that you are innocent, but there are still a few people who doubt you.";
		}
		else if (this.Score >= 50)
		{
			this.Rank = 3;
			this.RankDesc.text = "Public opinion is split 50/50 on whether or not you are a killer. Many people will prefer to avoid you.";
		}
		else if (this.Score >= 25)
		{
			this.Rank = 2;
			this.RankDesc.text = "You avoided a guilty verdict, but you've still taken a massive hit to your reputation.";
		}
		else if (this.Score >= 0)
		{
			this.Rank = 1;
			this.RankDesc.text = "You barely managed to avoid a guilty verdict. You will be regarded with suspicion for the rest of your life.";
		}
		this.RankIcon.mainTexture = this.RankIcons[this.Rank];
	}

	// Token: 0x060012F5 RID: 4853 RVA: 0x000A8048 File Offset: 0x000A6248
	private void UpdateDOF(float Value)
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Value;
		settings.aperture = 5.6f;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x060012F6 RID: 4854 RVA: 0x000A808C File Offset: 0x000A628C
	private void ResetBloom()
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.intensity = 1f;
		settings.bloom.threshold = 1.1f;
		settings.bloom.softKnee = 0.75f;
		settings.bloom.radius = 4f;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x060012F7 RID: 4855 RVA: 0x000A8100 File Offset: 0x000A6300
	public void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			this.OriginalHair.SetActive(false);
			this.VtuberHairs[GameGlobals.VtuberID].SetActive(true);
			this.MyRenderer.materials[2].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
			for (int i = 0; i < 13; i++)
			{
				this.MyRenderer.SetBlendShapeWeight(i, 0f);
			}
			this.MyRenderer.SetBlendShapeWeight(0, 100f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.Vtuber = true;
			return;
		}
		this.VtuberHairs[1].SetActive(false);
	}

	// Token: 0x04001ACF RID: 6863
	public PostProcessingProfile Profile;

	// Token: 0x04001AD0 RID: 6864
	public EightiesStatsScript Stats;

	// Token: 0x04001AD1 RID: 6865
	public ParticleSystem[] SpeechLines;

	// Token: 0x04001AD2 RID: 6866
	public Transform[] CameraPosition;

	// Token: 0x04001AD3 RID: 6867
	public AudioClip[] ScoreJingles;

	// Token: 0x04001AD4 RID: 6868
	public AudioClip[] Voice;

	// Token: 0x04001AD5 RID: 6869
	public GameObject SkipButton;

	// Token: 0x04001AD6 RID: 6870
	public Transform BalanceBar;

	// Token: 0x04001AD7 RID: 6871
	public Transform RightScale;

	// Token: 0x04001AD8 RID: 6872
	public Transform LeftScale;

	// Token: 0x04001AD9 RID: 6873
	public Transform Scale;

	// Token: 0x04001ADA RID: 6874
	public AudioSource Jukebox;

	// Token: 0x04001ADB RID: 6875
	public AudioSource MyAudio;

	// Token: 0x04001ADC RID: 6876
	public AudioSource Walla;

	// Token: 0x04001ADD RID: 6877
	public Texture[] RankIcons;

	// Token: 0x04001ADE RID: 6878
	public UITexture Polaroid;

	// Token: 0x04001ADF RID: 6879
	public UITexture RankIcon;

	// Token: 0x04001AE0 RID: 6880
	public Animation Yandere;

	// Token: 0x04001AE1 RID: 6881
	public UISprite Darkness;

	// Token: 0x04001AE2 RID: 6882
	public UIPanel RankPanel;

	// Token: 0x04001AE3 RID: 6883
	public UILabel FactLabel;

	// Token: 0x04001AE4 RID: 6884
	public UILabel RankDesc;

	// Token: 0x04001AE5 RID: 6885
	public UILabel Subtitle;

	// Token: 0x04001AE6 RID: 6886
	public int[] EliminationSuspicion;

	// Token: 0x04001AE7 RID: 6887
	public int[] DetailSuspicion;

	// Token: 0x04001AE8 RID: 6888
	public int[] GuiltyPoints;

	// Token: 0x04001AE9 RID: 6889
	public string[] OpeningStatement;

	// Token: 0x04001AEA RID: 6890
	public string[] Eliminations;

	// Token: 0x04001AEB RID: 6891
	public string[] RivalNames;

	// Token: 0x04001AEC RID: 6892
	public string[] Details;

	// Token: 0x04001AED RID: 6893
	public string[] Fact;

	// Token: 0x04001AEE RID: 6894
	public float TargetRotation;

	// Token: 0x04001AEF RID: 6895
	public float MusicTimer;

	// Token: 0x04001AF0 RID: 6896
	public float Rotation;

	// Token: 0x04001AF1 RID: 6897
	public float Speed;

	// Token: 0x04001AF2 RID: 6898
	public float Timer;

	// Token: 0x04001AF3 RID: 6899
	public bool Innocent;

	// Token: 0x04001AF4 RID: 6900
	public int Innocence;

	// Token: 0x04001AF5 RID: 6901
	public int FactID;

	// Token: 0x04001AF6 RID: 6902
	public int Guilt;

	// Token: 0x04001AF7 RID: 6903
	public int Phase;

	// Token: 0x04001AF8 RID: 6904
	public int Score;

	// Token: 0x04001AF9 RID: 6905
	public int Rank;

	// Token: 0x04001AFA RID: 6906
	public AudioClip Deaths;

	// Token: 0x04001AFB RID: 6907
	public AudioClip Disappearances;

	// Token: 0x04001AFC RID: 6908
	public AudioClip DeathsAndDisappearances;

	// Token: 0x04001AFD RID: 6909
	public AudioClip SomeDeaths;

	// Token: 0x04001AFE RID: 6910
	public AudioClip SomeDisappearances;

	// Token: 0x04001AFF RID: 6911
	public AudioClip GuiltyClip;

	// Token: 0x04001B00 RID: 6912
	public AudioClip InnocentClip;

	// Token: 0x04001B01 RID: 6913
	public GameObject OriginalHair;

	// Token: 0x04001B02 RID: 6914
	public GameObject[] VtuberHairs;

	// Token: 0x04001B03 RID: 6915
	public Texture[] VtuberFaces;

	// Token: 0x04001B04 RID: 6916
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001B05 RID: 6917
	public bool Vtuber;
}
