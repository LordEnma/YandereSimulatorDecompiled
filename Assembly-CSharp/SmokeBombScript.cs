using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class SmokeBombScript : MonoBehaviour
{
	// Token: 0x06001CC2 RID: 7362 RVA: 0x001551AC File Offset: 0x001533AC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			if (!this.Stink)
			{
				foreach (StudentScript studentScript in this.Students)
				{
					if (studentScript != null)
					{
						studentScript.Blind = false;
					}
				}
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001CC3 RID: 7363 RVA: 0x00155218 File Offset: 0x00153418
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				if (this.Stink)
				{
					if (component != null && !component.Yandere.Noticed && !component.Guarding && !component.Fleeing)
					{
						this.GoAway(component);
						return;
					}
				}
				else
				{
					if (this.Amnesia && !component.Chasing)
					{
						component.ReturnToNormal();
					}
					this.Students[this.ID] = component;
					component.Blind = true;
					this.ID++;
				}
			}
		}
	}

	// Token: 0x06001CC4 RID: 7364 RVA: 0x001552BC File Offset: 0x001534BC
	private void OnTriggerStay(Collider other)
	{
		if (this.Stink)
		{
			if (other.gameObject.layer == 9)
			{
				StudentScript component = other.gameObject.GetComponent<StudentScript>();
				if (component != null && !component.Yandere.Noticed && !component.Guarding && !component.Fleeing)
				{
					this.GoAway(component);
					return;
				}
			}
		}
		else if (this.Amnesia && other.gameObject.layer == 9)
		{
			StudentScript component2 = other.gameObject.GetComponent<StudentScript>();
			if (component2 != null && component2.Alarmed && !component2.Chasing)
			{
				component2.ReturnToNormal();
			}
		}
	}

	// Token: 0x06001CC5 RID: 7365 RVA: 0x0015535C File Offset: 0x0015355C
	private void OnTriggerExit(Collider other)
	{
		if (!this.Stink && !this.Amnesia && other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log(component.Name + " left a smoke cloud and stopped being blind.");
				component.Blind = false;
			}
		}
	}

	// Token: 0x06001CC6 RID: 7366 RVA: 0x001553BC File Offset: 0x001535BC
	private void GoAway(StudentScript Student)
	{
		if (!Student.Chasing && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Fleeing && !Student.Yandere.Noticed && !Student.Hunting && !Student.Confessing)
		{
			if (Student.Following)
			{
				Student.Yandere.Follower = null;
				Student.Yandere.Followers--;
				Student.Hearts.emission.enabled = false;
				Student.FollowCountdown.gameObject.SetActive(false);
				Student.Following = false;
			}
			if (Student.SolvingPuzzle)
			{
				Student.PuzzleTimer = 0f;
				Student.DropPuzzle();
			}
			Student.CurrentDestination = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
			Student.Pathfinding.target = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
			Student.Pathfinding.canSearch = true;
			Student.Pathfinding.canMove = true;
			Student.CharacterAnimation.CrossFade(Student.SprintAnim);
			Student.DistanceToDestination = 100f;
			Student.Pathfinding.speed = 4f;
			Student.AmnesiaTimer = 10f;
			Student.Distracted = true;
			Student.Alarmed = false;
			Student.Routine = false;
			Student.GoAway = true;
			Student.AlarmTimer = 0f;
		}
	}

	// Token: 0x040033A0 RID: 13216
	public StudentScript[] Students;

	// Token: 0x040033A1 RID: 13217
	public float TimeLimit = 15f;

	// Token: 0x040033A2 RID: 13218
	public float Timer;

	// Token: 0x040033A3 RID: 13219
	public bool Amnesia;

	// Token: 0x040033A4 RID: 13220
	public bool Stink;

	// Token: 0x040033A5 RID: 13221
	public int ID;
}
