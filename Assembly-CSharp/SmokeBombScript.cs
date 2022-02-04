using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SmokeBombScript : MonoBehaviour
{
	// Token: 0x06001CB0 RID: 7344 RVA: 0x00154260 File Offset: 0x00152460
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

	// Token: 0x06001CB1 RID: 7345 RVA: 0x001542CC File Offset: 0x001524CC
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

	// Token: 0x06001CB2 RID: 7346 RVA: 0x00154370 File Offset: 0x00152570
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

	// Token: 0x06001CB3 RID: 7347 RVA: 0x00154410 File Offset: 0x00152610
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

	// Token: 0x06001CB4 RID: 7348 RVA: 0x00154470 File Offset: 0x00152670
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

	// Token: 0x04003387 RID: 13191
	public StudentScript[] Students;

	// Token: 0x04003388 RID: 13192
	public float TimeLimit = 15f;

	// Token: 0x04003389 RID: 13193
	public float Timer;

	// Token: 0x0400338A RID: 13194
	public bool Amnesia;

	// Token: 0x0400338B RID: 13195
	public bool Stink;

	// Token: 0x0400338C RID: 13196
	public int ID;
}
