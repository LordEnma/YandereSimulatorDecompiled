using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x0600181D RID: 6173 RVA: 0x000E45E0 File Offset: 0x000E27E0
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x0600181E RID: 6174 RVA: 0x000E45F4 File Offset: 0x000E27F4
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

	// Token: 0x040022E9 RID: 8937
	public StudentScript Teacher;

	// Token: 0x040022EA RID: 8938
	public GameObject Character;

	// Token: 0x040022EB RID: 8939
	public Transform LeftHand;

	// Token: 0x040022EC RID: 8940
	public Transform Chair;

	// Token: 0x040022ED RID: 8941
	public Transform Paper;

	// Token: 0x040022EE RID: 8942
	public float PickUpTime1;

	// Token: 0x040022EF RID: 8943
	public float SetDownTime1;

	// Token: 0x040022F0 RID: 8944
	public float PickUpTime2;

	// Token: 0x040022F1 RID: 8945
	public float SetDownTime2;

	// Token: 0x040022F2 RID: 8946
	public Vector3 OriginalPosition;

	// Token: 0x040022F3 RID: 8947
	public Vector3 PickUpPosition1;

	// Token: 0x040022F4 RID: 8948
	public Vector3 SetDownPosition1;

	// Token: 0x040022F5 RID: 8949
	public Vector3 PickUpPosition2;

	// Token: 0x040022F6 RID: 8950
	public Vector3 PickUpRotation1;

	// Token: 0x040022F7 RID: 8951
	public Vector3 SetDownRotation1;

	// Token: 0x040022F8 RID: 8952
	public Vector3 PickUpRotation2;

	// Token: 0x040022F9 RID: 8953
	public int Phase = 1;

	// Token: 0x040022FA RID: 8954
	public float Speed = 1f;

	// Token: 0x040022FB RID: 8955
	public bool Writing;
}
