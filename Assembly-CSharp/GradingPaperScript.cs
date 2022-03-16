using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x0600182B RID: 6187 RVA: 0x000E56A0 File Offset: 0x000E38A0
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x0600182C RID: 6188 RVA: 0x000E56B4 File Offset: 0x000E38B4
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

	// Token: 0x0400231D RID: 8989
	public StudentScript Teacher;

	// Token: 0x0400231E RID: 8990
	public GameObject Character;

	// Token: 0x0400231F RID: 8991
	public Transform LeftHand;

	// Token: 0x04002320 RID: 8992
	public Transform Chair;

	// Token: 0x04002321 RID: 8993
	public Transform Paper;

	// Token: 0x04002322 RID: 8994
	public float PickUpTime1;

	// Token: 0x04002323 RID: 8995
	public float SetDownTime1;

	// Token: 0x04002324 RID: 8996
	public float PickUpTime2;

	// Token: 0x04002325 RID: 8997
	public float SetDownTime2;

	// Token: 0x04002326 RID: 8998
	public Vector3 OriginalPosition;

	// Token: 0x04002327 RID: 8999
	public Vector3 PickUpPosition1;

	// Token: 0x04002328 RID: 9000
	public Vector3 SetDownPosition1;

	// Token: 0x04002329 RID: 9001
	public Vector3 PickUpPosition2;

	// Token: 0x0400232A RID: 9002
	public Vector3 PickUpRotation1;

	// Token: 0x0400232B RID: 9003
	public Vector3 SetDownRotation1;

	// Token: 0x0400232C RID: 9004
	public Vector3 PickUpRotation2;

	// Token: 0x0400232D RID: 9005
	public int Phase = 1;

	// Token: 0x0400232E RID: 9006
	public float Speed = 1f;

	// Token: 0x0400232F RID: 9007
	public bool Writing;
}
