using System;
using UnityEngine;

public class MovingEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public PortalScript Portal;

	public PromptScript Prompt;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public Transform[] EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public Collider BenchCollider;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventCheck;

	public bool EventOver;

	public bool Poisoned;

	public int EventPhase = 1;

	public DayOfWeek EventDay = DayOfWeek.Wednesday;

	public float Distance;

	public float Timer;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == EventDay)
		{
			EventCheck = true;
		}
	}

	private void Update()
	{
		if (!Clock.StopTime && EventCheck && Clock.HourTime > 13f)
		{
			EventStudent = StudentManager.Students[30];
			if (EventStudent != null)
			{
				EventStudent.Character.GetComponent<Animation>()[EventStudent.BentoAnim].weight = 1f;
				EventStudent.CurrentDestination = EventLocation[0];
				EventStudent.Pathfinding.target = EventLocation[0];
				EventStudent.SmartPhone.SetActive(value: false);
				EventStudent.Scrubber.SetActive(value: false);
				EventStudent.Bento.SetActive(value: true);
				EventStudent.Pen.SetActive(value: false);
				EventStudent.MovingEvent = this;
				EventStudent.InEvent = true;
				EventStudent.Private = true;
				EventCheck = false;
				EventActive = true;
			}
		}
		if (!EventActive)
		{
			return;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Poisoned = true;
			Prompt.Hide();
			Prompt.enabled = false;
		}
		if ((Clock.HourTime > 13.375f && !Poisoned) || EventStudent.Dying || EventStudent.Splashed || EventStudent.Dodging)
		{
			EndEvent();
			return;
		}
		Distance = Vector3.Distance(Yandere.transform.position, EventStudent.transform.position);
		if (EventStudent.Alarmed || !(EventStudent.DistanceToDestination < EventStudent.TargetDistance) || EventStudent.Pathfinding.canMove)
		{
			return;
		}
		if (EventPhase == 0)
		{
			EventStudent.Character.GetComponent<Animation>().CrossFade(EventStudent.IdleAnim);
			if (Clock.HourTime > 13.05f)
			{
				EventStudent.CurrentDestination = EventLocation[1];
				EventStudent.Pathfinding.target = EventLocation[1];
				EventPhase++;
			}
		}
		else if (EventPhase == 1)
		{
			if (!StudentManager.Students[1].WitnessedCorpse)
			{
				if (Timer == 0f)
				{
					AudioClipPlayer.Play(EventClip[1], EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip);
					EventStudent.Character.GetComponent<Animation>().CrossFade(EventStudent.IdleAnim);
					if (Distance < 10f)
					{
						EventSubtitle.text = EventSpeech[1];
					}
					EventStudent.Prompt.Hide();
					EventStudent.Prompt.enabled = false;
				}
				Timer += Time.deltaTime;
				if (Timer > 2f)
				{
					EventStudent.CurrentDestination = EventLocation[2];
					EventStudent.Pathfinding.target = EventLocation[2];
					if (Distance < 10f)
					{
						EventSubtitle.text = string.Empty;
					}
					EventPhase++;
					Timer = 0f;
				}
			}
			else
			{
				EventPhase = 7;
				Timer = 3f;
			}
		}
		else if (EventPhase == 2)
		{
			Animation component = EventStudent.Character.GetComponent<Animation>();
			component[EventStudent.BentoAnim].weight -= Time.deltaTime;
			if (Timer == 0f)
			{
				component.CrossFade("f02_bentoPlace_00");
			}
			Timer += Time.deltaTime;
			if (Timer > 1f && EventStudent.Bento.transform.parent != null)
			{
				EventStudent.Bento.transform.parent = null;
				EventStudent.Bento.transform.position = new Vector3(8f, 0.5f, -2.2965f);
				EventStudent.Bento.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				EventStudent.Bento.transform.localScale = new Vector3(1.4f, 1.5f, 1.4f);
			}
			if (Timer > 2f)
			{
				if (Yandere.Inventory.LethalPoisons > 0)
				{
					Prompt.HideButton[0] = false;
				}
				EventStudent.CurrentDestination = EventLocation[3];
				EventStudent.Pathfinding.target = EventLocation[3];
				EventPhase++;
				Timer = 0f;
			}
		}
		else if (EventPhase == 3)
		{
			AudioClipPlayer.Play(EventClip[2], EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip);
			EventStudent.Character.GetComponent<Animation>().CrossFade("f02_cornerPeek_00");
			if (Distance < 10f)
			{
				EventSubtitle.text = EventSpeech[2];
			}
			EventPhase++;
		}
		else if (EventPhase == 4)
		{
			Timer += Time.deltaTime;
			if (Timer > 5.5f)
			{
				AudioClipPlayer.Play(EventClip[3], EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip);
				if (Distance < 10f)
				{
					EventSubtitle.text = EventSpeech[3];
				}
				EventPhase++;
				Timer = 0f;
			}
		}
		else if (EventPhase == 5)
		{
			Timer += Time.deltaTime;
			if (Timer > 5.5f)
			{
				AudioClipPlayer.Play(EventClip[4], EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip);
				if (Distance < 10f)
				{
					EventSubtitle.text = EventSpeech[4];
				}
				EventPhase++;
				Timer = 0f;
			}
		}
		else if (EventPhase == 6)
		{
			Timer += Time.deltaTime;
			if (Timer > 3f)
			{
				EventStudent.CurrentDestination = EventLocation[2];
				EventStudent.Pathfinding.target = EventLocation[2];
				if (Distance < 10f)
				{
					EventSubtitle.text = string.Empty;
				}
				EventPhase++;
				Prompt.Hide();
				Prompt.enabled = false;
				Timer = 0f;
			}
		}
		else if (EventPhase == 7)
		{
			if (Timer == 0f)
			{
				Animation component2 = EventStudent.Character.GetComponent<Animation>();
				component2["f02_bentoPlace_00"].time = component2["f02_bentoPlace_00"].length;
				component2["f02_bentoPlace_00"].speed = -1f;
				component2.CrossFade("f02_bentoPlace_00");
			}
			Timer += Time.deltaTime;
			if (Timer > 1f && EventStudent.Bento.transform.parent == null)
			{
				EventStudent.Bento.transform.parent = EventStudent.LeftHand;
				EventStudent.Bento.transform.localPosition = new Vector3(0f, -0.0906f, -0.032f);
				EventStudent.Bento.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
				EventStudent.Bento.transform.localScale = new Vector3(1.4f, 1.5f, 1.4f);
			}
			if (Timer > 2f)
			{
				EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
				EventStudent.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
				EventStudent.CurrentDestination = EventLocation[4];
				EventStudent.Pathfinding.target = EventLocation[4];
				EventStudent.Prompt.Hide();
				EventStudent.Prompt.enabled = false;
				EventPhase++;
				Timer = 0f;
			}
		}
		else if (EventPhase == 8)
		{
			Animation component3 = EventStudent.Character.GetComponent<Animation>();
			if (!Poisoned)
			{
				component3[EventStudent.BentoAnim].weight = 0f;
				component3.CrossFade(EventStudent.EatAnim);
				if (!EventStudent.Chopsticks[0].activeInHierarchy)
				{
					EventStudent.Chopsticks[0].SetActive(value: true);
					EventStudent.Chopsticks[1].SetActive(value: true);
				}
			}
			else
			{
				component3.CrossFade("f02_poisonDeath_00");
				Timer += Time.deltaTime;
				if (Timer < 13.55f)
				{
					if (!EventStudent.Chopsticks[0].activeInHierarchy)
					{
						AudioClipPlayer.Play(EventClip[5], EventStudent.transform.position + Vector3.up, 5f, 10f, out VoiceClip);
						EventStudent.Chopsticks[0].SetActive(value: true);
						EventStudent.Chopsticks[1].SetActive(value: true);
						EventStudent.Distracted = true;
					}
				}
				else if (Timer < 16.33333f)
				{
					if (EventStudent.Chopsticks[0].transform.parent != EventStudent.Bento.transform)
					{
						EventStudent.Chopsticks[0].transform.parent = EventStudent.Bento.transform;
						EventStudent.Chopsticks[1].transform.parent = EventStudent.Bento.transform;
					}
					EventStudent.EyeShrink += Time.deltaTime;
					if (EventStudent.EyeShrink > 0.9f)
					{
						EventStudent.EyeShrink = 0.9f;
					}
				}
				else if (EventStudent.Bento.transform.parent != null)
				{
					EventStudent.Bento.transform.parent = null;
					EventStudent.Bento.GetComponent<Collider>().isTrigger = false;
					EventStudent.Bento.AddComponent<Rigidbody>();
					Rigidbody component4 = EventStudent.Bento.GetComponent<Rigidbody>();
					component4.AddRelativeForce(Vector3.up * 100f);
					component4.AddRelativeForce(Vector3.left * 100f);
					component4.AddRelativeForce(Vector3.forward * -100f);
				}
				if (component3["f02_poisonDeath_00"].time > component3["f02_poisonDeath_00"].length)
				{
					EventStudent.Ragdoll.Poisoned = true;
					EventStudent.BecomeRagdoll();
					Yandere.Police.PoisonScene = true;
					EventOver = true;
					EndEvent();
				}
			}
		}
		if (!(Distance < 11f))
		{
			return;
		}
		if (Distance < 10f)
		{
			float num = Mathf.Abs((Distance - 10f) * 0.2f);
			if (num < 0f)
			{
				num = 0f;
			}
			if (num > 1f)
			{
				num = 1f;
			}
			EventSubtitle.transform.localScale = new Vector3(num, num, num);
		}
		else
		{
			EventSubtitle.transform.localScale = Vector3.zero;
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
			EventStudent.Character.GetComponent<Animation>()[EventStudent.BentoAnim].weight = 0f;
			EventStudent.Chopsticks[0].SetActive(value: false);
			EventStudent.Chopsticks[1].SetActive(value: false);
			EventStudent.Bento.SetActive(value: false);
			EventStudent.Prompt.enabled = true;
			EventStudent.MovingEvent = null;
			EventStudent.InEvent = false;
			EventStudent.Private = false;
			EventSubtitle.text = string.Empty;
			StudentManager.UpdateStudents();
		}
		EventActive = false;
		EventCheck = false;
		Prompt.Hide();
		Prompt.enabled = false;
	}
}
