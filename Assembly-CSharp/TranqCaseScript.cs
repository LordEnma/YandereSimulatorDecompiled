using System;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001F28 RID: 7976 RVA: 0x001B8BD3 File Offset: 0x001B6DD3
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001F29 RID: 7977 RVA: 0x001B8BE4 File Offset: 0x001B6DE4
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

	// Token: 0x04004104 RID: 16644
	public YandereScript Yandere;

	// Token: 0x04004105 RID: 16645
	public RagdollScript Ragdoll;

	// Token: 0x04004106 RID: 16646
	public PromptScript Prompt;

	// Token: 0x04004107 RID: 16647
	public DoorScript Door;

	// Token: 0x04004108 RID: 16648
	public Transform Hinge;

	// Token: 0x04004109 RID: 16649
	public bool Occupied;

	// Token: 0x0400410A RID: 16650
	public bool Open;

	// Token: 0x0400410B RID: 16651
	public int VictimID;

	// Token: 0x0400410C RID: 16652
	public ClubType VictimClubType;

	// Token: 0x0400410D RID: 16653
	public float Rotation;

	// Token: 0x0400410E RID: 16654
	public bool Animate;
}
