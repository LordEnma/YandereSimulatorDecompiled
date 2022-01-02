﻿using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x0600180F RID: 6159 RVA: 0x000E3A98 File Offset: 0x000E1C98
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x06001810 RID: 6160 RVA: 0x000E3AAC File Offset: 0x000E1CAC
	private void Update()
	{
		if (!this.Writing)
		{
			if (Vector3.Distance(this.Chair.position, this.OriginalPosition) > 0.01f)
			{
				this.Chair.position = Vector3.Lerp(this.Chair.position, this.OriginalPosition, Time.deltaTime * 10f);
				return;
			}
		}
		else if (this.Character != null && this.Teacher != null)
		{
			if (Vector3.Distance(this.Chair.position, this.Character.transform.position + this.Character.transform.forward * 0.1f) > 0.01f)
			{
				this.Chair.position = Vector3.Lerp(this.Chair.position, this.Character.transform.position + this.Character.transform.forward * 0.1f, Time.deltaTime * 10f);
			}
			if (this.Phase == 1)
			{
				if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.PickUpTime1)
				{
					this.Teacher.CharacterAnimation["f02_deskWrite"].speed = this.Speed;
					this.Paper.parent = this.LeftHand;
					this.Paper.localPosition = this.PickUpPosition1;
					this.Paper.localEulerAngles = this.PickUpRotation1;
					this.Paper.localScale = new Vector3(0.9090909f, 0.9090909f, 0.9090909f);
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.SetDownTime1)
				{
					this.Paper.parent = this.Character.transform;
					this.Paper.localPosition = this.SetDownPosition1;
					this.Paper.localEulerAngles = this.SetDownRotation1;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.PickUpTime2)
				{
					this.Paper.parent = this.LeftHand;
					this.Paper.localPosition = this.PickUpPosition2;
					this.Paper.localEulerAngles = this.PickUpRotation2;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.SetDownTime2)
				{
					this.Paper.parent = this.Character.transform;
					this.Paper.localScale = Vector3.zero;
					this.Phase++;
				}
			}
			else if (this.Phase == 5 && this.Teacher.CharacterAnimation["f02_deskWrite"].time >= this.Teacher.CharacterAnimation["f02_deskWrite"].length)
			{
				this.Teacher.CharacterAnimation["f02_deskWrite"].time = 0f;
				this.Teacher.CharacterAnimation.Play("f02_deskWrite");
				this.Phase = 1;
			}
			if (this.Teacher.Actions[this.Teacher.Phase] != StudentActionType.GradePapers || !this.Teacher.Routine || this.Teacher.Stop)
			{
				this.Paper.localScale = Vector3.zero;
				this.Teacher.Obstacle.enabled = false;
				this.Teacher.Pen.SetActive(false);
				this.Writing = false;
				this.Phase = 1;
			}
		}
	}

	// Token: 0x040022D3 RID: 8915
	public StudentScript Teacher;

	// Token: 0x040022D4 RID: 8916
	public GameObject Character;

	// Token: 0x040022D5 RID: 8917
	public Transform LeftHand;

	// Token: 0x040022D6 RID: 8918
	public Transform Chair;

	// Token: 0x040022D7 RID: 8919
	public Transform Paper;

	// Token: 0x040022D8 RID: 8920
	public float PickUpTime1;

	// Token: 0x040022D9 RID: 8921
	public float SetDownTime1;

	// Token: 0x040022DA RID: 8922
	public float PickUpTime2;

	// Token: 0x040022DB RID: 8923
	public float SetDownTime2;

	// Token: 0x040022DC RID: 8924
	public Vector3 OriginalPosition;

	// Token: 0x040022DD RID: 8925
	public Vector3 PickUpPosition1;

	// Token: 0x040022DE RID: 8926
	public Vector3 SetDownPosition1;

	// Token: 0x040022DF RID: 8927
	public Vector3 PickUpPosition2;

	// Token: 0x040022E0 RID: 8928
	public Vector3 PickUpRotation1;

	// Token: 0x040022E1 RID: 8929
	public Vector3 SetDownRotation1;

	// Token: 0x040022E2 RID: 8930
	public Vector3 PickUpRotation2;

	// Token: 0x040022E3 RID: 8931
	public int Phase = 1;

	// Token: 0x040022E4 RID: 8932
	public float Speed = 1f;

	// Token: 0x040022E5 RID: 8933
	public bool Writing;
}
