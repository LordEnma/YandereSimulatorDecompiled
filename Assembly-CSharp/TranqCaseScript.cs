using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001EDF RID: 7903 RVA: 0x001B23FB File Offset: 0x001B05FB
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001EE0 RID: 7904 RVA: 0x001B240C File Offset: 0x001B060C
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

	// Token: 0x04004030 RID: 16432
	public YandereScript Yandere;

	// Token: 0x04004031 RID: 16433
	public RagdollScript Ragdoll;

	// Token: 0x04004032 RID: 16434
	public PromptScript Prompt;

	// Token: 0x04004033 RID: 16435
	public DoorScript Door;

	// Token: 0x04004034 RID: 16436
	public Transform Hinge;

	// Token: 0x04004035 RID: 16437
	public bool Occupied;

	// Token: 0x04004036 RID: 16438
	public bool Open;

	// Token: 0x04004037 RID: 16439
	public int VictimID;

	// Token: 0x04004038 RID: 16440
	public ClubType VictimClubType;

	// Token: 0x04004039 RID: 16441
	public float Rotation;

	// Token: 0x0400403A RID: 16442
	public bool Animate;
}
