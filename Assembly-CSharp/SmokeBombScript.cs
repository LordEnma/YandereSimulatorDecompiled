using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class SmokeBombScript : MonoBehaviour
{
	// Token: 0x06001C9C RID: 7324 RVA: 0x001515E0 File Offset: 0x0014F7E0
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

	// Token: 0x06001C9D RID: 7325 RVA: 0x0015164C File Offset: 0x0014F84C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				if (this.Stink)
				{
					this.GoAway(component);
					return;
				}
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

	// Token: 0x06001C9E RID: 7326 RVA: 0x001516C8 File Offset: 0x0014F8C8
	private void OnTriggerStay(Collider other)
	{
		if (this.Stink)
		{
			if (other.gameObject.layer == 9)
			{
				StudentScript component = other.gameObject.GetComponent<StudentScript>();
				if (component != null && !component.Yandere.Noticed)
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

	// Token: 0x06001C9F RID: 7327 RVA: 0x00151758 File Offset: 0x0014F958
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

	// Token: 0x06001CA0 RID: 7328 RVA: 0x001517B8 File Offset: 0x0014F9B8
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

	// Token: 0x04003343 RID: 13123
	public StudentScript[] Students;

	// Token: 0x04003344 RID: 13124
	public float TimeLimit = 15f;

	// Token: 0x04003345 RID: 13125
	public float Timer;

	// Token: 0x04003346 RID: 13126
	public bool Amnesia;

	// Token: 0x04003347 RID: 13127
	public bool Stink;

	// Token: 0x04003348 RID: 13128
	public int ID;
}
