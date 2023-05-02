using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class CourtroomScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public EightiesStatsScript Stats;

	public ParticleSystem[] SpeechLines;

	public Transform[] CameraPosition;

	public AudioClip[] ScoreJingles;

	public AudioClip[] Voice;

	public GameObject SkipButton;

	public Transform BalanceBar;

	public Transform RightScale;

	public Transform LeftScale;

	public Transform Scale;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public AudioSource Walla;

	public Texture[] RankIcons;

	public UITexture Polaroid;

	public UITexture RankIcon;

	public Animation Yandere;

	public UISprite Darkness;

	public UIPanel RankPanel;

	public UILabel FactLabel;

	public UILabel RankDesc;

	public UILabel Subtitle;

	public int[] EliminationSuspicion;

	public int[] DetailSuspicion;

	public int[] GuiltyPoints;

	public string[] OpeningStatement;

	public string[] Eliminations;

	public string[] RivalNames;

	public string[] Details;

	public string[] Fact;

	public float TargetRotation;

	public float MusicTimer;

	public float Rotation;

	public float Speed;

	public float Timer;

	public bool Innocent;

	public int Innocence;

	public int FactID;

	public int Guilt;

	public int Phase;

	public int Score;

	public int Rank;

	public AudioClip Deaths;

	public AudioClip Disappearances;

	public AudioClip DeathsAndDisappearances;

	public AudioClip SomeDeaths;

	public AudioClip SomeDisappearances;

	public AudioClip GuiltyClip;

	public AudioClip InnocentClip;

	public GameObject KnifeOnlyIcon;

	public GameObject NoAlertsIcon;

	public GameObject NoBagIcon;

	public GameObject NoFriendsIcon;

	public GameObject NoGamingIcon;

	public GameObject NoInfoIcon;

	public GameObject NoLaughIcon;

	public GameObject RivalsOnlyIcon;

	public GameObject OriginalHair;

	public GameObject[] VtuberHairs;

	public Texture[] VtuberFaces;

	public SkinnedMeshRenderer MyRenderer;

	public bool Vtuber;

	private void Start()
	{
		Subtitle.text = "";
		Polaroid.alpha = 0f;
		Darkness.alpha = 1f;
		RankPanel.alpha = 0f;
		GameGlobals.TrueEnding = false;
		Scale.localPosition = new Vector3(0f, 0.645f, 1f);
		base.transform.position = new Vector3(0f, 5f, 15f);
		base.transform.eulerAngles = new Vector3(15f, 180f, 0f);
		Jukebox.volume = 0f;
		ResetBloom();
		VtuberCheck();
		KnifeOnlyIcon.SetActive(ChallengeGlobals.KnifeOnly);
		NoAlertsIcon.SetActive(ChallengeGlobals.NoAlerts);
		NoBagIcon.SetActive(ChallengeGlobals.NoBag);
		NoFriendsIcon.SetActive(ChallengeGlobals.NoFriends);
		NoGamingIcon.SetActive(ChallengeGlobals.NoGaming);
		NoInfoIcon.SetActive(ChallengeGlobals.NoInfo);
		NoLaughIcon.SetActive(ChallengeGlobals.NoLaugh);
		RivalsOnlyIcon.SetActive(ChallengeGlobals.RivalsOnly);
	}

	public void UpdateFactLabels()
	{
		Fact[1] = RivalNames[1] + " " + Eliminations[Stats.EliminationIDs[1]];
		GuiltyPoints[1] = EliminationSuspicion[Stats.EliminationIDs[1]];
		Fact[2] = Details[Stats.DetailIDs[1]];
		GuiltyPoints[2] = DetailSuspicion[Stats.DetailIDs[1]];
		Fact[3] = RivalNames[2] + " " + Eliminations[Stats.EliminationIDs[2]];
		GuiltyPoints[3] = EliminationSuspicion[Stats.EliminationIDs[2]];
		Fact[4] = Details[Stats.DetailIDs[2]];
		GuiltyPoints[4] = DetailSuspicion[Stats.DetailIDs[2]];
		Fact[5] = RivalNames[3] + " " + Eliminations[Stats.EliminationIDs[3]];
		GuiltyPoints[5] = EliminationSuspicion[Stats.EliminationIDs[3]];
		Fact[6] = Details[Stats.DetailIDs[3]];
		GuiltyPoints[6] = DetailSuspicion[Stats.DetailIDs[3]];
		Fact[7] = RivalNames[4] + " " + Eliminations[Stats.EliminationIDs[4]];
		GuiltyPoints[7] = EliminationSuspicion[Stats.EliminationIDs[4]];
		Fact[8] = Details[Stats.DetailIDs[4]];
		GuiltyPoints[8] = DetailSuspicion[Stats.DetailIDs[4]];
		Fact[9] = RivalNames[5] + " " + Eliminations[Stats.EliminationIDs[5]];
		GuiltyPoints[9] = EliminationSuspicion[Stats.EliminationIDs[5]];
		Fact[10] = Details[Stats.DetailIDs[5]];
		GuiltyPoints[10] = DetailSuspicion[Stats.DetailIDs[5]];
		Fact[11] = RivalNames[6] + " " + Eliminations[Stats.EliminationIDs[6]];
		GuiltyPoints[11] = EliminationSuspicion[Stats.EliminationIDs[6]];
		Fact[12] = Details[Stats.DetailIDs[6]];
		GuiltyPoints[12] = DetailSuspicion[Stats.DetailIDs[6]];
		Fact[13] = RivalNames[7] + " " + Eliminations[Stats.EliminationIDs[7]];
		GuiltyPoints[13] = EliminationSuspicion[Stats.EliminationIDs[7]];
		Fact[14] = Details[Stats.DetailIDs[7]];
		GuiltyPoints[14] = DetailSuspicion[Stats.DetailIDs[7]];
		Fact[15] = RivalNames[8] + " " + Eliminations[Stats.EliminationIDs[8]];
		GuiltyPoints[15] = EliminationSuspicion[Stats.EliminationIDs[8]];
		Fact[16] = Details[Stats.DetailIDs[8]];
		GuiltyPoints[16] = DetailSuspicion[Stats.DetailIDs[8]];
		Fact[17] = RivalNames[9] + " " + Eliminations[Stats.EliminationIDs[9]];
		GuiltyPoints[17] = EliminationSuspicion[Stats.EliminationIDs[9]];
		Fact[18] = Details[Stats.DetailIDs[9]];
		GuiltyPoints[18] = DetailSuspicion[Stats.DetailIDs[9]];
		Fact[19] = RivalNames[10] + " " + Eliminations[Stats.EliminationIDs[10]];
		GuiltyPoints[19] = EliminationSuspicion[Stats.EliminationIDs[10]];
		Fact[20] = Details[Stats.DetailIDs[10]];
		GuiltyPoints[20] = DetailSuspicion[Stats.DetailIDs[10]];
		Fact[21] = "After Sumire's disappearance, the police were called to Akademi a total of " + PlayerGlobals.PoliceVisits + " times.";
		GuiltyPoints[21] = PlayerGlobals.PoliceVisits;
		Fact[22] = "The police discovered a total of " + PlayerGlobals.CorpsesDiscovered + " corpses at Akademi.";
		GuiltyPoints[22] = PlayerGlobals.CorpsesDiscovered;
		Fact[23] = "Ryoba made " + PlayerGlobals.Friends + " friends at Akademi.";
		GuiltyPoints[23] = PlayerGlobals.Friends * -1;
		Fact[24] = "Ryoba's reputation at school is " + Mathf.RoundToInt(PlayerGlobals.Reputation) + ".";
		GuiltyPoints[24] = Mathf.RoundToInt(PlayerGlobals.Reputation) * -1;
		Fact[25] = "Ryoba's classmates witnessed her doing something suspicious " + PlayerGlobals.Alarms + " times.";
		GuiltyPoints[25] = PlayerGlobals.Alarms;
		Fact[26] = "Ryoba's classmates witnessed her carrying a dangerous weapon around school " + PlayerGlobals.WeaponWitnessed + " times.";
		GuiltyPoints[26] = PlayerGlobals.WeaponWitnessed;
		Fact[27] = "Ryoba's classmates witnessed her walking around in blood-stained clothing " + PlayerGlobals.BloodWitnessed + " times.";
		GuiltyPoints[27] = PlayerGlobals.BloodWitnessed;
		if (Stats.Grudges == 0)
		{
			Fact[28] = Stats.Grudges + " students testified that they witnessed Ryoba commit murder.";
		}
		else if (Stats.Grudges == 1)
		{
			Fact[28] = Stats.Grudges + " student testified that they witnessed Ryoba commit murder, but had no evidence.";
		}
		else
		{
			Fact[28] = Stats.Grudges + " students testified that they witnessed Ryoba commit murder, but had no evidence.";
		}
		GuiltyPoints[28] = Stats.Grudges * 20;
	}

	private void Update()
	{
		if (Phase == 0)
		{
			Timer += Time.deltaTime;
			Speed += Time.deltaTime * 0.2f;
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.2f);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 2f, 2f), Time.deltaTime * Speed);
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				Timer = 11f;
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				Timer = 0f;
				Phase = 66;
				Darkness.alpha = 0f;
				base.transform.position = CameraPosition[65].position;
				base.transform.eulerAngles = CameraPosition[65].eulerAngles;
			}
			if (Timer > 10f)
			{
				Phase++;
				Timer = 0f;
				Darkness.alpha = 0f;
				Subtitle.text = OpeningStatement[Phase];
				MyAudio.clip = Voice[Phase];
				MyAudio.Play();
				base.transform.position = CameraPosition[Phase].position;
				base.transform.eulerAngles = CameraPosition[Phase].eulerAngles;
			}
		}
		else if (Phase < 66)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				Phase++;
				if (Phase < 66)
				{
					Subtitle.text = OpeningStatement[Phase];
					MyAudio.clip = Voice[Phase];
					MyAudio.Play();
					base.transform.position = CameraPosition[Phase].position;
					base.transform.eulerAngles = CameraPosition[Phase].eulerAngles;
				}
				else
				{
					Subtitle.text = "";
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				Phase = 66;
				Subtitle.text = "";
				base.transform.position = CameraPosition[65].position;
				base.transform.eulerAngles = CameraPosition[65].eulerAngles;
			}
		}
		else if (Phase == 66)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0.5f, Time.deltaTime * 0.5f);
			Scale.localPosition = Vector3.Lerp(Scale.localPosition, new Vector3(0f, -0.2f, 1f), Time.deltaTime * 10f);
			if (Darkness.alpha == 0.5f)
			{
				Scale.localPosition = new Vector3(0f, -0.2f, 1f);
				if (Fact[FactID] == "")
				{
					Fact[FactID] = "Huh? The game could not identify how this character was eliminated. Tell YandereDev about this, and let him know exactly how you eliminated her.";
				}
				FactLabel.text = Fact[FactID];
				Guilt += GuiltyPoints[FactID];
				SkipButton.SetActive(value: false);
				Phase++;
			}
		}
		else if (Phase == 67)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (FactID < Fact.Length - 1)
				{
					FactID++;
					if (Fact[FactID] == "")
					{
						Fact[FactID] = "Huh? The game could not identify how this character was eliminated. Tell YandereDev about this, and let him know exactly how you eliminated her.";
					}
					FactLabel.text = Fact[FactID];
					if (GuiltyPoints[FactID] > 0)
					{
						Guilt += GuiltyPoints[FactID];
					}
					else
					{
						Innocence -= GuiltyPoints[FactID];
					}
				}
				else
				{
					FactLabel.text = "";
					Phase++;
				}
			}
		}
		else if (Phase == 68)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.5f);
			Scale.localPosition = Vector3.Lerp(Scale.localPosition, new Vector3(0f, 0.645f, 1f), Time.deltaTime * 10f);
			if (Darkness.alpha == 0f)
			{
				Scale.localPosition = new Vector3(0f, 0.645f, 1f);
				Subtitle.text = "Taking all of the facts into consideration, it is clear beyond any shadow of a doubt...";
				MyAudio.clip = Voice[66];
				MyAudio.Play();
				Phase++;
			}
		}
		else if (Phase == 69)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (Guilt - Innocence > 0)
				{
					if (Stats.Deaths == 10)
					{
						Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven deaths over the past eleven weeks.";
						MyAudio.clip = Deaths;
					}
					else if (Stats.Disappearances == 10)
					{
						Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven disappearances over the past eleven weeks.";
						MyAudio.clip = Disappearances;
					}
					else if (Stats.Deaths + Stats.Disappearances == 10)
					{
						Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven deaths and disappearances over the past eleven weeks.";
						MyAudio.clip = DeathsAndDisappearances;
					}
					else if (Stats.Deaths > 0)
					{
						Subtitle.text = "...that Ryoba Aishi is responsible for at least one death over the past eleven weeks.";
						MyAudio.clip = SomeDeaths;
					}
					else if (Stats.Disappearances > 0)
					{
						Subtitle.text = "...that Ryoba Aishi is responsible for at least one disappearance over the past eleven weeks.";
						MyAudio.clip = SomeDisappearances;
					}
					else if (Stats.Deaths + Stats.Disappearances == 0)
					{
						Subtitle.text = "...that Ryoba Aishi is responsible for Sumire Saitozaki's death.";
						MyAudio.clip = GuiltyClip;
					}
				}
				else
				{
					MyRenderer.SetBlendShapeWeight(0, 0f);
					Subtitle.text = "...that Ryoba Aishi is innocent of all charges.";
					MyAudio.clip = InnocentClip;
					Innocent = true;
				}
				MyAudio.Play();
				Phase++;
			}
		}
		else if (Phase == 70)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				Speed = 0f;
				Subtitle.text = "";
				base.transform.position = CameraPosition[15].position;
				base.transform.eulerAngles = CameraPosition[15].eulerAngles;
				if (Innocent)
				{
					Yandere["YandereConfessionRejected"].time = 4.5f;
					Yandere.CrossFade("YandereConfessionRejected");
				}
				else
				{
					Yandere.transform.position = new Vector3(0f, 0f, 0.15f);
					Yandere.CrossFade("YandereConfessionAccepted");
				}
				PopulateRankPanel();
				AudioSource.PlayClipAtPoint(ScoreJingles[Rank], base.transform.position);
				Phase++;
			}
		}
		else if (Phase == 71)
		{
			Timer += Time.deltaTime;
			if (Timer > 2.5f)
			{
				if (Innocent)
				{
					Yandere.CrossFade("YandereConfessionRejectedLoop");
				}
				else
				{
					Yandere.CrossFade("f02_down_22");
				}
				if (Timer > 3f)
				{
					Phase++;
				}
			}
		}
		else if (Phase == 72)
		{
			RankPanel.alpha = Mathf.MoveTowards(RankPanel.alpha, 1f, Time.deltaTime);
			if (RankPanel.alpha == 1f)
			{
				Phase++;
			}
		}
		else if (Phase == 73)
		{
			RankIcon.transform.localScale = Vector3.Lerp(RankIcon.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (RankIcon.transform.localScale.x > 0.999f)
			{
				RankDesc.alpha = Mathf.MoveTowards(RankDesc.alpha, 1f, Time.deltaTime);
				if (RankDesc.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					Phase++;
				}
			}
		}
		else if (Phase == 74)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha == 1f)
			{
				if (Innocent)
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
		if (Phase < 68)
		{
			MusicTimer += Time.deltaTime;
			if (MusicTimer > 1f)
			{
				Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0.033333f, Time.deltaTime * 0.01f);
			}
		}
		else
		{
			Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0f, Time.deltaTime * 0.1f);
		}
		if (Phase > 70)
		{
			Speed += Time.deltaTime;
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(2f / 3f, 1.33333f, -1f), Time.deltaTime * Speed);
		}
		if (Phase == 27 || Phase == 47 || Phase == 63)
		{
			if (Walla.volume == 0f)
			{
				for (int i = 1; i < SpeechLines.Length; i++)
				{
					SpeechLines[i].Play();
				}
			}
			Walla.volume = Mathf.MoveTowards(Walla.volume, 0.5f, Time.deltaTime * 0.2f);
		}
		else
		{
			if (SpeechLines[1].isPlaying)
			{
				for (int j = 1; j < SpeechLines.Length; j++)
				{
					SpeechLines[j].Stop();
				}
			}
			Walla.volume = Mathf.MoveTowards(Walla.volume, 0f, Time.deltaTime * 0.2f);
		}
		if (Phase == 9 || Phase == 10)
		{
			Polaroid.transform.localPosition = Vector3.Lerp(Polaroid.transform.localPosition, new Vector3(700f, 200f, 0f), Time.deltaTime);
			Polaroid.alpha = Mathf.MoveTowards(Polaroid.alpha, 1f, Time.deltaTime);
		}
		else
		{
			Polaroid.transform.localPosition = Vector3.Lerp(Polaroid.transform.localPosition, new Vector3(700f, 0f, 0f), Time.deltaTime);
			Polaroid.alpha = Mathf.MoveTowards(Polaroid.alpha, 0f, Time.deltaTime);
		}
		TargetRotation = (float)(Guilt - Innocence) * 0.25f;
		if (TargetRotation > 25f)
		{
			TargetRotation = 25f;
		}
		if (TargetRotation < -25f)
		{
			TargetRotation = -25f;
		}
		Rotation = Mathf.Lerp(Rotation, TargetRotation, Time.deltaTime);
		BalanceBar.localEulerAngles = new Vector3(0f, 0f, Rotation);
		RightScale.eulerAngles = new Vector3(0f, 0f, 0f);
		LeftScale.eulerAngles = new Vector3(0f, 0f, 0f);
		if (base.transform.position == CameraPosition[1].position || base.transform.position == CameraPosition[15].position || base.transform.position == CameraPosition[65].position || Phase > 70)
		{
			UpdateDOF(1f);
		}
		else
		{
			UpdateDOF(3f);
		}
	}

	public void PopulateRankPanel()
	{
		RankIcon.transform.localScale = new Vector3(0f, 0f, 0f);
		Score = (Guilt - Innocence) * -1;
		if (!Innocent)
		{
			Rank = 0;
			RankDesc.text = "You successfully eliminated your rivals, but aroused so much suspicion that you were eventually judged to be guilty of murder.";
		}
		else if (Score >= 100)
		{
			Rank = 5;
			RankDesc.text = "Everyone loves you, and nobody has any reason to suspect that you might be a killer! You are a true yandere!";
			if (Stats.EliminationIDs[1] == 18 && Stats.EliminationIDs[2] == 5 && Stats.EliminationIDs[3] == 6 && Stats.EliminationIDs[4] == 15 && Stats.EliminationIDs[5] == 7 && Stats.EliminationIDs[6] == 8 && Stats.EliminationIDs[7] == 9 && Stats.EliminationIDs[8] == 4 && Stats.EliminationIDs[9] == 13 && Stats.EliminationIDs[10] == 2)
			{
				Debug.Log("True ending unlocked!");
				Rank = 6;
				GameGlobals.TrueEnding = true;
			}
		}
		else if (Score >= 75)
		{
			Rank = 4;
			RankDesc.text = "Nearly everyone is convinced that you are innocent, but there are still a few people who doubt you.";
		}
		else if (Score >= 50)
		{
			Rank = 3;
			RankDesc.text = "Public opinion is split 50/50 on whether or not you are a killer. Many people will prefer to avoid you.";
		}
		else if (Score >= 25)
		{
			Rank = 2;
			RankDesc.text = "You avoided a guilty verdict, but you've still taken a massive hit to your reputation.";
		}
		else if (Score >= 0)
		{
			Rank = 1;
			RankDesc.text = "You barely managed to avoid a guilty verdict. You will be regarded with suspicion for the rest of your life.";
		}
		RankIcon.mainTexture = RankIcons[Rank];
	}

	private void UpdateDOF(float Value)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Value;
		settings.aperture = 5.6f;
		Profile.depthOfField.settings = settings;
	}

	private void ResetBloom()
	{
		BloomModel.Settings settings = Profile.bloom.settings;
		settings.bloom.intensity = 1f;
		settings.bloom.threshold = 1.1f;
		settings.bloom.softKnee = 0.75f;
		settings.bloom.radius = 4f;
		Profile.bloom.settings = settings;
	}

	public void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			OriginalHair.SetActive(value: false);
			VtuberHairs[GameGlobals.VtuberID].SetActive(value: true);
			MyRenderer.materials[2].mainTexture = VtuberFaces[GameGlobals.VtuberID];
			for (int i = 0; i < 13; i++)
			{
				MyRenderer.SetBlendShapeWeight(i, 0f);
			}
			MyRenderer.SetBlendShapeWeight(0, 100f);
			MyRenderer.SetBlendShapeWeight(9, 100f);
			Vtuber = true;
		}
		else
		{
			VtuberHairs[1].SetActive(value: false);
		}
	}
}
