using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001EDC RID: 7900 RVA: 0x001B1C17 File Offset: 0x001AFE17
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001EDD RID: 7901 RVA: 0x001B1C28 File Offset: 0x001AFE28
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

	// Token: 0x04004022 RID: 16418
	public YandereScript Yandere;

	// Token: 0x04004023 RID: 16419
	public RagdollScript Ragdoll;

	// Token: 0x04004024 RID: 16420
	public PromptScript Prompt;

	// Token: 0x04004025 RID: 16421
	public DoorScript Door;

	// Token: 0x04004026 RID: 16422
	public Transform Hinge;

	// Token: 0x04004027 RID: 16423
	public bool Occupied;

	// Token: 0x04004028 RID: 16424
	public bool Open;

	// Token: 0x04004029 RID: 16425
	public int VictimID;

	// Token: 0x0400402A RID: 16426
	public ClubType VictimClubType;

	// Token: 0x0400402B RID: 16427
	public float Rotation;

	// Token: 0x0400402C RID: 16428
	public bool Animate;
}
