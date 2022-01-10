using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SmokeBombScript : MonoBehaviour
{
	// Token: 0x06001CAD RID: 7341 RVA: 0x00152614 File Offset: 0x00150814
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

	// Token: 0x06001CAE RID: 7342 RVA: 0x00152680 File Offset: 0x00150880
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

	// Token: 0x06001CAF RID: 7343 RVA: 0x00152724 File Offset: 0x00150924
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

	// Token: 0x06001CB0 RID: 7344 RVA: 0x001527C4 File Offset: 0x001509C4
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

	// Token: 0x06001CB1 RID: 7345 RVA: 0x00152824 File Offset: 0x00150A24
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

	// Token: 0x0400337B RID: 13179
	public StudentScript[] Students;

	// Token: 0x0400337C RID: 13180
	public float TimeLimit = 15f;

	// Token: 0x0400337D RID: 13181
	public float Timer;

	// Token: 0x0400337E RID: 13182
	public bool Amnesia;

	// Token: 0x0400337F RID: 13183
	public bool Stink;

	// Token: 0x04003380 RID: 13184
	public int ID;
}
