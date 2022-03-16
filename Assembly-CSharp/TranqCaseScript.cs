using System;
using UnityEngine;

// Token: 0x02000485 RID: 1157
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001F07 RID: 7943 RVA: 0x001B540F File Offset: 0x001B360F
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001F08 RID: 7944 RVA: 0x001B5420 File Offset: 0x001B3620
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

	// Token: 0x040040AE RID: 16558
	public YandereScript Yandere;

	// Token: 0x040040AF RID: 16559
	public RagdollScript Ragdoll;

	// Token: 0x040040B0 RID: 16560
	public PromptScript Prompt;

	// Token: 0x040040B1 RID: 16561
	public DoorScript Door;

	// Token: 0x040040B2 RID: 16562
	public Transform Hinge;

	// Token: 0x040040B3 RID: 16563
	public bool Occupied;

	// Token: 0x040040B4 RID: 16564
	public bool Open;

	// Token: 0x040040B5 RID: 16565
	public int VictimID;

	// Token: 0x040040B6 RID: 16566
	public ClubType VictimClubType;

	// Token: 0x040040B7 RID: 16567
	public float Rotation;

	// Token: 0x040040B8 RID: 16568
	public bool Animate;
}
