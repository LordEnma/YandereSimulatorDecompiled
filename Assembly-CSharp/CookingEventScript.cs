using System;
using UnityEngine;

public class CookingEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public RefrigeratorScript Snacks;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public ClockScript Clock;

	public GameObject Refrigerator;

	public GameObject RivalPhone;

	public GameObject Octodog;

	public GameObject Sausage;

	public Transform CookingClub;

	public Transform JarLid;

	public Transform Knife;

	public Transform Plate;

	public Transform Jar;

	public Transform[] Octodogs;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public Transform[] EventLocations;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] ClubMembers;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventCheck;

	public bool EventOver;

	public int EventStudentID;

	public float EventTime = 7f;

	public int EventPhase = 1;

	public DayOfWeek EventDay = DayOfWeek.Tuesday;

	public int Loop;

	public float CurrentClipLength;

	public float Rotation;

	public float Timer;

	private void Start()
	{
		Octodog.SetActive(false);
		Sausage.SetActive(false);
		Rotation = -90f;
		Transform[] octodogs = Octodogs;
		for (int i = 0; i < octodogs.Length; i++)
		{
			octodogs[i].gameObject.SetActive(false);
		}
		EventSubtitle.transform.localScale = Vector3.zero;
		EventCheck = true;
		if (ClubGlobals.GetClubClosed(ClubType.Cooking))
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		Input.GetKeyDown(KeyCode.Space);
		if (!Clock.StopTime && EventCheck && Clock.HourTime > EventTime)
		{
			EventStudent = StudentManager.Students[EventStudentID];
			if (EventStudent != null && !EventStudent.Distracted && EventStudent.MeetTime == 0f && !EventStudent.Meeting && !EventStudent.Wet)
			{
				if (!EventStudent.WitnessedMurder)
				{
					Snacks.Prompt.Hide();
					Snacks.Prompt.enabled = false;
					Snacks.enabled = false;
					EventStudent.CurrentDestination = EventLocations[0];
					EventStudent.Pathfinding.target = EventLocations[0];
					EventStudent.Scrubber.SetActive(false);
					EventStudent.Eraser.SetActive(false);
					EventStudent.Obstacle.checkTime = 99f;
					EventStudent.CookingEvent = this;
					EventStudent.InEvent = true;
					EventStudent.Private = true;
					EventStudent.Prompt.Hide();
					EventCheck = false;
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
					base.enabled = false;
				}
			}
		}
		if (!EventActive)
		{
			return;
		}
		if (Clock.HourTime > EventTime + 0.5f || EventStudent.WitnessedMurder || EventStudent.Splashed || EventStudent.Alarmed || EventStudent.Dying || EventStudent.Yandere.Cooking)
		{
			EndEvent();
		}
		else
		{
			if (!(EventStudent.DistanceToDestination < 1f))
			{
				return;
			}
			if (EventPhase == -1)
			{
				EventStudent.CharacterAnimation.CrossFade(EventAnim[0]);
				Timer += Time.deltaTime;
				if (Timer > 5f)
				{
					SchemeGlobals.SetSchemeStage(4, 5);
					Schemes.UpdateInstructions();
					RivalPhone.SetActive(false);
					EventSubtitle.text = string.Empty;
					EventPhase++;
					Timer = 0f;
				}
			}
			else if (EventPhase == 0)
			{
				if (!RivalPhone.activeInHierarchy)
				{
					EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
					EventStudent.SmartPhone.SetActive(false);
					Octodog.transform.parent = EventStudent.RightHand;
					Octodog.transform.localPosition = new Vector3(0.0129f, -0.02475f, 0.0316f);
					Octodog.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
					Sausage.transform.parent = EventStudent.RightHand;
					Sausage.transform.localPosition = new Vector3(0.013f, -0.038f, 0.015f);
					Sausage.transform.localEulerAngles = Vector3.zero;
					EventPhase++;
				}
				else
				{
					AudioClipPlayer.Play(EventClip[0], EventStudent.transform.position + Vector3.up, 5f, 10f, out VoiceClip, out CurrentClipLength);
					EventStudent.CharacterAnimation.CrossFade(EventAnim[0]);
					EventSubtitle.text = EventSpeech[0];
					EventPhase--;
				}
			}
			else if (EventPhase == 1)
			{
				EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 1f)
				{
					EventPhase++;
				}
			}
			else if (EventPhase == 2)
			{
				Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 3f)
				{
					Jar.transform.parent = EventStudent.RightHand;
					EventPhase++;
				}
			}
			else if (EventPhase == 3)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 5f)
				{
					JarLid.transform.parent = EventStudent.LeftHand;
					EventPhase++;
				}
			}
			else if (EventPhase == 4)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 6f)
				{
					JarLid.transform.parent = CookingClub;
					JarLid.transform.localPosition = new Vector3(0.334585f, 1f, -0.2528915f);
					JarLid.transform.localEulerAngles = new Vector3(0f, 30f, 0f);
					Jar.transform.parent = CookingClub;
					Jar.transform.localPosition = new Vector3(0.29559f, 1f, 0.2029152f);
					Jar.transform.localEulerAngles = new Vector3(0f, -150f, 0f);
					EventPhase++;
				}
			}
			else if (EventPhase == 5)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 7f)
				{
					Knife.GetComponent<WeaponScript>().FingerprintID = EventStudent.StudentID;
					Knife.parent = EventStudent.LeftHand;
					Knife.localPosition = new Vector3(0f, -0.01f, 0f);
					Knife.localEulerAngles = new Vector3(0f, 0f, -90f);
					EventPhase++;
				}
			}
			else if (EventPhase == 6)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time >= EventStudent.CharacterAnimation["f02_prepareFood_00"].length)
				{
					EventStudent.CharacterAnimation.CrossFade("f02_cutFood_00");
					Sausage.SetActive(true);
					EventPhase++;
				}
			}
			else if (EventPhase == 7)
			{
				if (EventStudent.CharacterAnimation["f02_cutFood_00"].time > 2.66666f)
				{
					Octodog.SetActive(true);
					Sausage.SetActive(false);
					EventPhase++;
				}
			}
			else if (EventPhase == 8)
			{
				if (EventStudent.CharacterAnimation["f02_cutFood_00"].time > 3f)
				{
					Rotation = Mathf.MoveTowards(Rotation, 90f, Time.deltaTime * 360f);
					Octodog.transform.localEulerAngles = new Vector3(Rotation, Octodog.transform.localEulerAngles.y, Octodog.transform.localEulerAngles.z);
					Octodog.transform.localPosition = new Vector3(Octodog.transform.localPosition.x, Octodog.transform.localPosition.y, Mathf.MoveTowards(Octodog.transform.localPosition.z, 0.012f, Time.deltaTime));
				}
				if (EventStudent.CharacterAnimation["f02_cutFood_00"].time > 6f)
				{
					Octodog.SetActive(false);
					Octodogs[Loop].gameObject.SetActive(true);
					EventPhase++;
				}
			}
			else if (EventPhase == 9)
			{
				if (EventStudent.CharacterAnimation["f02_cutFood_00"].time >= EventStudent.CharacterAnimation["f02_cutFood_00"].length)
				{
					if (Loop < Octodogs.Length - 1)
					{
						Octodog.transform.localEulerAngles = new Vector3(-90f, Octodog.transform.localEulerAngles.y, Octodog.transform.localEulerAngles.z);
						Octodog.transform.localPosition = new Vector3(Octodog.transform.localPosition.x, Octodog.transform.localPosition.y, 0.0316f);
						EventStudent.CharacterAnimation["f02_cutFood_00"].time = 0f;
						EventStudent.CharacterAnimation.Play("f02_cutFood_00");
						Sausage.SetActive(true);
						EventPhase = 7;
						Rotation = -90f;
						Loop++;
					}
					else
					{
						EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
						EventStudent.CharacterAnimation["f02_prepareFood_00"].time = EventStudent.CharacterAnimation["f02_prepareFood_00"].length;
						EventStudent.CharacterAnimation["f02_prepareFood_00"].speed = -1f;
						EventPhase++;
					}
				}
			}
			else if (EventPhase == 10)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time < EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 1f)
				{
					Knife.parent = CookingClub;
					Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
					Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
					EventPhase++;
				}
			}
			else if (EventPhase == 11)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time < EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 2f)
				{
					JarLid.parent = EventStudent.LeftHand;
					Jar.parent = EventStudent.RightHand;
					EventPhase++;
				}
			}
			else if (EventPhase == 12)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time < EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 3f)
				{
					JarLid.parent = Jar;
					JarLid.localPosition = new Vector3(0f, 0.175f, 0f);
					JarLid.localEulerAngles = Vector3.zero;
					Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
					Refrigerator.GetComponent<Animation>()["FridgeOpen"].time = Refrigerator.GetComponent<Animation>()["FridgeOpen"].length;
					Refrigerator.GetComponent<Animation>()["FridgeOpen"].speed = -1f;
					EventPhase++;
				}
			}
			else if (EventPhase == 13)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time < EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 5f)
				{
					Jar.parent = CookingClub;
					Jar.localPosition = new Vector3(0.1f, 0.941f, 0.75f);
					Jar.localEulerAngles = new Vector3(0f, 90f, 0f);
					EventPhase++;
				}
			}
			else if (EventPhase == 14)
			{
				if (EventStudent.CharacterAnimation["f02_prepareFood_00"].time <= 0f)
				{
					Knife.GetComponent<Collider>().enabled = true;
					Plate.parent = EventStudent.RightHand;
					Plate.localPosition = new Vector3(0f, 0.011f, -0.156765f);
					Plate.localEulerAngles = new Vector3(0f, -90f, -180f);
					EventStudent.CurrentDestination = EventLocations[1];
					EventStudent.Pathfinding.target = EventLocations[1];
					EventStudent.CharacterAnimation[EventStudent.CarryAnim].weight = 1f;
					EventPhase++;
				}
			}
			else if (EventPhase == 15)
			{
				Plate.parent = CookingClub;
				Plate.localPosition = new Vector3(-3.66666f, 0.9066666f, -2.379f);
				Plate.localEulerAngles = new Vector3(0f, -90f, 0f);
				EndEvent();
			}
			float num = Vector3.Distance(Yandere.transform.position, EventStudent.transform.position);
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
			else if (num < 11f)
			{
				EventSubtitle.transform.localScale = Vector3.zero;
			}
		}
	}

	private void EndEvent()
	{
		if (!EventOver)
		{
			if (VoiceClip != null)
			{
				UnityEngine.Object.Destroy(VoiceClip);
			}
			EventStudent.CurrentDestination = EventStudent.Destinations[EventStudent.Phase];
			EventStudent.Pathfinding.target = EventStudent.Destinations[EventStudent.Phase];
			EventStudent.Obstacle.checkTime = 1f;
			if (!EventStudent.Dying)
			{
				EventStudent.Prompt.enabled = true;
			}
			if (Plate.parent == EventStudent.RightHand)
			{
				Plate.parent = null;
				Plate.GetComponent<Rigidbody>().useGravity = true;
				Plate.GetComponent<BoxCollider>().enabled = true;
			}
			EventStudent.CharacterAnimation[EventStudent.CarryAnim].weight = 0f;
			EventStudent.SmartPhone.SetActive(false);
			EventStudent.Pathfinding.speed = 1f;
			EventStudent.TargetDistance = 1f;
			EventStudent.PhoneEvent = null;
			EventStudent.InEvent = false;
			EventStudent.Private = false;
			EventSubtitle.text = string.Empty;
			if (Knife.parent == EventStudent.LeftHand)
			{
				Knife.parent = CookingClub;
				Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
				Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
				Knife.GetComponent<Collider>().enabled = true;
			}
			StudentManager.UpdateStudents();
		}
		EventActive = false;
		EventCheck = false;
	}
}
