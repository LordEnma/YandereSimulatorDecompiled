using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x06001837 RID: 6199 RVA: 0x000E5CB0 File Offset: 0x000E3EB0
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x06001838 RID: 6200 RVA: 0x000E5CC4 File Offset: 0x000E3EC4
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

	// Token: 0x0400232D RID: 9005
	public StudentScript Teacher;

	// Token: 0x0400232E RID: 9006
	public GameObject Character;

	// Token: 0x0400232F RID: 9007
	public Transform LeftHand;

	// Token: 0x04002330 RID: 9008
	public Transform Chair;

	// Token: 0x04002331 RID: 9009
	public Transform Paper;

	// Token: 0x04002332 RID: 9010
	public float PickUpTime1;

	// Token: 0x04002333 RID: 9011
	public float SetDownTime1;

	// Token: 0x04002334 RID: 9012
	public float PickUpTime2;

	// Token: 0x04002335 RID: 9013
	public float SetDownTime2;

	// Token: 0x04002336 RID: 9014
	public Vector3 OriginalPosition;

	// Token: 0x04002337 RID: 9015
	public Vector3 PickUpPosition1;

	// Token: 0x04002338 RID: 9016
	public Vector3 SetDownPosition1;

	// Token: 0x04002339 RID: 9017
	public Vector3 PickUpPosition2;

	// Token: 0x0400233A RID: 9018
	public Vector3 PickUpRotation1;

	// Token: 0x0400233B RID: 9019
	public Vector3 SetDownRotation1;

	// Token: 0x0400233C RID: 9020
	public Vector3 PickUpRotation2;

	// Token: 0x0400233D RID: 9021
	public int Phase = 1;

	// Token: 0x0400233E RID: 9022
	public float Speed = 1f;

	// Token: 0x0400233F RID: 9023
	public bool Writing;
}
