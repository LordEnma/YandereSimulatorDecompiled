using UnityEngine;
using XInputDotNetPure;

public class CounselorScript : MonoBehaviour
{
	public CutsceneManagerScript CutsceneManager;

	public StudentManagerScript StudentManager;

	public CounselorDoorScript CounselorDoor;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public EndOfDayScript EndOfDay;

	public SubtitleScript Subtitle;

	public SchemesScript Schemes;

	public StudentScript Student;

	public YandereScript Yandere;

	public Animation MyAnimation;

	public AudioSource MyAudio;

	public PromptScript Prompt;

	public GameObject DelinquentRadio;

	public AudioClip[] EightiesCounselorLectureClips;

	public AudioClip[] EightiesCounselorReportClips;

	public AudioClip[] CounselorGreetingClips;

	public AudioClip[] CounselorLectureClips;

	public AudioClip[] CounselorReportClips;

	public AudioClip[] EightiesRivalClips;

	public AudioClip[] RivalClips;

	public AudioClip CounselorFarewellClip;

	public readonly string CounselorFarewellText = "Don't misbehave.";

	public AudioClip CounselorBusyClip;

	public readonly string CounselorBusyText = "I'm sorry, I've got my hands full for the rest of today. I won't be available until tomorrow.";

	public bool MustReturnStolenRing;

	public bool StoleRing;

	public string RivalName;

	private string[] CounselorGreetingText = new string[3] { "", "What can I help you with?", "Can I help you?" };

	private string[] CounselorLectureText = new string[9] { "", "May I see your phone for a moment? ...what is THIS?! Would you care to explain why something like this is on your phone?", "May I take a look inside your bag? ...this doesn't belong to you, does it?! What are you doing with someone else's property?", "I need to take a look in your bag. ...cigarettes?! You have absolutely no excuse to be carrying something like this around!", "It has come to my attention that you've been vandalizing the school's property. What, exactly, do you have to say for yourself?", "Obviously, we need to have a long talk about the kind of behavior that will not tolerated at this school!", "(This line of text doesn't show up outside of the Eighties.)", "That's it! I've given you enough second chances. You have repeatedly broken school rules and ignored every warning that I have given you. You have left me with no choice but to permanently expel you!", "(This line of text doesn't show up outside of the Eighties.)" };

	private string[] EightiesCounselorLectureText = new string[9] { "", "May I see your bag for a moment? ...what is THIS?! Would you care to explain why you brought something like this to school?!", "Whatever you do in the privacy of your own home is none of my business. But there is NO reason for you to bring something like THIS to school!", "I need to take a look in your bag. ...cigarettes?! You have absolutely no excuse to be carrying something like this around!", "May I take a look inside your bag? ...this doesn't belong to you, does it?! What are you doing with someone else's property?", "It's absolutely appalling that you honestly believed you were going to get away with cheating! And at THIS institution, of all places!", "I can't believe you actually brought illegal narcotics to school with you! How did you even get ahold of something like this?!", "That's it! I've given you enough second chances. You have repeatedly broken school rules and ignored every warning that I have given you. You have left me with no choice but to permanently expel you!", "Enough! I have no choice but to inform the police immediately. Explain yourself to them, not me." };

	private string[] CounselorReportText = new string[7] { "", "That's a very serious accusation. I hope you're not lying to me. Hopefully, it's just a misunderstanding. I'll investigate the matter.", "Is that true? I'd hate to think we have a thief here at school. Don't worry - I'll get to the bottom of this.", "That's a clear violation of school rules, not to mention completely illegal. If what you're saying is true, she will face serious consequences. I'll confront her about this.", "Thank you for bringing this to my attention! I'll have to have a word with her later today...", "That's a bold claim. Are you certain? I'll investigate the matter. If she is cheating, I'll catch her in the act.", "(This line of text doesn't show up outside of the Eighties.)" };

	private string[] EightiesCounselorReportText = new string[7] { "", "That's a very serious accusation. I hope you're not lying to me. Hopefully, it's just a misunderstanding. I'll investigate the matter.", "Thank you for bringing this to my attention! I'll have to have a word with her later today...", "That's a clear violation of school rules, not to mention completely illegal. If what you're saying is true, she will face serious consequences. I'll confront her about this.", "Is that true? I'd hate to think we have a thief here at school. Don't worry - I'll get to the bottom of this.", "That's a bold claim. Are you certain? I'll investigate the matter. If she is cheating, I'll catch her in the act.", "...are you serious? Illegal narcotics?! If this is true, she'll be expelled immediately, and the police WILL be informed." };

	private string[] LectureIntro = new string[8] { "", "The guidance counselor enters your rival's classroom and says that she needs to speak with her...", "The guidance counselor enters your rival's classroom and says that she needs to speak with her...", "The guidance counselor enters your rival's classroom and says that she needs to speak with her...", "The guidance counselor enters your rival's classroom and says that she needs to speak with her...", "The guidance counselor enters your rival's classroom and says that she needs to speak with her...", "The guidance counselor enters your rival's classroom and says that she needs to speak with her...", "The guidance counselor enters your rival's classroom and says that she needs to speak with her..." };

	private string[] RivalText = new string[9] { "", "What?! I've never taken any pictures like that! How did this get on my phone?!", "No! I'm not the one who did this! I would never steal from anyone!", "Huh? I don't smoke! I don't know why something like this was in my bag!", "W-wait, I can explain! It's not what you think!", "I'm telling the truth! I didn't steal the answer sheet! I don't know why it was in my desk!", "(This line of text doesn't show up outside of the Eighties.)", "No...! P-please! Don't do this!", "(This line of text doesn't show up outside of the Eighties.)" };

	private string[] EightiesRivalText = new string[9] { "", "What?! I don't drink! How did something like this get in my bag?!", "No! I've never even seen these things before! I swear!", "Huh? I don't smoke! I don't know why something like this was in my bag!", "No! I'm not the one who did this! I would never steal from anyone!", "I'm telling the truth! I didn't steal the answer sheet! I don't know why it was in my bag!", "Wait! I'm being framed! You've got to believe me!", "No...! P-please! Don't do this!", "No! Please! Don't call the police! I'm begging you!" };

	public UILabel[] Labels;

	public Transform CounselorWindow;

	public Transform NarcoticsWindow;

	public Transform Highlight;

	public Transform Chibi;

	public SkinnedMeshRenderer Face;

	public UILabel CounselorSubtitle;

	public UISprite EndOfDayDarkness;

	public UILabel LectureSubtitle;

	public UISprite ExpelProgress;

	public UILabel LectureLabel;

	public bool ShowWindow;

	public bool Lecturing;

	public bool Eighties;

	public bool Busy;

	public int Selected = 1;

	public int LecturePhase = 1;

	public int LectureID = 5;

	public float ExpelTimer;

	public float ChinTimer;

	public float TalkTimer = 1f;

	public float Timer;

	public UITexture ChibiTexture;

	public Texture[] EightiesRivalHeads;

	public Texture[] RivalHeads;

	public int SadMouthID = 1;

	public int MadBrowID = 5;

	public int SadBrowID = 6;

	public int AngryEyesID = 9;

	public int MouthOpenID = 2;

	public int RivalExpelProgress;

	public int CounselorPunishments;

	public int CounselorVisits;

	public int CounselorTape;

	public int BloodVisits;

	public int InsanityVisits;

	public int LewdVisits;

	public int TheftVisits;

	public int TrespassVisits;

	public int WeaponVisits;

	public int BloodBlameUsed;

	public int InsanityBlameUsed;

	public int LewdBlameUsed;

	public int TheftBlameUsed;

	public int TrespassBlameUsed;

	public int WeaponBlameUsed;

	public int ApologiesUsed;

	public int WeaponsBanned;

	public int DelinquentPunishments;

	public GameObject ModernAttacher;

	public bool ReportedAlcohol;

	public bool ReportedCondoms;

	public bool ReportedCigarettes;

	public bool ReportedTheft;

	public bool ReportedCheating;

	public bool ReportedNarcotics;

	public Vector3 LookAtTarget;

	public bool LookAtPlayer;

	public Transform Default;

	public Transform Head;

	public bool Angry;

	public bool Stern;

	public bool Sad;

	public float MouthTarget;

	public float MouthTimer;

	public float TimerLimit;

	public float MouthOpen;

	public float TalkSpeed;

	public float BS_SadMouth;

	public float BS_MadBrow;

	public float BS_SadBrow;

	public float BS_AngryEyes;

	public DetectClickScript[] CounselorOption;

	public CabinetDoorScript InfirmaryCabinetDoor;

	public InputDeviceScript InputDevice;

	public WeaponScript WeaponToReturn;

	public StudentWitnessType Crime;

	public UITexture GenkaChibi;

	public CameraShake Shake;

	public Texture HappyChibi;

	public Texture AnnoyedChibi;

	public Texture MadChibi;

	public GameObject CounselorOptions;

	public GameObject CounselorBar;

	public GameObject Reticle;

	public GameObject Laptop;

	public GameObject RedPen;

	public Transform CameraTarget;

	public int InterrogationPhase;

	public int Patience;

	public int CrimeID;

	public int Answer;

	public bool MustExpelDelinquents;

	public bool ExpelledDelinquents;

	public bool SilentTreatment;

	public bool Interrogating;

	public bool SentHome;

	public bool Expelled;

	public bool Slammed;

	public AudioSource Rumble;

	public AudioClip EightiesCountdown;

	public AudioClip Countdown;

	public AudioClip Choice;

	public AudioClip Slam;

	public RiggedAccessoryAttacher EightiesAttacher;

	public GameObject[] EightiesMesh;

	public GameObject[] OriginalMesh;

	public GameObject EightiesPaper;

	public Transform PelvisRoot;

	public bool UpdatedFace;

	public AudioClip[] GreetingClips;

	public string[] Greetings;

	public AudioClip[] BloodLectureClips;

	public string[] BloodLectures;

	public AudioClip[] InsanityLectureClips;

	public string[] InsanityLectures;

	public AudioClip[] LewdLectureClips;

	public string[] LewdLectures;

	public AudioClip[] TheftLectureClips;

	public string[] TheftLectures;

	public AudioClip[] TrespassLectureClips;

	public string[] TrespassLectures;

	public AudioClip[] WeaponLectureClips;

	public string[] WeaponLectures;

	public AudioClip[] SilentClips;

	public string[] Silents;

	public AudioClip[] SuspensionClips;

	public string[] Suspensions;

	public AudioClip[] AcceptExcuseClips;

	public string[] AcceptExcuses;

	public AudioClip[] RejectExcuseClips;

	public string[] RejectExcuses;

	public AudioClip[] RejectLieClips;

	public string[] RejectLies;

	public AudioClip[] AcceptBlameClips;

	public string[] AcceptBlames;

	public AudioClip[] RejectApologyClips;

	public string[] RejectApologies;

	public AudioClip[] RejectBlameClips;

	public string[] RejectBlames;

	public AudioClip[] RejectFlirtClips;

	public string[] RejectFlirts;

	public AudioClip[] BadClosingClips;

	public string[] BadClosings;

	public AudioClip[] BlameClosingClips;

	public string[] BlameClosings;

	public AudioClip[] FreeToLeaveClips;

	public string[] FreeToLeaves;

	public AudioClip AcceptApologyClip;

	public string AcceptApology;

	public AudioClip RejectThreatClip;

	public string RejectThreat;

	public AudioClip ExpelDelinquentsClip;

	public string ExpelDelinquents;

	public AudioClip DelinquentsDeadClip;

	public string DelinquentsDead;

	public AudioClip DelinquentsExpelledClip;

	public string DelinquentsExpelled;

	public AudioClip DelinquentsGoneClip;

	public string DelinquentsGone;

	public AudioClip[] ExcuseClips;

	public string[] Excuses;

	public AudioClip[] LieClips;

	public string[] Lies;

	public AudioClip[] DelinquentClips;

	public string[] Delinquents;

	public AudioClip ApologyClip;

	public string Apology;

	public AudioClip FlirtClip;

	public string Flirt;

	public AudioClip ThreatenClip;

	public string Threaten;

	public AudioClip Silence;

	public float VibrationTimer;

	public bool VibrationCheck;

	public UILabel RIVAL;

	public UILabel EXPELLED;

	public int BloodExcuseUsed;

	public int InsanityExcuseUsed;

	public int LewdExcuseUsed;

	public int TheftExcuseUsed;

	public int TrespassExcuseUsed;

	public int WeaponExcuseUsed;

	public AudioClip LongestSilence;

	public AudioClip LongSilence;

	private void Start()
	{
		CounselorPunishments = CounselorGlobals.CounselorPunishments;
		CounselorVisits = CounselorGlobals.CounselorVisits;
		CounselorTape = CounselorGlobals.CounselorTape;
		BloodVisits = CounselorGlobals.BloodVisits;
		InsanityVisits = CounselorGlobals.InsanityVisits;
		LewdVisits = CounselorGlobals.LewdVisits;
		TheftVisits = CounselorGlobals.TheftVisits;
		TrespassVisits = CounselorGlobals.TrespassVisits;
		WeaponVisits = CounselorGlobals.WeaponVisits;
		BloodBlameUsed = CounselorGlobals.BloodBlameUsed;
		InsanityBlameUsed = CounselorGlobals.InsanityBlameUsed;
		LewdBlameUsed = CounselorGlobals.LewdBlameUsed;
		TheftBlameUsed = CounselorGlobals.TheftBlameUsed;
		TrespassBlameUsed = CounselorGlobals.TrespassBlameUsed;
		WeaponBlameUsed = CounselorGlobals.WeaponBlameUsed;
		ApologiesUsed = CounselorGlobals.ApologiesUsed;
		WeaponsBanned = CounselorGlobals.WeaponsBanned;
		DelinquentPunishments = CounselorGlobals.DelinquentPunishments;
		CounselorWindow.localScale = Vector3.zero;
		CounselorWindow.gameObject.SetActive(value: false);
		CounselorOptions.SetActive(value: false);
		CounselorBar.SetActive(value: false);
		Reticle.SetActive(value: false);
		RivalExpelProgress = StudentGlobals.ExpelProgress;
		int week = DateGlobals.Week;
		if (week > 10)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		ExpelProgress.color = new Color(ExpelProgress.color.r, ExpelProgress.color.g, ExpelProgress.color.b, 0f);
		Chibi.localPosition = new Vector3(Chibi.localPosition.x, 250f + (float)RivalExpelProgress * -90f, Chibi.localPosition.z);
		LoadExcusesUsed();
		if (GameGlobals.Eighties)
		{
			Eighties = true;
			MyAnimation.Play("f02_deskWritePingPong_00");
			Laptop.SetActive(value: false);
			EightiesPaper.SetActive(value: true);
			EightiesAttacher.gameObject.SetActive(value: true);
			OriginalMesh[1].GetComponent<SkinnedMeshRenderer>().enabled = false;
			OriginalMesh[2].SetActive(value: false);
			OriginalMesh[3].SetActive(value: false);
			EightiesMesh[1].SetActive(value: true);
			Countdown = EightiesCountdown;
			Labels[1].text = "Report Alcohol";
			Labels[2].text = "Report Condoms";
			Labels[3].text = "Report Cigarettes";
			Labels[4].text = "Report Theft";
			Labels[5].text = "Report Cheating";
			Labels[6].text = "Report Narcotics";
			CounselorReportText = EightiesCounselorReportText;
			CounselorReportClips = EightiesCounselorReportClips;
			CounselorLectureText = EightiesCounselorLectureText;
			CounselorLectureClips = EightiesCounselorLectureClips;
			RivalText = EightiesRivalText;
			RivalClips = EightiesRivalClips;
			ChibiTexture.mainTexture = EightiesRivalHeads[week];
			ReportedAlcohol = CounselorGlobals.ReportedAlcohol;
			ReportedCigarettes = CounselorGlobals.ReportedCigarettes;
			ReportedCondoms = CounselorGlobals.ReportedCondoms;
			ReportedTheft = CounselorGlobals.ReportedTheft;
			ReportedCheating = CounselorGlobals.ReportedCheating;
			SadMouthID = 4;
			MadBrowID = 5;
			SadBrowID = 3;
			AngryEyesID = 2;
			MouthOpenID = 9;
			base.transform.position += new Vector3(0f, -0.1f, 0f);
			RedPen.SetActive(value: true);
			LewdLectureClips[0] = LongSilence;
			LewdLectureClips[1] = LongSilence;
			LewdLectures[0] = "You've been caught aiming a camera at a student's unmentionables. Start talking.";
			LewdLectures[1] = "Once again, you're here because you stuck a camera up someone's skirt. Oh, I can't wait to hear your excuse this time.";
		}
		else
		{
			ModernAttacher.gameObject.SetActive(value: true);
			OriginalMesh[1].GetComponent<SkinnedMeshRenderer>().enabled = false;
			OriginalMesh[2].SetActive(value: false);
			OriginalMesh[3].SetActive(value: false);
		}
	}

	private void Update()
	{
		if (LookAtPlayer)
		{
			if (TalkTimer < 1f)
			{
				TalkTimer = Mathf.MoveTowards(TalkTimer, 1f, Time.deltaTime);
				if (TalkTimer == 1f)
				{
					int num = Random.Range(1, 3);
					CounselorSubtitle.text = CounselorGreetingText[num];
					MyAudio.clip = CounselorGreetingClips[num];
					MyAudio.Play();
				}
			}
			if (InputManager.TappedUp)
			{
				Selected--;
				if (!Eighties && Selected == 6)
				{
					Selected = 5;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedDown)
			{
				Selected++;
				if (!Eighties && Selected == 6)
				{
					Selected = 7;
				}
				UpdateHighlight();
			}
			if (ShowWindow)
			{
				if (CounselorDoor.Darkness.color.a < 0.0001f)
				{
					CounselorDoor.Darkness.alpha = 0f;
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						if (Selected == 7)
						{
							if (!CounselorDoor.Exit)
							{
								CounselorSubtitle.text = CounselorFarewellText;
								MyAudio.clip = CounselorFarewellClip;
								MyAudio.Play();
								CounselorDoor.FadeOut = true;
								CounselorDoor.FadeIn = false;
								CounselorDoor.Exit = true;
							}
						}
						else if (Labels[Selected].color.a == 1f)
						{
							if (!Eighties)
							{
								if (Selected == 1)
								{
									SchemeGlobals.SetSchemeStage(1, 9);
									Schemes.UpdateInstructions();
								}
								else if (Selected == 2)
								{
									Debug.Log("This code is only supposed to fire if the player was speaking to the Counselor...");
									SchemeGlobals.SetSchemeStage(2, 7);
									Schemes.UpdateInstructions();
								}
								else if (Selected == 3)
								{
									SchemeGlobals.SetSchemeStage(3, 5);
									Schemes.UpdateInstructions();
								}
								else if (Selected == 4)
								{
									SchemeGlobals.SetSchemeStage(4, 8);
									Schemes.UpdateInstructions();
								}
								else if (Selected == 5)
								{
									SchemeGlobals.SetSchemeStage(5, 10);
									Schemes.UpdateInstructions();
								}
							}
							else if (Selected == 1)
							{
								ReportedAlcohol = true;
							}
							else if (Selected == 2)
							{
								ReportedCondoms = true;
							}
							else if (Selected == 3)
							{
								ReportedCigarettes = true;
							}
							else if (Selected == 4)
							{
								ReportedTheft = true;
							}
							else if (Selected == 5)
							{
								ReportedCheating = true;
							}
							else if (Selected == 6)
							{
								ReportedNarcotics = true;
							}
							CounselorSubtitle.text = CounselorReportText[Selected];
							MyAudio.clip = CounselorReportClips[Selected];
							MyAudio.Play();
							ShowWindow = false;
							Angry = true;
							CutsceneManager.Scheme = Selected;
							LectureID = Selected;
							PromptBar.ClearButtons();
							PromptBar.Show = false;
							Busy = true;
						}
					}
				}
			}
			else if (!Interrogating)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					MyAudio.Stop();
				}
				if (!MyAudio.isPlaying)
				{
					Timer += Time.deltaTime;
					if (Timer > 0.5f)
					{
						CounselorDoor.FadeOut = true;
						CounselorDoor.Exit = true;
						LookAtPlayer = false;
						UpdateList();
					}
				}
			}
		}
		if (ShowWindow)
		{
			CounselorWindow.localScale = Vector3.Lerp(CounselorWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		else if (CounselorWindow.localScale.x > 0.1f)
		{
			CounselorWindow.localScale = Vector3.Lerp(CounselorWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (CounselorWindow.gameObject.activeInHierarchy)
		{
			CounselorWindow.localScale = Vector3.zero;
			CounselorWindow.gameObject.SetActive(value: false);
		}
		if (Lecturing)
		{
			Chibi.localPosition = new Vector3(Chibi.localPosition.x, Mathf.Lerp(Chibi.localPosition.y, 250f + (float)RivalExpelProgress * -90f, Time.deltaTime * 3f), Chibi.localPosition.z);
			if (LecturePhase == 1)
			{
				LectureLabel.text = LectureIntro[LectureID];
				EndOfDayDarkness.color = new Color(EndOfDayDarkness.color.r, EndOfDayDarkness.color.g, EndOfDayDarkness.color.b, Mathf.MoveTowards(EndOfDayDarkness.color.a, 0f, Time.deltaTime));
				if (EndOfDayDarkness.color.a < 0.0001f)
				{
					EndOfDayDarkness.alpha = 0f;
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Continue";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						LecturePhase++;
						PromptBar.ClearButtons();
						PromptBar.Show = false;
					}
				}
			}
			else if (LecturePhase == 2)
			{
				LectureLabel.color = new Color(LectureLabel.color.r, LectureLabel.color.g, LectureLabel.color.b, Mathf.MoveTowards(LectureLabel.color.a, 0f, Time.deltaTime));
				if (LectureLabel.color.a < 0.0001f)
				{
					LectureLabel.alpha = 0f;
					EndOfDay.TextWindow.SetActive(value: false);
					EndOfDay.EODCamera.GetComponent<AudioListener>().enabled = true;
					LectureSubtitle.text = CounselorLectureText[LectureID];
					MyAudio.clip = CounselorLectureClips[LectureID];
					MyAudio.Play();
					LecturePhase++;
				}
			}
			else if (LecturePhase == 3)
			{
				if (!MyAudio.isPlaying || Input.GetButtonDown(InputNames.Xbox_A))
				{
					LectureSubtitle.text = RivalText[LectureID];
					MyAudio.clip = RivalClips[LectureID];
					MyAudio.Play();
					LecturePhase++;
				}
			}
			else if (LecturePhase == 4)
			{
				if (!MyAudio.isPlaying || Input.GetButtonDown(InputNames.Xbox_A))
				{
					LectureSubtitle.text = string.Empty;
					if (RivalExpelProgress < 5)
					{
						LecturePhase++;
					}
					else
					{
						LecturePhase = 7;
						ExpelTimer = 0f;
					}
				}
			}
			else if (LecturePhase == 5)
			{
				ExpelProgress.color = new Color(ExpelProgress.color.r, ExpelProgress.color.g, ExpelProgress.color.b, Mathf.MoveTowards(ExpelProgress.color.a, 1f, Time.deltaTime));
				ExpelTimer += Time.deltaTime;
				if (ExpelTimer > 2f)
				{
					if (ReportedNarcotics)
					{
						EXPELLED.text = "ARRESTED";
						RivalExpelProgress = 5;
					}
					else
					{
						RivalExpelProgress++;
					}
					LecturePhase++;
					Debug.Log("RivalExpelProgress is now: " + RivalExpelProgress);
				}
			}
			else if (LecturePhase == 6)
			{
				ExpelTimer += Time.deltaTime;
				if (ExpelTimer > 4f)
				{
					LecturePhase += 2;
				}
			}
			else if (LecturePhase == 7)
			{
				ExpelTimer += Time.deltaTime;
				if (ExpelTimer > 1f)
				{
					RIVAL.gameObject.SetActive(value: true);
				}
				if (ExpelTimer > 3f)
				{
					EXPELLED.gameObject.SetActive(value: true);
				}
				if (ExpelTimer > 5f)
				{
					RIVAL.color = new Color(RIVAL.color.r, RIVAL.color.g, RIVAL.color.b, RIVAL.color.a - Time.deltaTime);
					EXPELLED.color = new Color(EXPELLED.color.r, EXPELLED.color.g, EXPELLED.color.b, EXPELLED.color.a - Time.deltaTime);
				}
				if (ExpelTimer > 7f)
				{
					RIVAL.gameObject.SetActive(value: false);
					EXPELLED.gameObject.SetActive(value: false);
					LecturePhase++;
				}
			}
			else if (LecturePhase == 8)
			{
				Debug.Log("We are now in Lecture Phase 8. We're deciding whether to return to gameplay or expel the rival.");
				ExpelProgress.color = new Color(ExpelProgress.color.r, ExpelProgress.color.g, ExpelProgress.color.b, Mathf.MoveTowards(ExpelProgress.color.a, 0f, Time.deltaTime));
				ExpelTimer += Time.deltaTime;
				if (ExpelTimer > 6f)
				{
					if ((RivalExpelProgress == 5 && !StudentGlobals.GetStudentExpelled(StudentManager.RivalID) && EndOfDay.RivalEliminationMethod != RivalEliminationType.Expelled && EndOfDay.RivalEliminationMethod != RivalEliminationType.Arrested && StudentManager.Police.TranqCase.VictimID != StudentManager.RivalID) || StudentManager.Students[StudentManager.RivalID].SentHome)
					{
						Debug.Log("The guidence counselor is now choosing the words she will say when expelling the rival.");
						EndOfDayDarkness.color = new Color(EndOfDayDarkness.color.r, EndOfDayDarkness.color.g, EndOfDayDarkness.color.b, 0f);
						LectureLabel.color = new Color(LectureLabel.color.r, LectureLabel.color.g, LectureLabel.color.b, 0f);
						LecturePhase = 2;
						ExpelTimer = 0f;
						if (ReportedNarcotics)
						{
							LectureID = 8;
							EndOfDay.RivalEliminationMethod = RivalEliminationType.Arrested;
							StudentManager.RivalEliminated = true;
						}
						else
						{
							LectureID = 7;
							EndOfDay.RivalEliminationMethod = RivalEliminationType.Expelled;
							StudentManager.RivalEliminated = true;
						}
						if (StudentManager.Students[StudentManager.SuitorID] != null)
						{
							Debug.Log("Commanding the rival's suitor to stop trying to spy on her, since she's gone now.");
							StudentManager.Students[StudentManager.SuitorID].Curious = false;
						}
					}
					else
					{
						Debug.Log("The lecture is over. Now, the game decides where to go next.");
						Yandere.Subtitle.gameObject.SetActive(value: true);
						if (!EndOfDay.Police.Show)
						{
							Lecturing = false;
							if (Yandere.StudentManager.Clock.Period > 4 || SentHome)
							{
								if (SentHome)
								{
									Debug.Log("We got here after being sent home.");
								}
								else
								{
									Debug.Log("We got here during Period 5 or 6. We must be at the end of the school day.");
								}
								EndOfDay.Phase++;
								EndOfDay.UpdateScene();
							}
							else
							{
								Debug.Log("We got here prior to Period 5. We are leaving the lecture and returning to gameplay.");
								StudentManager.Portal.gameObject.GetComponent<PortalScript>().Class.gameObject.SetActive(value: true);
								StudentManager.Portal.gameObject.GetComponent<PortalScript>().ReturningFromLecture = true;
								EndOfDay.gameObject.SetActive(value: false);
								EndOfDay.Phase = 1;
								CutsceneManager.Phase++;
								Yandere.PauseScreen.Schemes.SchemeManager.enabled = false;
								Yandere.MainCamera.gameObject.SetActive(value: true);
								Yandere.gameObject.SetActive(value: true);
								SpawnDelinquents();
								Debug.Log("Now returning to gameplay from the counselor.");
								StudentManager.ComeBack();
								StudentManager.Students[StudentManager.RivalID].IdleAnim = StudentManager.Students[StudentManager.RivalID].BulliedIdleAnim;
								StudentManager.Students[StudentManager.RivalID].WalkAnim = StudentManager.Students[StudentManager.RivalID].BulliedWalkAnim;
								if (Eighties)
								{
									if (LectureID == 4)
									{
										if (StudentManager.Students[30] != null)
										{
											Debug.Log("Attempting to update Himedere's routine...");
											StudentManager.Students[30].Cosmetic.EnableRings();
											StudentManager.Students[30].Depressed = false;
										}
									}
									else if (LectureID == 6)
									{
										Debug.Log("Disabling the rival and her bag, since she was expelled.");
										StudentManager.Students[StudentManager.RivalID].gameObject.SetActive(value: false);
										if (StudentManager.Students[StudentManager.SuitorID] != null)
										{
											Debug.Log("Commanding the rival's suitor to stop trying to spy on her, since she's gone now.");
											StudentManager.Students[StudentManager.SuitorID].Curious = false;
										}
									}
									if (StudentManager.Students[StudentManager.RivalID] != null && !StudentManager.Students[StudentManager.RivalID].gameObject.activeInHierarchy)
									{
										Debug.Log("Disabling the rival's bag, since she was expelled.");
										StudentManager.GenericRivalBag.gameObject.SetActive(value: false);
										if (StudentManager.RivalID == 19)
										{
											StudentManager.RevertEightiesWeek9RoutineAdjustments();
										}
									}
								}
								else if (LectureID == 2)
								{
									if (StoleRing)
									{
										MustReturnStolenRing = true;
									}
								}
								else if (LectureID == 6 && StudentManager.RivalID == 11 && StudentManager.Students[10] != null)
								{
									StudentScript obj = StudentManager.Students[10];
									Debug.Log("Osana is gone, so Raibaru's routine has to change.");
									ScheduleBlock obj2 = obj.ScheduleBlocks[4];
									obj2.destination = "Mourn";
									obj2.action = "Mourn";
									ScheduleBlock obj3 = obj.ScheduleBlocks[5];
									obj3.destination = "Seat";
									obj3.action = "Sit";
									ScheduleBlock obj4 = obj.ScheduleBlocks[6];
									obj4.destination = "Locker";
									obj4.action = "Shoes";
									ScheduleBlock obj5 = obj.ScheduleBlocks[7];
									obj5.destination = "Exit";
									obj5.action = "Exit";
									ScheduleBlock obj6 = obj.ScheduleBlocks[8];
									obj6.destination = "Exit";
									obj6.action = "Exit";
									ScheduleBlock obj7 = obj.ScheduleBlocks[9];
									obj7.destination = "Exit";
									obj7.action = "Exit";
									obj.TargetDistance = 0.5f;
									obj.IdleAnim = obj.BulliedIdleAnim;
									obj.WalkAnim = obj.BulliedWalkAnim;
									obj.OriginalIdleAnim = obj.IdleAnim;
									obj.Pathfinding.speed = 1f;
									obj.GetDestinations();
								}
								LectureID = 0;
							}
						}
						else
						{
							Debug.Log("The police were present at school, so we're returning to the EndOfDay sequence now.");
							EndOfDay.Phase++;
							EndOfDay.UpdateScene();
						}
					}
				}
			}
		}
		if (!MyAudio.isPlaying)
		{
			CounselorSubtitle.text = string.Empty;
		}
		if (Interrogating)
		{
			UpdateInterrogation();
		}
	}

	public void Talk()
	{
		MyAnimation.CrossFade("CounselorComputerAttention", 1f);
		ChinTimer = 0f;
		Yandere.TargetStudent = Student;
		TalkTimer = 0f;
		StudentManager.DisablePrompts();
		CounselorWindow.gameObject.SetActive(value: true);
		LookAtPlayer = true;
		ShowWindow = true;
		Yandere.ShoulderCamera.OverShoulder = true;
		Yandere.WeaponMenu.KeyboardShow = false;
		Yandere.WeaponMenu.Show = false;
		Yandere.YandereVision = false;
		Yandere.CanMove = false;
		Yandere.Talking = true;
		PromptBar.ClearButtons();
		PromptBar.Label[0].text = "Accept";
		PromptBar.Label[4].text = "Choose";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		base.transform.position = new Vector3(-28.93333f, 0f, 12f);
		RedPen.SetActive(value: false);
		UpdateList();
	}

	private void UpdateList()
	{
		for (int i = 1; i < Labels.Length; i++)
		{
			UILabel uILabel = Labels[i];
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
		}
		if (!(StudentManager.Students[StudentManager.RivalID] != null))
		{
			return;
		}
		if (!Eighties)
		{
			if (SchemeGlobals.GetSchemeStage(1) == 8)
			{
				UILabel uILabel2 = Labels[1];
				uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, 1f);
			}
			if (SchemeGlobals.GetSchemeStage(2) == 6)
			{
				UILabel uILabel3 = Labels[2];
				uILabel3.color = new Color(uILabel3.color.r, uILabel3.color.g, uILabel3.color.b, 1f);
			}
			if (SchemeGlobals.GetSchemeStage(3) == 4)
			{
				UILabel uILabel4 = Labels[3];
				uILabel4.color = new Color(uILabel4.color.r, uILabel4.color.g, uILabel4.color.b, 1f);
			}
			if (SchemeGlobals.GetSchemeStage(4) == 7)
			{
				UILabel uILabel5 = Labels[4];
				uILabel5.color = new Color(uILabel5.color.r, uILabel5.color.g, uILabel5.color.b, 1f);
			}
			if (SchemeGlobals.GetSchemeStage(5) == 9)
			{
				UILabel uILabel6 = Labels[5];
				uILabel6.color = new Color(uILabel6.color.r, uILabel6.color.g, uILabel6.color.b, 1f);
			}
			return;
		}
		if (ReportedAlcohol)
		{
			Labels[1].text = "Already Reported Alcohol";
		}
		if (ReportedCondoms)
		{
			Labels[2].text = "Already Reported Condoms";
		}
		if (ReportedCigarettes)
		{
			Labels[3].text = "Already Reported Cigarettes";
		}
		if (ReportedTheft)
		{
			Labels[4].text = "Already Reported Theft";
		}
		if (ReportedCheating)
		{
			Labels[5].text = "Already Reported Cheating";
		}
		if (StudentManager.RivalBookBag.Alcohol && !ReportedAlcohol)
		{
			Labels[1].alpha = 1f;
		}
		if (StudentManager.RivalBookBag.Condoms && !ReportedCondoms)
		{
			Labels[2].alpha = 1f;
		}
		if (StudentManager.RivalBookBag.Cigarettes && !ReportedCigarettes)
		{
			Labels[3].alpha = 1f;
		}
		if ((StudentManager.RivalBookBag.StolenRing && !ReportedTheft) || (StudentManager.RivalBookBag.StolenProperty && !ReportedTheft))
		{
			Labels[4].alpha = 1f;
		}
		if (StudentManager.RivalBookBag.AnswerSheet && !ReportedCheating)
		{
			Labels[5].alpha = 1f;
		}
		if (StudentManager.RivalBookBag.Narcotics)
		{
			Labels[6].alpha = 1f;
		}
	}

	private void UpdateHighlight()
	{
		if (Selected < 1)
		{
			Selected = 7;
		}
		else if (Selected > 7)
		{
			Selected = 1;
		}
		if (Selected == 6)
		{
			NarcoticsWindow.gameObject.SetActive(value: true);
		}
		else
		{
			NarcoticsWindow.gameObject.SetActive(value: false);
		}
		Highlight.transform.localPosition = new Vector3(Highlight.transform.localPosition.x, 200f - 50f * (float)Selected, Highlight.transform.localPosition.z);
	}

	private void LateUpdate()
	{
		if (!(Vector3.Distance(base.transform.position, Yandere.transform.position) < 5f))
		{
			return;
		}
		if (Angry)
		{
			BS_SadMouth = Mathf.Lerp(BS_SadMouth, 100f, Time.deltaTime * 10f);
			BS_MadBrow = Mathf.Lerp(BS_MadBrow, 100f, Time.deltaTime * 10f);
			BS_SadBrow = Mathf.Lerp(BS_SadBrow, 0f, Time.deltaTime * 10f);
			BS_AngryEyes = Mathf.Lerp(BS_AngryEyes, 100f, Time.deltaTime * 10f);
		}
		else if (Stern)
		{
			BS_SadMouth = Mathf.Lerp(BS_SadMouth, 0f, Time.deltaTime * 10f);
			BS_MadBrow = Mathf.Lerp(BS_MadBrow, 100f, Time.deltaTime * 10f);
			BS_SadBrow = Mathf.Lerp(BS_SadBrow, 0f, Time.deltaTime * 10f);
			BS_AngryEyes = Mathf.Lerp(BS_AngryEyes, 0f, Time.deltaTime * 10f);
		}
		else if (Sad)
		{
			BS_SadMouth = Mathf.Lerp(BS_SadMouth, 100f, Time.deltaTime * 10f);
			BS_MadBrow = Mathf.Lerp(BS_MadBrow, 0f, Time.deltaTime * 10f);
			BS_SadBrow = Mathf.Lerp(BS_SadBrow, 100f, Time.deltaTime * 10f);
			BS_AngryEyes = Mathf.Lerp(BS_AngryEyes, 0f, Time.deltaTime * 10f);
		}
		else
		{
			BS_SadMouth = Mathf.Lerp(BS_SadMouth, 0f, Time.deltaTime * 10f);
			BS_MadBrow = Mathf.Lerp(BS_MadBrow, 0f, Time.deltaTime * 10f);
			BS_SadBrow = Mathf.Lerp(BS_SadBrow, 0f, Time.deltaTime * 10f);
			BS_AngryEyes = Mathf.Lerp(BS_AngryEyes, 0f, Time.deltaTime * 10f);
		}
		if (EightiesAttacher.gameObject.activeInHierarchy && !UpdatedFace)
		{
			UpdatedFace = true;
			Face = PelvisRoot.GetChild(1).GetComponent<SkinnedMeshRenderer>();
		}
		else if (ModernAttacher.gameObject.activeInHierarchy && !UpdatedFace)
		{
			UpdatedFace = true;
			Face = PelvisRoot.GetChild(1).GetComponent<SkinnedMeshRenderer>();
		}
		Face.SetBlendShapeWeight(SadMouthID, BS_SadMouth);
		Face.SetBlendShapeWeight(MadBrowID, BS_MadBrow);
		Face.SetBlendShapeWeight(SadBrowID, BS_SadBrow);
		Face.SetBlendShapeWeight(AngryEyesID, BS_AngryEyes);
		if (MyAudio.isPlaying)
		{
			if (InterrogationPhase != 6)
			{
				MouthTimer += Time.deltaTime;
				if (MouthTimer > TimerLimit)
				{
					MouthTarget = Random.Range(0f, 100f);
					MouthTimer = 0f;
				}
				MouthOpen = Mathf.Lerp(MouthOpen, MouthTarget, Time.deltaTime * TalkSpeed);
			}
			else
			{
				MouthOpen = Mathf.Lerp(MouthOpen, 0f, Time.deltaTime * TalkSpeed);
			}
		}
		else
		{
			MouthOpen = Mathf.Lerp(MouthOpen, 0f, Time.deltaTime * TalkSpeed);
		}
		Face.SetBlendShapeWeight(MouthOpenID, MouthOpen);
		LookAtTarget = Vector3.Lerp(LookAtTarget, LookAtPlayer ? Yandere.Head.position : Default.position, Time.deltaTime * 2f);
		Head.LookAt(LookAtTarget);
	}

	public void Quit()
	{
		if (WeaponToReturn != null)
		{
			WeaponToReturn.Drop();
			if (WeaponToReturn.Dangerous)
			{
				WeaponToReturn.transform.position = StudentManager.WeaponBoxSpot.parent.position + new Vector3(0f, 1f, 0f);
				WeaponToReturn.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			else
			{
				WeaponToReturn.transform.position = WeaponToReturn.Origin.position;
				WeaponToReturn.transform.eulerAngles = WeaponToReturn.Origin.eulerAngles;
			}
			WeaponToReturn.MyRigidbody.useGravity = true;
			WeaponToReturn.MyRigidbody.isKinematic = false;
			WeaponToReturn = null;
		}
		Debug.Log("CounselorScript has called the Quit() function.");
		bool noticed = Yandere.ShoulderCamera.Noticed;
		CounselorSubtitle.text = "";
		if (StudentManager.Students[1] != null)
		{
			Yandere.Senpai = StudentManager.Students[1].transform;
		}
		Yandere.PauseScreen.Hint.MyPanel.alpha = 1f;
		Yandere.DetectionPanel.alpha = 1f;
		Yandere.RPGCamera.mouseSpeed = 8f;
		Yandere.HUD.alpha = 1f;
		Yandere.SuspiciousActionTimer = 0f;
		Yandere.WeaponTimer = 0f;
		Yandere.TheftTimer = 0f;
		Yandere.HeartRate.gameObject.SetActive(value: true);
		Yandere.Subtitle.gameObject.SetActive(value: true);
		Yandere.CannotRecover = false;
		Yandere.Noticed = false;
		Yandere.Talking = true;
		Yandere.ShoulderCamera.GoingToCounselor = false;
		Yandere.ShoulderCamera.HUD.SetActive(value: true);
		Yandere.ShoulderCamera.Noticed = false;
		Yandere.ShoulderCamera.enabled = true;
		Yandere.TargetStudent = Student;
		if (!Yandere.Jukebox.FullSanity.isPlaying)
		{
			Yandere.Jukebox.FullSanity.volume = 0f;
			Yandere.Jukebox.HalfSanity.volume = 0f;
			Yandere.Jukebox.NoSanity.volume = 0f;
			Yandere.Jukebox.FullSanity.Play();
			Yandere.Jukebox.HalfSanity.Play();
			Yandere.Jukebox.NoSanity.Play();
		}
		Yandere.transform.position = new Vector3(-21.5f, 0f, 8f);
		Yandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
		Yandere.ShoulderCamera.OverShoulder = false;
		CounselorBar.SetActive(value: false);
		StudentManager.EnablePrompts();
		if (!EightiesAttacher.gameObject.activeInHierarchy)
		{
			Laptop.SetActive(value: true);
		}
		else
		{
			MyAnimation.CrossFade("f02_deskWritePingPong_00");
			base.transform.position += new Vector3(0f, -0.1f, 0f);
			RedPen.SetActive(value: true);
		}
		LookAtPlayer = false;
		ShowWindow = false;
		TalkTimer = 1f;
		Patience = 0;
		Stern = false;
		Angry = false;
		Sad = false;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		if (!StudentManager.TutorialActive)
		{
			StudentManager.ComeBack();
		}
		StudentManager.GracePeriod(10f);
		if (noticed)
		{
			StudentManager.Reputation.UpdateRep();
		}
		Yandere.CameraEffects.UpdateDOF(2f);
		Physics.SyncTransforms();
	}

	private void UpdateInterrogation()
	{
		if (VibrationCheck)
		{
			VibrationTimer = Mathf.MoveTowards(VibrationTimer, 0f, Time.deltaTime);
			if (VibrationTimer == 0f)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				VibrationCheck = false;
			}
		}
		Timer += Time.deltaTime;
		if (Input.GetButtonDown(InputNames.Xbox_A) && InterrogationPhase != 4)
		{
			Timer += 20f;
		}
		if (InterrogationPhase == 0)
		{
			if (Timer > 1f || Input.GetButtonDown(InputNames.Xbox_A))
			{
				Debug.Log("Previous Punishments: " + CounselorPunishments);
				Patience -= CounselorPunishments;
				if (Patience < -6)
				{
					Patience = -6;
				}
				GenkaChibi.transform.localPosition = new Vector3(0f, 90 * Patience, 0f);
				Yandere.MainCamera.transform.eulerAngles = CameraTarget.eulerAngles;
				Yandere.MainCamera.transform.position = CameraTarget.position;
				Yandere.MainCamera.transform.Translate(Vector3.forward * -1f);
				if (CounselorVisits < 3)
				{
					CounselorVisits++;
				}
				if (CounselorTape == 0)
				{
					CounselorOption[4].Label.color = new Color(0f, 0f, 0f, 0.5f);
				}
				else
				{
					CounselorOption[4].Label.color = new Color(0f, 0f, 0f, 1f);
					CounselorOption[4].Label.text = "Blame Delinquents";
				}
				if (Yandere.Subtitle.CurrentClip != null)
				{
					Object.Destroy(Yandere.Subtitle.CurrentClip);
				}
				Yandere.CameraEffects.UpdateDOF(1.1f);
				GenkaChibi.mainTexture = AnnoyedChibi;
				CounselorBar.SetActive(value: true);
				Subtitle.Label.text = "";
				InterrogationPhase++;
				Time.timeScale = 1f;
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 1)
		{
			Yandere.Police.Darkness.color -= new Color(0f, 0f, 0f, Time.deltaTime);
			Yandere.MainCamera.transform.position = Vector3.Lerp(Yandere.MainCamera.transform.position, CameraTarget.position, Timer * Time.deltaTime * 0.5f);
			if (Timer > 5f || Input.GetButtonDown(InputNames.Xbox_A))
			{
				Yandere.MainCamera.transform.position = CameraTarget.position;
				MyAudio.clip = GreetingClips[CounselorVisits];
				CounselorSubtitle.text = Greetings[CounselorVisits];
				Yandere.Police.Darkness.color = new Color(0f, 0f, 0f, 0f);
				InterrogationPhase++;
				MyAudio.Play();
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 2)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				MyAudio.Stop();
			}
			if (Timer > MyAudio.clip.length + 0.5f)
			{
				if (Crime == StudentWitnessType.Blood || Crime == StudentWitnessType.BloodAndInsanity)
				{
					MyAudio.clip = BloodLectureClips[BloodVisits];
					CounselorSubtitle.text = BloodLectures[BloodVisits];
					if (BloodVisits < 2)
					{
						BloodVisits++;
					}
					CrimeID = 1;
				}
				else if (Crime == StudentWitnessType.Insanity || Crime == StudentWitnessType.CleaningItem || Crime == StudentWitnessType.HoldingBloodyClothing || Crime == StudentWitnessType.Poisoning || Crime == StudentWitnessType.Stalking)
				{
					MyAudio.clip = InsanityLectureClips[InsanityVisits];
					CounselorSubtitle.text = InsanityLectures[InsanityVisits];
					if (InsanityVisits < 2)
					{
						InsanityVisits++;
					}
					CrimeID = 2;
				}
				else if (Crime == StudentWitnessType.Lewd)
				{
					MyAudio.clip = LewdLectureClips[LewdVisits];
					CounselorSubtitle.text = LewdLectures[LewdVisits];
					if (LewdVisits < 2)
					{
						LewdVisits++;
					}
					CrimeID = 3;
				}
				else if (Crime == StudentWitnessType.Theft || Crime == StudentWitnessType.Pickpocketing)
				{
					MyAudio.clip = TheftLectureClips[TheftVisits];
					CounselorSubtitle.text = TheftLectures[TheftVisits];
					if (TheftVisits < 2)
					{
						TheftVisits++;
					}
					CrimeID = 4;
				}
				else if (Crime == StudentWitnessType.Trespassing)
				{
					MyAudio.clip = TrespassLectureClips[TrespassVisits];
					CounselorSubtitle.text = TrespassLectures[TrespassVisits];
					if (TrespassVisits < 2)
					{
						TrespassVisits++;
					}
					CrimeID = 5;
				}
				else if (Crime == StudentWitnessType.Weapon || Crime == StudentWitnessType.WeaponAndBlood || Crime == StudentWitnessType.WeaponAndInsanity || Crime == StudentWitnessType.WeaponAndBloodAndInsanity)
				{
					MyAudio.clip = WeaponLectureClips[WeaponVisits];
					CounselorSubtitle.text = WeaponLectures[WeaponVisits];
					if (WeaponVisits < 2)
					{
						WeaponVisits++;
					}
					CrimeID = 6;
				}
				InterrogationPhase++;
				MyAudio.Play();
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 3)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				MyAudio.Stop();
			}
			if (Timer > MyAudio.clip.length + 0.5f)
			{
				for (int i = 1; i < 7; i++)
				{
					CounselorOption[i].transform.localPosition = CounselorOption[i].OriginalPosition;
					CounselorOption[i].Sprite.color = CounselorOption[i].OriginalColor;
					CounselorOption[i].transform.localScale = new Vector3(0.9f, 0.9f, 1f);
					CounselorOption[i].gameObject.SetActive(value: true);
					CounselorOption[i].Clicked = false;
				}
				Yandere.CharacterAnimation["f02_countdown_00"].speed = 1f;
				Yandere.CharacterAnimation.Play("f02_countdown_00");
				Yandere.transform.position = new Vector3(-27.818f, 0f, 12f);
				Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				Yandere.MainCamera.transform.position = new Vector3(-28f, 1.1f, 12f);
				Yandere.MainCamera.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				Reticle.transform.localPosition = new Vector3(0f, 0f, 0f);
				CounselorOptions.SetActive(value: true);
				CounselorBar.SetActive(value: false);
				CounselorSubtitle.text = "";
				MyAudio.clip = Countdown;
				MyAudio.Play();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[4].text = "Choose";
				PromptBar.Label[5].text = "Choose";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Yandere.CameraEffects.UpdateDOF(0.4f);
				InterrogationPhase++;
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 4)
		{
			Yandere.MainCamera.transform.Translate(Vector3.forward * Time.deltaTime * 0.01f);
			CounselorOptions.transform.localEulerAngles += new Vector3(0f, 0f, Time.deltaTime * -36f);
			if (InputDevice.Type == InputDeviceType.Gamepad)
			{
				Reticle.SetActive(value: true);
				Cursor.visible = false;
				Reticle.transform.localPosition += new Vector3(Input.GetAxis("Horizontal") * 1500f * Time.deltaTime, Input.GetAxis("Vertical") * 1500f * Time.deltaTime, 0f);
			}
			else
			{
				Reticle.SetActive(value: true);
				Cursor.visible = true;
				Reticle.transform.localPosition += new Vector3(Input.GetAxis("Horizontal") * 1500f * Time.deltaTime, Input.GetAxis("Vertical") * 1500f * Time.deltaTime, 0f);
				if (Input.GetKey("up"))
				{
					Reticle.transform.localPosition += new Vector3(0f, 1500f * Time.deltaTime, 0f);
				}
				if (Input.GetKey("down"))
				{
					Reticle.transform.localPosition -= new Vector3(0f, 1500f * Time.deltaTime, 0f);
				}
				if (Input.GetKey("right"))
				{
					Reticle.transform.localPosition += new Vector3(1500f * Time.deltaTime, 0f, 0f);
				}
				if (Input.GetKey("left"))
				{
					Reticle.transform.localPosition -= new Vector3(1500f * Time.deltaTime, 0f, 0f);
				}
			}
			if (Reticle.transform.localPosition.x > 975f)
			{
				Reticle.transform.localPosition = new Vector3(975f, Reticle.transform.localPosition.y, Reticle.transform.localPosition.z);
			}
			if (Reticle.transform.localPosition.x < -975f)
			{
				Reticle.transform.localPosition = new Vector3(-975f, Reticle.transform.localPosition.y, Reticle.transform.localPosition.z);
			}
			if (Reticle.transform.localPosition.y > 525f)
			{
				Reticle.transform.localPosition = new Vector3(Reticle.transform.localPosition.x, 525f, Reticle.transform.localPosition.z);
			}
			if (Reticle.transform.localPosition.y < -525f)
			{
				Reticle.transform.localPosition = new Vector3(Reticle.transform.localPosition.x, -525f, Reticle.transform.localPosition.z);
			}
			for (int j = 1; j < 7; j++)
			{
				CounselorOption[j].transform.eulerAngles = new Vector3(CounselorOption[j].transform.eulerAngles.x, CounselorOption[j].transform.eulerAngles.y, 0f);
				if (!CounselorOption[j].Clicked && (!(CounselorOption[j].Sprite.color != CounselorOption[j].OriginalColor) || !Input.GetButtonDown(InputNames.Xbox_A)))
				{
					continue;
				}
				for (int k = 1; k < 7; k++)
				{
					if (k != j)
					{
						CounselorOption[k].gameObject.SetActive(value: false);
					}
				}
				Yandere.CharacterAnimation["f02_countdown_00"].time = 10f;
				MyAudio.clip = Choice;
				MyAudio.pitch = 1f;
				MyAudio.Play();
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Reticle.SetActive(value: false);
				InterrogationPhase++;
				Answer = j;
				Timer = 0f;
				PromptBar.ClearButtons();
			}
			if (Timer > 10f)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Reticle.SetActive(value: false);
				SilentTreatment = true;
				InterrogationPhase++;
				Timer = 0f;
				PromptBar.ClearButtons();
			}
		}
		else if (InterrogationPhase == 5)
		{
			int l = 1;
			if (SilentTreatment)
			{
				CounselorOptions.transform.localScale += new Vector3(Time.deltaTime * 2f, Time.deltaTime * 2f, Time.deltaTime * 2f);
				for (; l < 7; l++)
				{
					CounselorOption[l].transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
				}
			}
			if (Timer > 3f || Input.GetButtonDown(InputNames.Xbox_A))
			{
				CounselorOptions.transform.localScale = new Vector3(1f, 1f, 1f);
				CounselorOptions.SetActive(value: false);
				CounselorBar.SetActive(value: true);
				Yandere.CameraEffects.UpdateDOF(1.1f);
				Yandere.transform.position = new Vector3(-27.51f, 0f, 12f);
				Yandere.MainCamera.transform.position = CameraTarget.position;
				Yandere.MainCamera.transform.eulerAngles = CameraTarget.eulerAngles;
				if (SilentTreatment)
				{
					MyAudio.clip = Silence;
					CounselorSubtitle.text = "...";
				}
				else if (Answer == 1)
				{
					MyAudio.clip = ExcuseClips[CrimeID];
					CounselorSubtitle.text = Excuses[CrimeID];
					if (CrimeID == 1)
					{
						BloodExcuseUsed++;
					}
					else if (CrimeID == 2)
					{
						InsanityExcuseUsed++;
					}
					else if (CrimeID == 3)
					{
						LewdExcuseUsed++;
					}
					else if (CrimeID == 4)
					{
						TheftExcuseUsed++;
					}
					else if (CrimeID == 5)
					{
						TrespassExcuseUsed++;
					}
					else if (CrimeID == 6)
					{
						WeaponExcuseUsed++;
					}
				}
				else if (Answer == 2)
				{
					MyAudio.clip = ApologyClip;
					CounselorSubtitle.text = Apology;
					ApologiesUsed++;
				}
				else if (Answer == 3)
				{
					MyAudio.clip = LieClips[CrimeID];
					CounselorSubtitle.text = Lies[CrimeID];
				}
				else if (Answer == 4)
				{
					MyAudio.clip = DelinquentClips[CrimeID];
					CounselorSubtitle.text = Delinquents[CrimeID];
				}
				else if (Answer == 5)
				{
					MyAudio.clip = FlirtClip;
					CounselorSubtitle.text = Flirt;
				}
				else if (Answer == 6)
				{
					MyAudio.clip = ThreatenClip;
					CounselorSubtitle.text = Threaten;
				}
				Yandere.CharacterAnimation.Play("f02_sit_00");
				InterrogationPhase++;
				MyAudio.Play();
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 6)
		{
			if (Answer == 6)
			{
				Yandere.Sanity = Mathf.MoveTowards(Yandere.Sanity, 0f, Time.deltaTime * 7.5f);
				Rumble.volume += Time.deltaTime * 0.075f;
			}
			if (Timer > MyAudio.clip.length + 0.5f || Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (SilentTreatment)
				{
					int num = Random.Range(0, 3);
					MyAudio.clip = SilentClips[num];
					CounselorSubtitle.text = Silents[num];
					Patience--;
				}
				else if (Answer == 1)
				{
					if (CrimeID == 1)
					{
						Debug.Log("The player's crime is Bloodiness.");
					}
					else if (CrimeID == 2)
					{
						Debug.Log("The player's crime is Insanity.");
					}
					else if (CrimeID == 3)
					{
						Debug.Log("The player's crime is Lewdness.");
					}
					else if (CrimeID == 4)
					{
						Debug.Log("The player's crime is Theft.");
					}
					else if (CrimeID == 5)
					{
						Debug.Log("The player's crime is Trespassing.");
					}
					else if (CrimeID == 6)
					{
						Debug.Log("The player's crime is Weaponry.");
					}
					Debug.Log("The player has chosen to use an exuse.");
					bool flag = false;
					if ((CrimeID == 1 && BloodExcuseUsed > 1) || (CrimeID == 2 && InsanityExcuseUsed > 1) || (CrimeID == 3 && LewdExcuseUsed > 1) || (CrimeID == 4 && TheftExcuseUsed > 1) || (CrimeID == 5 && TrespassExcuseUsed > 1) || (CrimeID == 6 && WeaponExcuseUsed > 1))
					{
						Debug.Log("Yandere-chan has already used this excuse before.");
						flag = true;
					}
					if (!flag)
					{
						Debug.Log("Yandere-chan's excuse is not invalid!");
						MyAudio.clip = AcceptExcuseClips[CrimeID];
						CounselorSubtitle.text = AcceptExcuses[CrimeID];
						MyAnimation.CrossFade("CounselorRelief", 1f);
						Stern = false;
						Patience = 1;
					}
					else
					{
						Debug.Log("Yandere-chan's excuse has been deemed invalid.");
						int num2 = Random.Range(0, 3);
						MyAudio.clip = RejectExcuseClips[num2];
						CounselorSubtitle.text = RejectExcuses[num2];
						MyAnimation.CrossFade("CounselorAnnoyed");
						Angry = true;
						Patience--;
					}
				}
				else if (Answer == 2)
				{
					if (ApologiesUsed == 1)
					{
						MyAudio.clip = AcceptApologyClip;
						CounselorSubtitle.text = AcceptApology;
						MyAnimation.CrossFade("CounselorRelief", 1f);
						Stern = false;
						Patience = 1;
					}
					else
					{
						int num3 = Random.Range(0, 3);
						MyAudio.clip = RejectApologyClips[num3];
						CounselorSubtitle.text = RejectApologies[num3];
						MyAnimation.CrossFade("CounselorAnnoyed");
						Patience--;
					}
				}
				else if (Answer == 3)
				{
					int num4 = Random.Range(0, 5);
					MyAudio.clip = RejectLieClips[num4];
					CounselorSubtitle.text = RejectLies[num4];
					MyAnimation.CrossFade("CounselorAnnoyed");
					Angry = true;
					Patience--;
				}
				else if (Answer == 4)
				{
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					int num5 = 5;
					if (StudentGlobals.GetStudentDead(76) && StudentGlobals.GetStudentDead(77) && StudentGlobals.GetStudentDead(78) && StudentGlobals.GetStudentDead(79) && StudentGlobals.GetStudentDead(80))
					{
						flag4 = true;
					}
					else if (StudentGlobals.GetStudentExpelled(76) && StudentGlobals.GetStudentExpelled(77) && StudentGlobals.GetStudentExpelled(78) && StudentGlobals.GetStudentExpelled(79) && StudentGlobals.GetStudentExpelled(80))
					{
						flag3 = true;
					}
					else
					{
						if (StudentManager.Students[76] == null)
						{
							num5--;
						}
						else if (!StudentManager.Students[76].gameObject.activeInHierarchy)
						{
							num5--;
						}
						if (StudentManager.Students[77] == null)
						{
							num5--;
						}
						else if (!StudentManager.Students[77].gameObject.activeInHierarchy)
						{
							num5--;
						}
						if (StudentManager.Students[78] == null)
						{
							num5--;
						}
						else if (!StudentManager.Students[78].gameObject.activeInHierarchy)
						{
							num5--;
						}
						if (StudentManager.Students[79] == null)
						{
							num5--;
						}
						else if (!StudentManager.Students[79].gameObject.activeInHierarchy)
						{
							num5--;
						}
						if (StudentManager.Students[80] == null)
						{
							num5--;
						}
						else if (!StudentManager.Students[80].gameObject.activeInHierarchy)
						{
							num5--;
						}
						if (num5 == 0)
						{
							flag2 = true;
						}
					}
					bool flag5 = false;
					if ((CrimeID == 1 && BloodBlameUsed > 1) || (CrimeID == 2 && InsanityBlameUsed > 1) || (CrimeID == 3 && LewdBlameUsed > 1) || (CrimeID == 4 && TheftBlameUsed > 1) || (CrimeID == 5 && TrespassBlameUsed > 1) || (CrimeID == 6 && WeaponBlameUsed > 1))
					{
						flag5 = true;
					}
					if (flag4)
					{
						MyAudio.clip = DelinquentsDeadClip;
						CounselorSubtitle.text = DelinquentsDead;
						MyAnimation.CrossFade("CounselorAnnoyed");
						Angry = true;
						Patience--;
					}
					else if (flag3)
					{
						MyAudio.clip = DelinquentsExpelledClip;
						CounselorSubtitle.text = DelinquentsExpelled;
						MyAnimation.CrossFade("CounselorAnnoyed");
						Patience--;
					}
					else if (flag2)
					{
						MyAudio.clip = DelinquentsGoneClip;
						CounselorSubtitle.text = DelinquentsGone;
						MyAnimation.CrossFade("CounselorAnnoyed");
						Patience--;
					}
					else if (!flag5)
					{
						if (CrimeID == 1)
						{
							Debug.Log("Banning weapons.");
							WeaponsBanned++;
						}
						MyAudio.clip = AcceptBlameClips[CrimeID];
						CounselorSubtitle.text = AcceptBlames[CrimeID];
						MyAnimation.CrossFade("CounselorSad", 1f);
						Stern = false;
						Sad = true;
						Patience = 1;
						DelinquentPunishments++;
						if (CrimeID == 1)
						{
							BloodBlameUsed++;
						}
						else if (CrimeID == 2)
						{
							InsanityBlameUsed++;
						}
						else if (CrimeID == 3)
						{
							LewdBlameUsed++;
						}
						else if (CrimeID == 4)
						{
							TheftBlameUsed++;
						}
						else if (CrimeID == 5)
						{
							TrespassBlameUsed++;
						}
						else if (CrimeID == 6)
						{
							WeaponBlameUsed++;
						}
						if (DelinquentPunishments > 5)
						{
							MustExpelDelinquents = true;
						}
					}
					else
					{
						int num6 = Random.Range(0, 3);
						MyAudio.clip = RejectBlameClips[num6];
						CounselorSubtitle.text = RejectBlames[num6];
						MyAnimation.CrossFade("CounselorAnnoyed");
						Patience--;
					}
				}
				else if (Answer == 5)
				{
					int num7 = Random.Range(0, 3);
					MyAudio.clip = RejectFlirtClips[num7];
					CounselorSubtitle.text = RejectFlirts[num7];
					MyAnimation.CrossFade("CounselorAnnoyed");
					Angry = true;
					Patience--;
				}
				else if (Answer == 6)
				{
					MyAudio.clip = RejectThreatClip;
					CounselorSubtitle.text = RejectThreat;
					MyAnimation.CrossFade("CounselorAnnoyed");
					InterrogationPhase += 2;
					Patience = -6;
					Angry = true;
				}
				if (Patience < -6)
				{
					Patience = -6;
				}
				if (Patience == 1)
				{
					GenkaChibi.mainTexture = HappyChibi;
				}
				else if (Patience == -6)
				{
					GenkaChibi.mainTexture = MadChibi;
				}
				else
				{
					GenkaChibi.mainTexture = AnnoyedChibi;
				}
				InterrogationPhase++;
				MyAudio.Play();
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 7)
		{
			if (Timer > MyAudio.clip.length + 0.5f || Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (Patience < 0)
				{
					int num8 = Random.Range(0, 3);
					MyAudio.clip = BadClosingClips[num8];
					CounselorSubtitle.text = BadClosings[num8];
					MyAnimation.CrossFade("CounselorArmsCrossed", 1f);
					InterrogationPhase += 2;
				}
				else
				{
					if (MustExpelDelinquents)
					{
						MyAudio.clip = ExpelDelinquentsClip;
						CounselorSubtitle.text = ExpelDelinquents;
						MustExpelDelinquents = false;
						StudentManager.Students[76].gameObject.SetActive(value: false);
						StudentManager.Students[77].gameObject.SetActive(value: false);
						StudentManager.Students[78].gameObject.SetActive(value: false);
						StudentManager.Students[79].gameObject.SetActive(value: false);
						StudentManager.Students[80].gameObject.SetActive(value: false);
						ExpelledDelinquents = true;
						DelinquentRadio.SetActive(value: false);
					}
					else if (Answer == 4)
					{
						MyAudio.clip = BlameClosingClips[CrimeID];
						CounselorSubtitle.text = BlameClosings[CrimeID];
					}
					else
					{
						int num9 = Random.Range(0, 3);
						MyAudio.clip = FreeToLeaveClips[num9];
						CounselorSubtitle.text = FreeToLeaves[num9];
						MyAnimation.CrossFade("CounselorArmsCrossed", 1f);
						Stern = true;
					}
					InterrogationPhase++;
				}
				MyAudio.Play();
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 8)
		{
			if (Timer > MyAudio.clip.length + 0.5f || Input.GetButtonDown(InputNames.Xbox_A))
			{
				CounselorDoor.FadeOut = true;
				CounselorDoor.Exit = true;
				Interrogating = false;
				InterrogationPhase = 0;
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 9)
		{
			if (Timer > MyAudio.clip.length + 0.5f || Input.GetButtonDown(InputNames.Xbox_A))
			{
				MyAnimation.Play("CounselorSlamDesk");
				InterrogationPhase++;
				MyAudio.Stop();
				Stern = false;
				Angry = true;
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 10)
		{
			if (Timer > 0.5f)
			{
				if (!Slammed)
				{
					GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
					VibrationCheck = true;
					VibrationTimer = 0.2f;
					AudioSource.PlayClipAtPoint(Slam, base.transform.position);
					Shake.shakeAmount = 0.1f;
					Shake.enabled = true;
					Shake.shake = 0.5f;
					Slammed = true;
				}
				Shake.shakeAmount = Mathf.Lerp(Shake.shakeAmount, 0f, Time.deltaTime);
			}
			Shake.shakeAmount = Mathf.Lerp(Shake.shakeAmount, 0f, Time.deltaTime * 10f);
			if (Timer > 1.5f || Input.GetButtonDown(InputNames.Xbox_A))
			{
				MyAudio.clip = SuspensionClips[Mathf.Abs(Patience)];
				CounselorSubtitle.text = Suspensions[Mathf.Abs(Patience)];
				MyAnimation.Play("CounselorSlamIdle");
				Shake.enabled = false;
				InterrogationPhase++;
				SentHome = true;
				MyAudio.Play();
				Timer = 0f;
			}
		}
		else if (InterrogationPhase == 11 && (Timer > MyAudio.clip.length + 0.5f || Input.GetButtonDown(InputNames.Xbox_A)) && !Yandere.Police.FadeOut)
		{
			PromptBar.Show = false;
			CounselorPunishments++;
			Yandere.Police.Darkness.color = new Color(0f, 0f, 0f, 0f);
			Yandere.Police.SuspensionLength = Mathf.Abs(Patience);
			Yandere.Police.Darkness.enabled = true;
			Yandere.Police.ClubActivity = false;
			Yandere.Police.Suspended = true;
			Yandere.Police.FadeOut = true;
			Yandere.Police.HiddenCorpses = 0;
			if (Yandere.Police.Corpses > 0)
			{
				Yandere.ShoulderCamera.GoingToCounselor = true;
			}
			Yandere.ShoulderCamera.HUD.SetActive(value: true);
			InterrogationPhase++;
			if (Patience == -6)
			{
				Expelled = true;
			}
			Timer = 0f;
			Yandere.Senpai = StudentManager.Students[1].transform;
			StudentManager.Reputation.PendingRep -= 10f;
			StudentManager.Reputation.UpdateRep();
		}
		if (InterrogationPhase > 6)
		{
			Yandere.Sanity = Mathf.Lerp(Yandere.Sanity, 100f, Time.deltaTime);
			Rumble.volume = Mathf.Lerp(Rumble.volume, 0f, Time.deltaTime);
			GenkaChibi.transform.localPosition = Vector3.Lerp(GenkaChibi.transform.localPosition, new Vector3(0f, 90 * Patience, 0f), Time.deltaTime * 10f);
		}
	}

	public void SaveExcusesUsed()
	{
		CounselorGlobals.BloodExcuseUsed = BloodExcuseUsed;
		CounselorGlobals.InsanityExcuseUsed = InsanityExcuseUsed;
		CounselorGlobals.LewdExcuseUsed = LewdExcuseUsed;
		CounselorGlobals.TheftExcuseUsed = TheftExcuseUsed;
		CounselorGlobals.TrespassExcuseUsed = TrespassExcuseUsed;
		CounselorGlobals.WeaponExcuseUsed = WeaponExcuseUsed;
	}

	public void LoadExcusesUsed()
	{
		BloodExcuseUsed = CounselorGlobals.BloodExcuseUsed;
		InsanityExcuseUsed = CounselorGlobals.InsanityExcuseUsed;
		LewdExcuseUsed = CounselorGlobals.LewdExcuseUsed;
		TheftExcuseUsed = CounselorGlobals.TheftExcuseUsed;
		TrespassExcuseUsed = CounselorGlobals.TrespassExcuseUsed;
		WeaponExcuseUsed = CounselorGlobals.WeaponExcuseUsed;
	}

	public void SaveCounselorData()
	{
		CounselorGlobals.CounselorPunishments = CounselorPunishments;
		CounselorGlobals.CounselorVisits = CounselorVisits;
		CounselorGlobals.CounselorTape = CounselorTape;
		CounselorGlobals.BloodVisits = BloodVisits;
		CounselorGlobals.InsanityVisits = InsanityVisits;
		CounselorGlobals.LewdVisits = LewdVisits;
		CounselorGlobals.TheftVisits = TheftVisits;
		CounselorGlobals.TrespassVisits = TrespassVisits;
		CounselorGlobals.WeaponVisits = WeaponVisits;
		CounselorGlobals.BloodBlameUsed = BloodBlameUsed;
		CounselorGlobals.InsanityBlameUsed = InsanityBlameUsed;
		CounselorGlobals.LewdBlameUsed = LewdBlameUsed;
		CounselorGlobals.TheftBlameUsed = TheftBlameUsed;
		CounselorGlobals.TrespassBlameUsed = TrespassBlameUsed;
		CounselorGlobals.WeaponBlameUsed = WeaponBlameUsed;
		CounselorGlobals.ApologiesUsed = ApologiesUsed;
		CounselorGlobals.WeaponsBanned = WeaponsBanned;
		CounselorGlobals.DelinquentPunishments = DelinquentPunishments;
	}

	public void ExpelStudents()
	{
		if (ExpelledDelinquents)
		{
			StudentGlobals.SetStudentExpelled(76, value: true);
			StudentGlobals.SetStudentExpelled(77, value: true);
			StudentGlobals.SetStudentExpelled(78, value: true);
			StudentGlobals.SetStudentExpelled(79, value: true);
			StudentGlobals.SetStudentExpelled(80, value: true);
		}
	}

	public void SilenceClips(AudioClip[] ClipArray)
	{
		for (int i = 0; i < 11; i++)
		{
			if (i < ClipArray.Length)
			{
				ClipArray[i] = LongestSilence;
			}
		}
	}

	public void SpawnDelinquents()
	{
		for (int i = 1; i < 6; i++)
		{
			if (StudentManager.Students[75 + i] != null)
			{
				StudentManager.Students[75 + i].Spawned = true;
			}
		}
	}
}
