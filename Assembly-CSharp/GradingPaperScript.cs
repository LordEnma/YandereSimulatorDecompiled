using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x0600183F RID: 6207 RVA: 0x000E63B4 File Offset: 0x000E45B4
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x06001840 RID: 6208 RVA: 0x000E63C8 File Offset: 0x000E45C8
	private void Update()
	{
		if (this.Teacher != null && this.Teacher.DistanceToPlayer < 10f)
		{
			if (!this.Writing)
			{
				if (Vector3.Distance(this.Chair.position, this.OriginalPosition) > 0.01f)
				{
					this.Chair.position = Vector3.Lerp(this.Chair.position, this.OriginalPosition, Time.deltaTime * 10f);
					return;
				}
			}
			else if (this.Character != null && this.Teacher.DistanceToDestination < 1f)
			{
				if (Vector3.Distance(this.Chair.position, this.Character.transform.position + this.Character.transform.forward * 0.1f) > 0.01f)
				{
					this.Chair.position = Vector3.Lerp(this.Chair.position, this.Character.transform.position + this.Character.transform.forward * 0.1f, Time.deltaTime * 10f);
				}
				switch (this.Phase)
				{
				case 1:
					if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.PickUpTime1)
					{
						this.Teacher.CharacterAnimation["f02_deskWrite"].speed = this.Speed;
						this.Paper.parent = this.LeftHand;
						this.Paper.localPosition = this.PickUpPosition1;
						this.Paper.localEulerAngles = this.PickUpRotation1;
						this.Paper.localScale = new Vector3(0.9090909f, 0.9090909f, 0.9090909f);
						this.Phase++;
					}
					break;
				case 2:
					if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.SetDownTime1)
					{
						this.Paper.parent = this.Character.transform;
						this.Paper.localPosition = this.SetDownPosition1;
						this.Paper.localEulerAngles = this.SetDownRotation1;
						this.Phase++;
					}
					break;
				case 3:
					if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.PickUpTime2)
					{
						this.Paper.parent = this.LeftHand;
						this.Paper.localPosition = this.PickUpPosition2;
						this.Paper.localEulerAngles = this.PickUpRotation2;
						this.Phase++;
					}
					break;
				case 4:
					if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.SetDownTime2)
					{
						this.Paper.parent = this.Character.transform;
						this.Paper.localScale = Vector3.zero;
						this.Phase++;
					}
					break;
				case 5:
					if (this.Teacher.CharacterAnimation["f02_deskWrite"].time >= this.Teacher.CharacterAnimation["f02_deskWrite"].length)
					{
						this.Teacher.CharacterAnimation["f02_deskWrite"].time = 0f;
						this.Teacher.CharacterAnimation.Play("f02_deskWrite");
						this.Phase = 1;
					}
					break;
				}
				if ((this.Phase != 1 && this.Teacher.Actions[this.Teacher.Phase] != StudentActionType.GradePapers) || !this.Teacher.Routine || this.Teacher.Stop)
				{
					this.Paper.localScale = Vector3.zero;
					this.Teacher.Obstacle.enabled = false;
					this.Teacher.Pen.SetActive(false);
					this.Writing = false;
					this.Phase = 1;
				}
			}
		}
	}

	// Token: 0x04002339 RID: 9017
	public StudentScript Teacher;

	// Token: 0x0400233A RID: 9018
	public GameObject Character;

	// Token: 0x0400233B RID: 9019
	public Transform LeftHand;

	// Token: 0x0400233C RID: 9020
	public Transform Chair;

	// Token: 0x0400233D RID: 9021
	public Transform Paper;

	// Token: 0x0400233E RID: 9022
	public float PickUpTime1;

	// Token: 0x0400233F RID: 9023
	public float SetDownTime1;

	// Token: 0x04002340 RID: 9024
	public float PickUpTime2;

	// Token: 0x04002341 RID: 9025
	public float SetDownTime2;

	// Token: 0x04002342 RID: 9026
	public Vector3 OriginalPosition;

	// Token: 0x04002343 RID: 9027
	public Vector3 PickUpPosition1;

	// Token: 0x04002344 RID: 9028
	public Vector3 SetDownPosition1;

	// Token: 0x04002345 RID: 9029
	public Vector3 PickUpPosition2;

	// Token: 0x04002346 RID: 9030
	public Vector3 PickUpRotation1;

	// Token: 0x04002347 RID: 9031
	public Vector3 SetDownRotation1;

	// Token: 0x04002348 RID: 9032
	public Vector3 PickUpRotation2;

	// Token: 0x04002349 RID: 9033
	public int Phase = 1;

	// Token: 0x0400234A RID: 9034
	public float Speed = 1f;

	// Token: 0x0400234B RID: 9035
	public bool Writing;
}
