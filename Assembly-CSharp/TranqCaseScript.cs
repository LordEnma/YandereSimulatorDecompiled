using System;
using UnityEngine;

// Token: 0x0200047D RID: 1149
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001ECD RID: 7885 RVA: 0x001B0113 File Offset: 0x001AE313
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001ECE RID: 7886 RVA: 0x001B0124 File Offset: 0x001AE324
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

	// Token: 0x04004000 RID: 16384
	public YandereScript Yandere;

	// Token: 0x04004001 RID: 16385
	public RagdollScript Ragdoll;

	// Token: 0x04004002 RID: 16386
	public PromptScript Prompt;

	// Token: 0x04004003 RID: 16387
	public DoorScript Door;

	// Token: 0x04004004 RID: 16388
	public Transform Hinge;

	// Token: 0x04004005 RID: 16389
	public bool Occupied;

	// Token: 0x04004006 RID: 16390
	public bool Open;

	// Token: 0x04004007 RID: 16391
	public int VictimID;

	// Token: 0x04004008 RID: 16392
	public ClubType VictimClubType;

	// Token: 0x04004009 RID: 16393
	public float Rotation;

	// Token: 0x0400400A RID: 16394
	public bool Animate;
}
