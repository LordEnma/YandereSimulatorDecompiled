using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001EF2 RID: 7922 RVA: 0x001B3597 File Offset: 0x001B1797
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001EF3 RID: 7923 RVA: 0x001B35A8 File Offset: 0x001B17A8
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

	// Token: 0x0400404C RID: 16460
	public YandereScript Yandere;

	// Token: 0x0400404D RID: 16461
	public RagdollScript Ragdoll;

	// Token: 0x0400404E RID: 16462
	public PromptScript Prompt;

	// Token: 0x0400404F RID: 16463
	public DoorScript Door;

	// Token: 0x04004050 RID: 16464
	public Transform Hinge;

	// Token: 0x04004051 RID: 16465
	public bool Occupied;

	// Token: 0x04004052 RID: 16466
	public bool Open;

	// Token: 0x04004053 RID: 16467
	public int VictimID;

	// Token: 0x04004054 RID: 16468
	public ClubType VictimClubType;

	// Token: 0x04004055 RID: 16469
	public float Rotation;

	// Token: 0x04004056 RID: 16470
	public bool Animate;
}
