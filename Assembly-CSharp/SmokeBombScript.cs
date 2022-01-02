using System;
using UnityEngine;

// Token: 0x0200042B RID: 1067
public class SmokeBombScript : MonoBehaviour
{
	// Token: 0x06001CA6 RID: 7334 RVA: 0x00152310 File Offset: 0x00150510
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

	// Token: 0x06001CA7 RID: 7335 RVA: 0x0015237C File Offset: 0x0015057C
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

	// Token: 0x06001CA8 RID: 7336 RVA: 0x00152420 File Offset: 0x00150620
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

	// Token: 0x06001CA9 RID: 7337 RVA: 0x001524C0 File Offset: 0x001506C0
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

	// Token: 0x06001CAA RID: 7338 RVA: 0x00152520 File Offset: 0x00150720
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

	// Token: 0x04003375 RID: 13173
	public StudentScript[] Students;

	// Token: 0x04003376 RID: 13174
	public float TimeLimit = 15f;

	// Token: 0x04003377 RID: 13175
	public float Timer;

	// Token: 0x04003378 RID: 13176
	public bool Amnesia;

	// Token: 0x04003379 RID: 13177
	public bool Stink;

	// Token: 0x0400337A RID: 13178
	public int ID;
}
