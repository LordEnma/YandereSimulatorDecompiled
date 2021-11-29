using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x06001806 RID: 6150 RVA: 0x000E3008 File Offset: 0x000E1208
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x06001807 RID: 6151 RVA: 0x000E301C File Offset: 0x000E121C
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

	// Token: 0x040022AF RID: 8879
	public StudentScript Teacher;

	// Token: 0x040022B0 RID: 8880
	public GameObject Character;

	// Token: 0x040022B1 RID: 8881
	public Transform LeftHand;

	// Token: 0x040022B2 RID: 8882
	public Transform Chair;

	// Token: 0x040022B3 RID: 8883
	public Transform Paper;

	// Token: 0x040022B4 RID: 8884
	public float PickUpTime1;

	// Token: 0x040022B5 RID: 8885
	public float SetDownTime1;

	// Token: 0x040022B6 RID: 8886
	public float PickUpTime2;

	// Token: 0x040022B7 RID: 8887
	public float SetDownTime2;

	// Token: 0x040022B8 RID: 8888
	public Vector3 OriginalPosition;

	// Token: 0x040022B9 RID: 8889
	public Vector3 PickUpPosition1;

	// Token: 0x040022BA RID: 8890
	public Vector3 SetDownPosition1;

	// Token: 0x040022BB RID: 8891
	public Vector3 PickUpPosition2;

	// Token: 0x040022BC RID: 8892
	public Vector3 PickUpRotation1;

	// Token: 0x040022BD RID: 8893
	public Vector3 SetDownRotation1;

	// Token: 0x040022BE RID: 8894
	public Vector3 PickUpRotation2;

	// Token: 0x040022BF RID: 8895
	public int Phase = 1;

	// Token: 0x040022C0 RID: 8896
	public float Speed = 1f;

	// Token: 0x040022C1 RID: 8897
	public bool Writing;
}
