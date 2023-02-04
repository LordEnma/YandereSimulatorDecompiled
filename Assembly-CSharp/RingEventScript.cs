using UnityEngine;

public class RingEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool RingStolen;

	public bool EventOver;

	public float EventTime = 13.1f;

	public int EventStudentID = 2;

	public int AccessoryID = 3;

	public int EventPhase = 1;

	public Vector3 OriginalPosition;

	public Vector3 HoldingPosition;

	public Vector3 HoldingRotation;

	public float CurrentClipLength;

	public float Timer;

	public PromptScript RingPrompt;

	public Collider RingCollider;

	private void Start()
	{
		HoldingPosition = new Vector3(0.0075f, -0.0355f, 0.0175f);
		HoldingRotation = new Vector3(15f, -70f, -135f);
		if (GameGlobals.RingStolen)
		{
			base.gameObject.SetActive(value: false);
		}
		if (GameGlobals.Eighties)
		{
			EventStudentID = 30;
			AccessoryID = 15;
		}
	}

	private void Update()
	{
		if (!Clock.StopTime && !EventActive && Clock.HourTime > EventTime)
		{
			EventStudent = StudentManager.Students[EventStudentID];
			if (EventStudent != null && !EventStudent.Distracted && !EventStudent.Talking && !EventStudent.EatingSnack && EventStudent.CurrentAction == StudentActionType.SitAndEatBento)
			{
				if (!EventStudent.WitnessedMurder && !EventStudent.Bullied)
				{
					if (EventStudent.Cosmetic.FemaleAccessories[AccessoryID].activeInHierarchy)
					{
						RingPrompt = EventStudent.Cosmetic.FemaleAccessories[AccessoryID].GetComponent<PromptScript>();
						RingCollider = EventStudent.Cosmetic.FemaleAccessories[AccessoryID].GetComponent<BoxCollider>();
						OriginalPosition = EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localPosition;
						EventStudent.CurrentDestination = EventStudent.Destinations[EventStudent.Phase];
						EventStudent.Pathfinding.target = EventStudent.Destinations[EventStudent.Phase];
						EventStudent.Obstacle.checkTime = 99f;
						EventStudent.InEvent = true;
						EventStudent.Private = true;
						EventActive = true;
						if (EventStudent.Following)
						{
							EventStudent.Pathfinding.canMove = true;
							EventStudent.Pathfinding.speed = 1f;
							EventStudent.Following = false;
							EventStudent.Routine = true;
							Yandere.Follower = null;
							Yandere.Followers--;
							EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
							EventStudent.Prompt.Label[0].text = "     Talk";
						}
					}
					else
					{
						Debug.Log("Disabling because the girl doesn't have her ring?");
						base.enabled = false;
					}
				}
				else
				{
					Debug.Log("Disabling because the girl witnessed murder or was bullied?");
					base.enabled = false;
				}
			}
		}
		if (!EventActive)
		{
			return;
		}
		if (EventStudent.DistanceToDestination < 0.5f)
		{
			EventStudent.Pathfinding.canSearch = false;
			EventStudent.Pathfinding.canMove = false;
		}
		if (EventStudent.Alarmed && Yandere.TheftTimer > 0f)
		{
			Debug.Log("Event ended because the owner of the ring witnessed the theft.");
			EventStudent.Yandere.NotificationManager.CustomText = "You failed to steal the ring.";
			EventStudent.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.parent = EventStudent.LeftMiddleFinger;
			EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localPosition = OriginalPosition;
			EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			RingCollider.gameObject.SetActive(value: true);
			RingCollider.enabled = false;
			RingPrompt.Hide();
			RingPrompt.enabled = false;
			RingPrompt.GetComponent<RingScript>().enabled = false;
			EventStudent.RingReact = true;
			Yandere.Inventory.Ring = false;
			EndEvent();
		}
		else if (Clock.HourTime > EventTime + 0.5f || EventStudent.WitnessedMurder || EventStudent.Splashed || EventStudent.Alarmed || EventStudent.Dying || !EventStudent.Alive)
		{
			EndEvent();
		}
		else if (!EventStudent.Pathfinding.canMove)
		{
			if (EventPhase == 1)
			{
				Timer += Time.deltaTime;
				EventStudent.CharacterAnimation.CrossFade(EventAnim[0]);
				EventPhase++;
			}
			else if (EventPhase == 2)
			{
				Timer += Time.deltaTime;
				if (Timer > EventStudent.CharacterAnimation[EventAnim[0]].length)
				{
					EventStudent.CharacterAnimation.CrossFade(EventStudent.EatAnim);
					EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
					EventStudent.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
					EventStudent.Chopsticks[0].SetActive(value: true);
					EventStudent.Chopsticks[1].SetActive(value: true);
					EventStudent.Bento.SetActive(value: true);
					EventStudent.Lid.SetActive(value: false);
					RingCollider.enabled = true;
					RingPrompt.enabled = true;
					RingPrompt.GetComponent<RingScript>().enabled = true;
					RingPrompt.GetComponent<RingScript>().RingEvent = this;
					EventPhase++;
					Timer = 0f;
				}
				else if (Timer > 4f)
				{
					if (EventStudent.Cosmetic.FemaleAccessories[AccessoryID] != null)
					{
						EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.parent = null;
						if (!StudentManager.Eighties)
						{
							EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.position = new Vector3(-2.707666f, 12.4695f, -31.136f);
							EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.eulerAngles = new Vector3(-20f, 180f, 0f);
						}
						else
						{
							EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.position = new Vector3(4.946667f, 0.4768f, 18.65925f);
							EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.eulerAngles = new Vector3(-22.5f, 180f, 0f);
						}
					}
				}
				else if (Timer > 2.5f)
				{
					EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.parent = EventStudent.RightHand;
					EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localPosition = HoldingPosition;
					EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localEulerAngles = HoldingRotation;
				}
			}
			else if (EventPhase == 3)
			{
				if (Clock.HourTime > 13.375f)
				{
					EventStudent.Bento.SetActive(value: false);
					EventStudent.Chopsticks[0].SetActive(value: false);
					EventStudent.Chopsticks[1].SetActive(value: false);
					if (RingCollider != null)
					{
						RingCollider.enabled = false;
					}
					if (RingPrompt != null)
					{
						RingPrompt.Hide();
						RingPrompt.enabled = false;
					}
					RingScript component = RingPrompt.GetComponent<RingScript>();
					if (component != null)
					{
						component.enabled = false;
					}
					EventStudent.CharacterAnimation[EventAnim[0]].time = EventStudent.CharacterAnimation[EventAnim[0]].length;
					EventStudent.CharacterAnimation[EventAnim[0]].speed = -1f;
					if (!RingStolen)
					{
						EventStudent.CharacterAnimation.CrossFade(EventAnim[0]);
					}
					else
					{
						EventStudent.CharacterAnimation.CrossFade(EventAnim[1]);
					}
					EventPhase++;
				}
			}
			else if (EventPhase == 4)
			{
				Timer += Time.deltaTime;
				if (!RingStolen && EventStudent.Cosmetic.FemaleAccessories[AccessoryID] != null && EventStudent.Cosmetic.FemaleAccessories[AccessoryID].activeInHierarchy)
				{
					EventStudent.CharacterAnimation.CrossFade(EventAnim[0]);
					if (Timer > 2f)
					{
						EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.parent = EventStudent.RightHand;
						EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localPosition = HoldingPosition;
						EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localEulerAngles = HoldingRotation;
					}
					if (Timer > 3f)
					{
						EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.parent = EventStudent.LeftMiddleFinger;
						EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localPosition = OriginalPosition;
						RingCollider.enabled = false;
						RingPrompt.enabled = false;
						RingPrompt.Hide();
						RingPrompt.GetComponent<RingScript>().enabled = false;
					}
					if (Timer > 6f)
					{
						EndEvent();
					}
				}
				else
				{
					Debug.Log("The ring was stolen.");
					EventStudent.CharacterAnimation.CrossFade(EventAnim[1]);
					if (Timer > 1.5f)
					{
						if (Vector3.Distance(EventStudent.transform.position, Yandere.transform.position) < 10f)
						{
							EventSubtitle.text = EventSpeech[0];
							AudioClipPlayer.Play(EventClip[0], EventStudent.transform.position + Vector3.up, 5f, 10f, out VoiceClip, out CurrentClipLength);
						}
						EventPhase++;
					}
				}
			}
			else if (EventPhase == 5)
			{
				Timer += Time.deltaTime;
				if (Timer > 9.5f)
				{
					EndEvent();
				}
			}
			float num = Vector3.Distance(Yandere.transform.position, EventStudent.transform.position);
			if (!(num < 11f))
			{
				return;
			}
			if (num < 10f)
			{
				float num2 = Mathf.Abs((num - 10f) * 0.2f);
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				if (num2 > 1f)
				{
					num2 = 1f;
				}
				EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
			}
			else
			{
				EventSubtitle.transform.localScale = Vector3.zero;
			}
		}
		else
		{
			EventStudent.CharacterAnimation.CrossFade(EventStudent.WalkAnim);
		}
	}

	private void EndEvent()
	{
		if (!EventOver)
		{
			if (VoiceClip != null)
			{
				Object.Destroy(VoiceClip);
			}
			EventStudent.CurrentDestination = EventStudent.Destinations[EventStudent.Phase];
			EventStudent.Pathfinding.target = EventStudent.Destinations[EventStudent.Phase];
			EventStudent.Obstacle.checkTime = 1f;
			if (!EventStudent.Dying)
			{
				EventStudent.Prompt.enabled = true;
			}
			EventStudent.Pathfinding.speed = 1f;
			EventStudent.TargetDistance = 0.5f;
			EventStudent.InEvent = false;
			EventStudent.Private = false;
			EventSubtitle.text = string.Empty;
			StudentManager.UpdateStudents();
		}
		EventActive = false;
		base.enabled = false;
	}

	public void ReturnRing()
	{
		if (EventStudent.Cosmetic.FemaleAccessories[AccessoryID] != null)
		{
			EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.parent = EventStudent.LeftMiddleFinger;
			EventStudent.Cosmetic.FemaleAccessories[AccessoryID].transform.localPosition = OriginalPosition;
			RingCollider.enabled = false;
			RingPrompt.Hide();
			RingPrompt.enabled = false;
			RingPrompt.GetComponent<RingScript>().enabled = false;
		}
	}
}
