using UnityEngine;

public class GateScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Collider EmergencyDoor;

	public Collider GateCollider;

	public Transform RightGate;

	public Transform LeftGate;

	public bool ManuallyAdjusted;

	public bool AudioPlayed;

	public bool UpdateGates;

	public bool Crushing;

	public bool Closed;

	public AudioSource RightGateAudio;

	public AudioSource LeftGateAudio;

	public AudioSource RightGateLoop;

	public AudioSource LeftGateLoop;

	public AudioClip Start;

	public AudioClip StopOpen;

	public AudioClip StopClose;

	private void Update()
	{
		if (!ManuallyAdjusted)
		{
			if (Clock.PresentTime / 60f > 8f && Clock.PresentTime / 60f < 15.5f)
			{
				if (!Closed)
				{
					PlayAudio();
					Closed = true;
					if (EmergencyDoor.enabled)
					{
						EmergencyDoor.enabled = false;
					}
				}
			}
			else if (Closed)
			{
				PlayAudio();
				Closed = false;
				if (!EmergencyDoor.enabled)
				{
					EmergencyDoor.enabled = true;
				}
			}
		}
		if (StudentManager.Students[97] != null)
		{
			if (StudentManager.Students[97].CurrentAction == StudentActionType.AtLocker && StudentManager.Students[97].Routine && StudentManager.Students[97].Alive)
			{
				if (ManuallyAdjusted)
				{
					StudentManager.Students[97].CurrentDestination = Prompt.transform;
					StudentManager.Students[97].Pathfinding.target = Prompt.transform;
				}
				if (Vector3.Distance(StudentManager.Students[97].transform.position, Prompt.transform.position) < 1.4f)
				{
					StudentManager.Students[97].CurrentDestination = StudentManager.Students[97].Destinations[StudentManager.Students[97].Phase];
					StudentManager.Students[97].Pathfinding.target = StudentManager.Students[97].Destinations[StudentManager.Students[97].Phase];
					if (ManuallyAdjusted)
					{
						ManuallyAdjusted = false;
					}
					Prompt.enabled = false;
					Prompt.Hide();
				}
				else
				{
					Prompt.enabled = true;
				}
			}
			else
			{
				Prompt.enabled = true;
			}
		}
		else
		{
			Prompt.enabled = true;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.SuspiciousActionTimer = 1f;
			Object.Instantiate(Prompt.Yandere.AlarmDisc, Prompt.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
			Prompt.Circle[0].fillAmount = 1f;
			PlayAudio();
			EmergencyDoor.enabled = !EmergencyDoor.enabled;
			ManuallyAdjusted = true;
			Closed = !Closed;
		}
		if (!Closed)
		{
			if (RightGate.localPosition.x != 7f)
			{
				RightGate.localPosition = new Vector3(Mathf.MoveTowards(RightGate.localPosition.x, 7f, Time.deltaTime), RightGate.localPosition.y, RightGate.localPosition.z);
				LeftGate.localPosition = new Vector3(Mathf.MoveTowards(LeftGate.localPosition.x, -7f, Time.deltaTime), LeftGate.localPosition.y, LeftGate.localPosition.z);
				if (!AudioPlayed && RightGate.localPosition.x == 7f)
				{
					RightGateAudio.clip = StopOpen;
					LeftGateAudio.clip = StopOpen;
					RightGateAudio.Play();
					LeftGateAudio.Play();
					RightGateLoop.Stop();
					LeftGateLoop.Stop();
					AudioPlayed = true;
				}
			}
		}
		else if (RightGate.localPosition.x != 2.325f)
		{
			if (RightGate.localPosition.x < 2.4f)
			{
				Crushing = true;
			}
			RightGate.localPosition = new Vector3(Mathf.MoveTowards(RightGate.localPosition.x, 2.325f, Time.deltaTime), RightGate.localPosition.y, RightGate.localPosition.z);
			LeftGate.localPosition = new Vector3(Mathf.MoveTowards(LeftGate.localPosition.x, -2.325f, Time.deltaTime), LeftGate.localPosition.y, LeftGate.localPosition.z);
			if (!AudioPlayed && RightGate.localPosition.x == 2.325f)
			{
				RightGateAudio.clip = StopOpen;
				LeftGateAudio.clip = StopOpen;
				RightGateAudio.Play();
				LeftGateAudio.Play();
				RightGateLoop.Stop();
				LeftGateLoop.Stop();
				AudioPlayed = true;
				Crushing = false;
			}
		}
	}

	public void PlayAudio()
	{
		RightGateAudio.clip = Start;
		LeftGateAudio.clip = Start;
		RightGateAudio.Play();
		LeftGateAudio.Play();
		RightGateLoop.Play();
		LeftGateLoop.Play();
		AudioPlayed = false;
	}
}
