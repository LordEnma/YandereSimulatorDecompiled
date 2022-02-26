using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x06001826 RID: 6182 RVA: 0x000E4EC4 File Offset: 0x000E30C4
	private void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x06001827 RID: 6183 RVA: 0x000E4ED8 File Offset: 0x000E30D8
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

	// Token: 0x040022F8 RID: 8952
	public StudentScript Teacher;

	// Token: 0x040022F9 RID: 8953
	public GameObject Character;

	// Token: 0x040022FA RID: 8954
	public Transform LeftHand;

	// Token: 0x040022FB RID: 8955
	public Transform Chair;

	// Token: 0x040022FC RID: 8956
	public Transform Paper;

	// Token: 0x040022FD RID: 8957
	public float PickUpTime1;

	// Token: 0x040022FE RID: 8958
	public float SetDownTime1;

	// Token: 0x040022FF RID: 8959
	public float PickUpTime2;

	// Token: 0x04002300 RID: 8960
	public float SetDownTime2;

	// Token: 0x04002301 RID: 8961
	public Vector3 OriginalPosition;

	// Token: 0x04002302 RID: 8962
	public Vector3 PickUpPosition1;

	// Token: 0x04002303 RID: 8963
	public Vector3 SetDownPosition1;

	// Token: 0x04002304 RID: 8964
	public Vector3 PickUpPosition2;

	// Token: 0x04002305 RID: 8965
	public Vector3 PickUpRotation1;

	// Token: 0x04002306 RID: 8966
	public Vector3 SetDownRotation1;

	// Token: 0x04002307 RID: 8967
	public Vector3 PickUpRotation2;

	// Token: 0x04002308 RID: 8968
	public int Phase = 1;

	// Token: 0x04002309 RID: 8969
	public float Speed = 1f;

	// Token: 0x0400230A RID: 8970
	public bool Writing;
}
