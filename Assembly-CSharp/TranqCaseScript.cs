using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001EDA RID: 7898 RVA: 0x001B0F47 File Offset: 0x001AF147
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001EDB RID: 7899 RVA: 0x001B0F58 File Offset: 0x001AF158
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

	// Token: 0x0400401B RID: 16411
	public YandereScript Yandere;

	// Token: 0x0400401C RID: 16412
	public RagdollScript Ragdoll;

	// Token: 0x0400401D RID: 16413
	public PromptScript Prompt;

	// Token: 0x0400401E RID: 16414
	public DoorScript Door;

	// Token: 0x0400401F RID: 16415
	public Transform Hinge;

	// Token: 0x04004020 RID: 16416
	public bool Occupied;

	// Token: 0x04004021 RID: 16417
	public bool Open;

	// Token: 0x04004022 RID: 16418
	public int VictimID;

	// Token: 0x04004023 RID: 16419
	public ClubType VictimClubType;

	// Token: 0x04004024 RID: 16420
	public float Rotation;

	// Token: 0x04004025 RID: 16421
	public bool Animate;
}
