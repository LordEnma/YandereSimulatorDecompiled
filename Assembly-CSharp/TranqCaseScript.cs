using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001EE9 RID: 7913 RVA: 0x001B2A4B File Offset: 0x001B0C4B
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001EEA RID: 7914 RVA: 0x001B2A5C File Offset: 0x001B0C5C
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

	// Token: 0x0400403C RID: 16444
	public YandereScript Yandere;

	// Token: 0x0400403D RID: 16445
	public RagdollScript Ragdoll;

	// Token: 0x0400403E RID: 16446
	public PromptScript Prompt;

	// Token: 0x0400403F RID: 16447
	public DoorScript Door;

	// Token: 0x04004040 RID: 16448
	public Transform Hinge;

	// Token: 0x04004041 RID: 16449
	public bool Occupied;

	// Token: 0x04004042 RID: 16450
	public bool Open;

	// Token: 0x04004043 RID: 16451
	public int VictimID;

	// Token: 0x04004044 RID: 16452
	public ClubType VictimClubType;

	// Token: 0x04004045 RID: 16453
	public float Rotation;

	// Token: 0x04004046 RID: 16454
	public bool Animate;
}
