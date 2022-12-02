using UnityEngine;

public class SmokeBombScript : MonoBehaviour
{
	public StudentScript[] Students;

	public float TimeLimit = 15f;

	public float Timer;

	public bool BigStink;

	public bool Amnesia;

	public bool Stink;

	public int ID;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (!(Timer > TimeLimit))
		{
			return;
		}
		if (!Stink)
		{
			StudentScript[] students = Students;
			foreach (StudentScript studentScript in students)
			{
				if (studentScript != null)
				{
					studentScript.Blind = false;
				}
			}
		}
		Object.Destroy(base.gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 9)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (!(component != null))
		{
			return;
		}
		if (Stink)
		{
			if (component != null && !component.Yandere.Noticed && !component.Guarding && !component.Fleeing)
			{
				GoAway(component);
			}
			return;
		}
		if (Amnesia && !component.Chasing)
		{
			component.ReturnToNormal();
		}
		Debug.Log(component.Name + " has been blinded.");
		Students[ID] = component;
		component.Blind = true;
		ID++;
	}

	private void OnTriggerStay(Collider other)
	{
		if (Stink)
		{
			if (other.gameObject.layer != 9)
			{
				return;
			}
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && !component.Yandere.Noticed && !component.Guarding && !component.Fleeing)
			{
				if (component.Actions[component.Phase] == StudentActionType.ClubAction && component.Club == ClubType.Cooking && component.ClubActivityPhase > 0)
				{
					component.Subtitle.CustomText = "Ew, something stinks! I want to run from the smell, but I can't run while holding this tray...";
					component.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				}
				else
				{
					GoAway(component);
				}
			}
		}
		else if (Amnesia && other.gameObject.layer == 9)
		{
			StudentScript component2 = other.gameObject.GetComponent<StudentScript>();
			if (component2 != null && component2.Alarmed && !component2.Chasing)
			{
				component2.ReturnToNormal();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!Stink && !Amnesia && other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log(component.Name + " left a smoke cloud and stopped being blind.");
				component.Blind = false;
			}
		}
	}

	private void GoAway(StudentScript Student)
	{
		if (!Student.Chasing && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Fleeing && !Student.Yandere.Noticed && !Student.Hunting && !Student.Confessing && !Student.Wet && !Student.Lethal && !Student.Emetic && !Student.Sedated && !Student.Headache && !Student.Vomiting && Student.ClubActivityPhase < 16 && !Student.EventSpecialCase && !Student.RetreivingMedicine)
		{
			Debug.Log(Student.Name + " just smelled a stink bomb!");
			if (Student.Investigating)
			{
				Student.StopInvestigating();
			}
			if (Student.Following)
			{
				Student.Yandere.Follower = null;
				Student.Yandere.Followers--;
				ParticleSystem.EmissionModule emission = Student.Hearts.emission;
				emission.enabled = false;
				Student.FollowCountdown.gameObject.SetActive(false);
				Student.Following = false;
			}
			if (Student.SolvingPuzzle)
			{
				Student.PuzzleTimer = 0f;
				Student.DropPuzzle();
			}
			if (Student.InEvent && Student.StinkBombSpecialCase > 0)
			{
				Debug.Log("Hit a student who was in an event with a stink bomb special case.");
				Student.Subtitle.CustomText = "Ew! Something STINKS! Gonna hold my breath until it's gone...";
				Student.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				Student.CharacterAnimation.CrossFade("f02_idleShame_00");
				Student.Pathfinding.canSearch = false;
				Student.Pathfinding.canMove = false;
				Student.Ragdoll.Zs.SetActive(false);
				Student.StinkBombSpecialCase = 2;
			}
			else
			{
				Student.CurrentDestination = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
				Student.Pathfinding.target = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
				Student.Pathfinding.canSearch = true;
				Student.Pathfinding.canMove = true;
				Student.CharacterAnimation.CrossFade(Student.SprintAnim);
				Student.DistanceToDestination = 100f;
				Student.Pathfinding.speed = 4f;
				Student.AmnesiaTimer = 10f;
				Student.GoAway = true;
			}
			Student.FocusOnYandere = false;
			Student.Distracted = true;
			Student.Alarmed = false;
			Student.Routine = false;
			if (BigStink)
			{
				Student.GoAwayLimit = 60f;
			}
			Student.AlarmTimer = 0f;
		}
	}
}
