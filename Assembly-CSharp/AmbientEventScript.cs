using System;
using UnityEngine;

public class AmbientEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public AmbientEventScript GrudgeReaction;

	public AmbientEventScript PoliceReaction;

	public HidingSpotScript HidingSpot;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript[] EventStudent;

	public Transform[] EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] EventSpeaker;

	public GameObject VoiceClip;

	public bool GrudgeConversation;

	public bool RotateSpine;

	public bool Sitting;

	public bool EventOn;

	public bool Spoken;

	public bool Private;

	public int EventPhase;

	public float StartTime = 13.001f;

	public float Delay = 0.5f;

	public float Timer;

	public float Scale;

	public int[] StudentID;

	public DayOfWeek EventDay;

	public float MouthTimer;

	public float MouthTarget;

	public float MouthExtent;

	public float TimerLimit = 0.1f;

	public float TalkSpeed;

	public float LipStrength;

	private void Start()
	{
		if (Sitting)
		{
			if (DateGlobals.Weekday != EventDay || GameGlobals.Eighties)
			{
				base.gameObject.SetActive(value: false);
				base.enabled = false;
			}
			else if ((!GameGlobals.GrudgeConversationHappened && StudentGlobals.GetStudentGrudge(2)) || (!GameGlobals.GrudgeConversationHappened && StudentGlobals.GetStudentGrudge(3)))
			{
				EventClip = GrudgeReaction.EventClip;
				EventSpeech = GrudgeReaction.EventSpeech;
				EventSpeaker = GrudgeReaction.EventSpeaker;
				GrudgeConversation = true;
			}
			else if (GameGlobals.PoliceYesterday)
			{
				EventClip = PoliceReaction.EventClip;
				EventSpeech = PoliceReaction.EventSpeech;
				EventSpeaker = PoliceReaction.EventSpeaker;
			}
		}
		else if (DateGlobals.Weekday != EventDay || GameGlobals.Eighties)
		{
			base.gameObject.SetActive(value: false);
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!EventOn)
		{
			for (int i = 1; i < 3; i++)
			{
				if (EventStudent[i] == null)
				{
					EventStudent[i] = StudentManager.Students[StudentID[i]];
				}
				else if (!EventStudent[i].Alive || EventStudent[i].Slave)
				{
					base.enabled = false;
				}
			}
			if (Clock.HourTime > StartTime && EventStudent[1] != null && EventStudent[2] != null && EventStudent[1].Indoors && EventStudent[2].Indoors && EventStudent[1].Pathfinding.canMove && EventStudent[2].Pathfinding.canMove)
			{
				if (Sitting && Yandere.Hiding && Yandere.HidingSpot == HidingSpot.Spot)
				{
					Yandere.PromptBar.ClearButtons();
					Yandere.PromptBar.Show = false;
					Yandere.Exiting = true;
					HidingSpot.Prompt.enabled = false;
					HidingSpot.Prompt.Hide();
				}
				EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].WalkAnim);
				EventStudent[1].CurrentDestination = EventLocation[1];
				EventStudent[1].Pathfinding.target = EventLocation[1];
				EventStudent[1].InEvent = true;
				EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].WalkAnim);
				EventStudent[2].CurrentDestination = EventLocation[2];
				EventStudent[2].Pathfinding.target = EventLocation[2];
				EventStudent[2].InEvent = true;
				if (StartTime > 16f)
				{
					Yandere.PauseScreen.Hint.QuickID = 49;
					Yandere.PauseScreen.Hint.Show = true;
				}
				EventOn = true;
			}
			return;
		}
		if ((!Sitting && Clock.HourTime > StartTime + 0.5f) || (Sitting && Clock.HourTime > StartTime + 1f) || EventStudent[1].WitnessedCorpse || EventStudent[2].WitnessedCorpse || EventStudent[1].Alarmed || EventStudent[2].Alarmed || EventStudent[1].Dying || EventStudent[2].Dying || EventStudent[1].GoAway || EventStudent[2].GoAway || Yandere.Noticed)
		{
			EndEvent();
			return;
		}
		if (EventStudent[1].Pathfinding.target != EventLocation[1])
		{
			EventStudent[1].CurrentDestination = EventLocation[1];
			EventStudent[1].Pathfinding.target = EventLocation[1];
			EventStudent[2].CurrentDestination = EventLocation[2];
			EventStudent[2].Pathfinding.target = EventLocation[2];
		}
		for (int j = 1; j < 3; j++)
		{
			if (!EventStudent[j].Pathfinding.canMove && !EventStudent[j].Private)
			{
				EventStudent[j].Character.GetComponent<Animation>().CrossFade(EventStudent[j].IdleAnim);
				EventStudent[j].Private = true;
				StudentManager.UpdateStudents();
			}
		}
		if (!EventStudent[1].Pathfinding.canMove && !EventStudent[2].Pathfinding.canMove)
		{
			if (Sitting)
			{
				EventStudent[1].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				EventStudent[1].CharacterAnimation[EventStudent[1].SocialSitAnim].layer = 99;
				EventStudent[1].CharacterAnimation.Play(EventStudent[1].SocialSitAnim);
				EventStudent[1].CharacterAnimation[EventStudent[1].SocialSitAnim].weight = 1f;
				EventStudent[2].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				EventStudent[2].CharacterAnimation[EventStudent[2].SocialSitAnim].layer = 99;
				EventStudent[2].CharacterAnimation.Play(EventStudent[2].SocialSitAnim);
				EventStudent[2].CharacterAnimation[EventStudent[2].SocialSitAnim].weight = 1f;
				EventStudent[1].MyController.radius = 0f;
				EventStudent[2].MyController.radius = 0f;
				RotateSpine = true;
			}
			float num = Vector3.Distance(Yandere.transform.position, EventLocation[1].parent.position);
			if (!Spoken)
			{
				if (Sitting)
				{
					EventStudent[EventSpeaker[1]].CharacterAnimation.CrossFade("f02_benchSit_00");
					EventStudent[EventSpeaker[2]].CharacterAnimation.CrossFade("f02_benchSit_00");
				}
				else
				{
					EventStudent[EventSpeaker[1]].CharacterAnimation.CrossFade(EventStudent[1].IdleAnim);
					EventStudent[EventSpeaker[2]].CharacterAnimation.CrossFade(EventStudent[2].IdleAnim);
				}
				EventStudent[EventSpeaker[EventPhase]].PickRandomAnim();
				EventStudent[EventSpeaker[EventPhase]].CharacterAnimation.CrossFade(EventStudent[EventSpeaker[EventPhase]].RandomAnim);
				if (!Sitting && StartTime < 16f && DateGlobals.Weekday == DayOfWeek.Monday && EventPhase == 13)
				{
					EventStudent[EventSpeaker[EventPhase]].CharacterAnimation.CrossFade("jojoPose_00");
				}
				AudioClipPlayer.Play(EventClip[EventPhase], EventStudent[EventSpeaker[EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Spoken = true;
			}
			else
			{
				int num2 = EventSpeaker[EventPhase];
				if (EventStudent[num2].CharacterAnimation[EventStudent[num2].RandomAnim].time >= EventStudent[num2].CharacterAnimation[EventStudent[num2].RandomAnim].length)
				{
					EventStudent[num2].PickRandomAnim();
					EventStudent[num2].CharacterAnimation.CrossFade(EventStudent[num2].RandomAnim);
				}
				Timer += Time.deltaTime;
				if (Yandere.transform.position.y > EventLocation[1].parent.position.y - 1f && Yandere.transform.position.y < EventLocation[1].parent.position.y + 1f)
				{
					if (VoiceClip != null)
					{
						VoiceClip.GetComponent<AudioSource>().volume = 1f;
					}
					if (num < 10f)
					{
						if (Timer > EventClip[EventPhase].length)
						{
							EventSubtitle.text = string.Empty;
						}
						else
						{
							EventSubtitle.text = EventSpeech[EventPhase];
						}
						Scale = Mathf.Abs((num - 10f) * 0.2f);
						if (Scale < 0f)
						{
							Scale = 0f;
						}
						if (Scale > 1f)
						{
							Scale = 1f;
						}
						EventSubtitle.transform.localScale = new Vector3(Scale, Scale, Scale);
					}
					else if (num < 11f)
					{
						EventSubtitle.transform.localScale = Vector3.zero;
						EventSubtitle.text = string.Empty;
					}
				}
				else if (VoiceClip != null)
				{
					VoiceClip.GetComponent<AudioSource>().volume = 0f;
				}
				if (Timer > EventClip[EventPhase].length + Delay)
				{
					Spoken = false;
					EventPhase++;
					Timer = 0f;
					if (EventPhase == EventSpeech.Length)
					{
						EndEvent();
					}
				}
			}
			if (Private)
			{
				if (num < 5f)
				{
					Yandere.Eavesdropping = true;
				}
				else
				{
					Yandere.Eavesdropping = false;
				}
			}
		}
		else if (Vector3.Distance(Yandere.transform.position, EventLocation[1].parent.position) < 5f)
		{
			Debug.Log("Ayano is intrusively close to the place where a private convo is supposed to take place...");
			if (EventStudent[1].CanSeeObject(Yandere.gameObject) || EventStudent[2].CanSeeObject(Yandere.gameObject))
			{
				Debug.Log("...AND is visible, too.");
				EndEvent();
			}
		}
	}

	private void LateUpdate()
	{
		if (RotateSpine)
		{
			EventStudent[1].Head.transform.localEulerAngles += new Vector3(0f, 15f, 0f);
			EventStudent[1].Neck.transform.localEulerAngles += new Vector3(0f, 15f, 0f);
			EventStudent[1].Spine.transform.localEulerAngles += new Vector3(0f, 15f, 0f);
			EventStudent[1].LeftEye.transform.localEulerAngles += new Vector3(0f, 5f, 0f);
			EventStudent[1].RightEye.transform.localEulerAngles += new Vector3(0f, 5f, 0f);
			EventStudent[2].Head.transform.localEulerAngles += new Vector3(0f, -15f, 0f);
			EventStudent[2].Neck.transform.localEulerAngles += new Vector3(0f, -15f, 0f);
			EventStudent[2].Spine.transform.localEulerAngles += new Vector3(0f, -15f, 0f);
			EventStudent[2].LeftEye.transform.localEulerAngles += new Vector3(0f, -5f, 0f);
			EventStudent[2].RightEye.transform.localEulerAngles += new Vector3(0f, -5f, 0f);
			MouthTimer += Time.deltaTime;
			if (MouthTimer > TimerLimit)
			{
				MouthTarget = UnityEngine.Random.Range(40f, 40f + MouthExtent);
				MouthTimer = 0f;
			}
			Transform jaw = EventStudent[EventSpeaker[EventPhase]].Jaw;
			Transform lipL = EventStudent[EventSpeaker[EventPhase]].LipL;
			Transform lipR = EventStudent[EventSpeaker[EventPhase]].LipR;
			jaw.localEulerAngles = new Vector3(jaw.localEulerAngles.x, jaw.localEulerAngles.y, Mathf.Lerp(jaw.localEulerAngles.z, MouthTarget, Time.deltaTime * TalkSpeed));
			lipL.localPosition = new Vector3(lipL.localPosition.x, Mathf.Lerp(lipL.localPosition.y, 0.02632812f + MouthTarget * LipStrength, Time.deltaTime * TalkSpeed), lipL.localPosition.z);
			lipR.localPosition = new Vector3(lipR.localPosition.x, Mathf.Lerp(lipR.localPosition.y, 0.02632812f + MouthTarget * LipStrength, Time.deltaTime * TalkSpeed), lipR.localPosition.z);
		}
	}

	public void EndEvent()
	{
		Debug.Log("An Ambient Event named " + base.gameObject.name + " has ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		for (int i = 1; i < 3; i++)
		{
			EventStudent[i].CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			EventStudent[i].CharacterAnimation.Stop(EventStudent[i].SocialSitAnim);
			EventStudent[1].MyController.radius = 0.1f;
			if (EventStudent[i].Meeting && EventStudent[i].Clock.HourTime > EventStudent[i].MeetTime)
			{
				EventStudent[i].CurrentDestination = EventStudent[i].MeetSpot;
				EventStudent[i].Pathfinding.target = EventStudent[i].MeetSpot;
				EventStudent[i].DistanceToDestination = Vector3.Distance(base.transform.position, EventStudent[i].CurrentDestination.position);
				EventStudent[i].Pathfinding.canSearch = true;
				EventStudent[i].Pathfinding.canMove = true;
				EventStudent[i].Pathfinding.speed = 4f;
				EventStudent[i].SpeechLines.Stop();
				EventStudent[i].EmptyHands();
				EventStudent[i].Meeting = true;
				EventStudent[i].MeetTime = 0f;
			}
			else
			{
				EventStudent[i].CurrentDestination = EventStudent[i].Destinations[EventStudent[i].Phase];
				EventStudent[i].Pathfinding.target = EventStudent[i].Destinations[EventStudent[i].Phase];
			}
			EventStudent[i].InEvent = false;
			EventStudent[i].Private = false;
			StudentManager.UpdateMe(EventStudent[i].StudentID);
			if (GrudgeConversation)
			{
				StudentManager.Police.EndOfDay.GrudgeConversationHappened = true;
			}
		}
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		if (HidingSpot != null)
		{
			HidingSpot.Prompt.enabled = true;
		}
		EventSubtitle.text = string.Empty;
		Yandere.Eavesdropping = false;
		base.enabled = false;
	}
}
