using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001F32 RID: 7986 RVA: 0x001BA2D7 File Offset: 0x001B84D7
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001F33 RID: 7987 RVA: 0x001BA2E8 File Offset: 0x001B84E8
	private void Update()
	{
		if (this.Yandere.transform.position.x > base.transform.position.x && Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f)
		{
			if (this.Yandere.Dragging)
			{
				if (this.Ragdoll == null)
				{
					this.Ragdoll = this.Yandere.Ragdoll.GetComponent<RagdollScript>();
				}
				if (this.Ragdoll.Tranquil)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.enabled = true;
					}
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.enabled && this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.TranquilHiding = true;
				this.Yandere.CanMove = false;
				this.Prompt.enabled = false;
				this.Prompt.Hide();
				this.Ragdoll.TranqCase = this;
				this.VictimClubType = this.Ragdoll.Student.Club;
				this.VictimID = this.Ragdoll.StudentID;
				this.Door.Prompt.enabled = true;
				this.Door.enabled = true;
				this.Occupied = true;
				this.Animate = true;
				this.Open = true;
			}
		}
		if (this.Animate)
		{
			if (this.Open)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 105f, Time.deltaTime * 10f);
			}
			else
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
				this.Ragdoll.Student.OsanaHairL.transform.localScale = Vector3.MoveTowards(this.Ragdoll.Student.OsanaHairL.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
				this.Ragdoll.Student.OsanaHairR.transform.localScale = Vector3.MoveTowards(this.Ragdoll.Student.OsanaHairR.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
				if (this.Rotation < 1f)
				{
					this.Animate = false;
					this.Rotation = 0f;
				}
			}
			this.Hinge.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
		}
	}

	// Token: 0x0400412B RID: 16683
	public YandereScript Yandere;

	// Token: 0x0400412C RID: 16684
	public RagdollScript Ragdoll;

	// Token: 0x0400412D RID: 16685
	public PromptScript Prompt;

	// Token: 0x0400412E RID: 16686
	public DoorScript Door;

	// Token: 0x0400412F RID: 16687
	public Transform Hinge;

	// Token: 0x04004130 RID: 16688
	public bool Occupied;

	// Token: 0x04004131 RID: 16689
	public bool Open;

	// Token: 0x04004132 RID: 16690
	public int VictimID;

	// Token: 0x04004133 RID: 16691
	public ClubType VictimClubType;

	// Token: 0x04004134 RID: 16692
	public float Rotation;

	// Token: 0x04004135 RID: 16693
	public bool Animate;
}
