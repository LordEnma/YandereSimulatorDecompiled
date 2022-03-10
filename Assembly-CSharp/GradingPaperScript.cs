using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x06001826 RID: 6182 RVA: 0x000E51F4 File Offset: 0x000E33F4
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x06001827 RID: 6183 RVA: 0x000E5208 File Offset: 0x000E3408
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

	// Token: 0x0400230C RID: 8972
	public StudentScript Teacher;

	// Token: 0x0400230D RID: 8973
	public GameObject Character;

	// Token: 0x0400230E RID: 8974
	public Transform LeftHand;

	// Token: 0x0400230F RID: 8975
	public Transform Chair;

	// Token: 0x04002310 RID: 8976
	public Transform Paper;

	// Token: 0x04002311 RID: 8977
	public float PickUpTime1;

	// Token: 0x04002312 RID: 8978
	public float SetDownTime1;

	// Token: 0x04002313 RID: 8979
	public float PickUpTime2;

	// Token: 0x04002314 RID: 8980
	public float SetDownTime2;

	// Token: 0x04002315 RID: 8981
	public Vector3 OriginalPosition;

	// Token: 0x04002316 RID: 8982
	public Vector3 PickUpPosition1;

	// Token: 0x04002317 RID: 8983
	public Vector3 SetDownPosition1;

	// Token: 0x04002318 RID: 8984
	public Vector3 PickUpPosition2;

	// Token: 0x04002319 RID: 8985
	public Vector3 PickUpRotation1;

	// Token: 0x0400231A RID: 8986
	public Vector3 SetDownRotation1;

	// Token: 0x0400231B RID: 8987
	public Vector3 PickUpRotation2;

	// Token: 0x0400231C RID: 8988
	public int Phase = 1;

	// Token: 0x0400231D RID: 8989
	public float Speed = 1f;

	// Token: 0x0400231E RID: 8990
	public bool Writing;
}
