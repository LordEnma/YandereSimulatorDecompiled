using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x06001843 RID: 6211 RVA: 0x000E6730 File Offset: 0x000E4930
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
		this.Paper.localScale = new Vector3(0.9090909f, 0.9090909f, 0.9090909f);
		if (this.ID == 8 && GameGlobals.Eighties && DateGlobals.Week == 1)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001844 RID: 6212 RVA: 0x000E678C File Offset: 0x000E498C
	private void Update()
	{
		if (this.Teacher != null && this.Teacher.DistanceToPlayer < 10f && this.Writing && this.Character != null)
		{
			if (this.Teacher.DistanceToDestination < 1f)
			{
				switch (this.Phase)
				{
				case 1:
					if (this.Teacher.CharacterAnimation["f02_deskWrite"].time > this.PickUpTime1)
					{
						this.Teacher.CharacterAnimation["f02_deskWrite"].speed = this.Speed;
						this.Paper.parent = this.LeftHand;
						this.Paper.localPosition = this.PickUpPosition1;
						this.Paper.localEulerAngles = this.PickUpRotation1;
						this.Paper.gameObject.SetActive(true);
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
						this.Paper.gameObject.SetActive(false);
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
					this.RemoveProps();
					return;
				}
			}
			else
			{
				this.RemoveProps();
			}
		}
	}

	// Token: 0x06001845 RID: 6213 RVA: 0x000E6AA8 File Offset: 0x000E4CA8
	public void RemoveProps()
	{
		if (this.Paper.gameObject.activeInHierarchy)
		{
			this.Paper.gameObject.SetActive(false);
			this.Teacher.Obstacle.enabled = false;
			this.Teacher.Pen.SetActive(false);
			this.Writing = false;
			this.Phase = 1;
		}
	}

	// Token: 0x04002343 RID: 9027
	public StudentScript Teacher;

	// Token: 0x04002344 RID: 9028
	public GameObject Character;

	// Token: 0x04002345 RID: 9029
	public Transform LeftHand;

	// Token: 0x04002346 RID: 9030
	public Transform Chair;

	// Token: 0x04002347 RID: 9031
	public Transform Paper;

	// Token: 0x04002348 RID: 9032
	public float PickUpTime1;

	// Token: 0x04002349 RID: 9033
	public float SetDownTime1;

	// Token: 0x0400234A RID: 9034
	public float PickUpTime2;

	// Token: 0x0400234B RID: 9035
	public float SetDownTime2;

	// Token: 0x0400234C RID: 9036
	public Vector3 OriginalPosition;

	// Token: 0x0400234D RID: 9037
	public Vector3 PickUpPosition1;

	// Token: 0x0400234E RID: 9038
	public Vector3 SetDownPosition1;

	// Token: 0x0400234F RID: 9039
	public Vector3 PickUpPosition2;

	// Token: 0x04002350 RID: 9040
	public Vector3 PickUpRotation1;

	// Token: 0x04002351 RID: 9041
	public Vector3 SetDownRotation1;

	// Token: 0x04002352 RID: 9042
	public Vector3 PickUpRotation2;

	// Token: 0x04002353 RID: 9043
	public int Phase = 1;

	// Token: 0x04002354 RID: 9044
	public float Speed = 1f;

	// Token: 0x04002355 RID: 9045
	public bool Writing;

	// Token: 0x04002356 RID: 9046
	public int ID;
}
