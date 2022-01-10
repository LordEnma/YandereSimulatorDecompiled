using System;
using UnityEngine;

// Token: 0x02000293 RID: 659
public class DumpsterLidScript : MonoBehaviour
{
	// Token: 0x060013C1 RID: 5057 RVA: 0x000BB0E5 File Offset: 0x000B92E5
	private void Start()
	{
		this.FallChecker.SetActive(false);
		this.Prompt.HideButton[3] = true;
	}

	// Token: 0x060013C2 RID: 5058 RVA: 0x000BB104 File Offset: 0x000B9304
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Open)
			{
				this.Prompt.Label[0].text = "     Close";
				this.Open = true;
			}
			else
			{
				this.Prompt.Label[0].text = "     Open";
				this.Open = false;
			}
		}
		if (!this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
			this.Prompt.HideButton[3] = true;
		}
		else
		{
			this.Rotation = Mathf.Lerp(this.Rotation, -115f, Time.deltaTime * 10f);
			if (this.Corpse != null)
			{
				if (this.Prompt.Yandere.PickUp != null)
				{
					this.Prompt.HideButton[3] = !this.Prompt.Yandere.PickUp.Garbage;
				}
				else
				{
					this.Prompt.HideButton[3] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[3] = true;
			}
			if (this.Prompt.Circle[3].fillAmount == 0f)
			{
				UnityEngine.Object.Destroy(this.Prompt.Yandere.PickUp.gameObject);
				this.Prompt.Circle[3].fillAmount = 1f;
				this.Prompt.HideButton[3] = false;
				this.Fill = true;
			}
			if (base.transform.position.z > this.DisposalSpot - 0.05f && base.transform.position.z < this.DisposalSpot + 0.05f)
			{
				this.FallChecker.SetActive(this.Prompt.Yandere.RoofPush);
			}
			else
			{
				this.FallChecker.SetActive(false);
			}
			if (this.Slide)
			{
				base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, this.SlideLocation.eulerAngles, Time.deltaTime * 10f);
				base.transform.position = Vector3.Lerp(base.transform.position, this.SlideLocation.position, Time.deltaTime * 10f);
				this.Corpse.GetComponent<RagdollScript>().Student.Hips.position = base.transform.position + new Vector3(0f, 1f, 0f);
				if (Vector3.Distance(base.transform.position, this.SlideLocation.position) < 0.01f)
				{
					this.DragPrompts[0].enabled = false;
					this.DragPrompts[1].enabled = false;
					this.FallChecker.SetActive(false);
					this.Slide = false;
				}
			}
		}
		this.Hinge.localEulerAngles = new Vector3(this.Rotation, 0f, 0f);
		if (this.Fill)
		{
			this.GarbageDebris.localPosition = new Vector3(this.GarbageDebris.localPosition.x, Mathf.Lerp(this.GarbageDebris.localPosition.y, 1f, Time.deltaTime * 10f), this.GarbageDebris.localPosition.z);
			if (this.GarbageDebris.localPosition.y > 0.99f)
			{
				this.Prompt.Yandere.Police.SuicideScene = false;
				this.Prompt.Yandere.Police.Suicide = false;
				if (!this.Corpse.GetComponent<RagdollScript>().Concealed)
				{
					this.Prompt.Yandere.Police.HiddenCorpses--;
				}
				this.Prompt.Yandere.Police.Corpses--;
				if (this.Corpse.GetComponent<RagdollScript>().AddingToCount)
				{
					this.Prompt.Yandere.NearBodies--;
				}
				this.GarbageDebris.localPosition = new Vector3(this.GarbageDebris.localPosition.x, 1f, this.GarbageDebris.localPosition.z);
				this.StudentToGoMissing = this.Corpse.GetComponent<StudentScript>().StudentID;
				this.Corpse.gameObject.SetActive(false);
				this.Fill = false;
				this.Prompt.Yandere.StudentManager.UpdateStudents(0);
			}
		}
	}

	// Token: 0x060013C3 RID: 5059 RVA: 0x000BB5C4 File Offset: 0x000B97C4
	public void SetVictimMissing()
	{
		StudentGlobals.SetStudentMissing(this.StudentToGoMissing, true);
	}

	// Token: 0x04001D6C RID: 7532
	public StudentScript Victim;

	// Token: 0x04001D6D RID: 7533
	public Transform SlideLocation;

	// Token: 0x04001D6E RID: 7534
	public Transform GarbageDebris;

	// Token: 0x04001D6F RID: 7535
	public Transform Hinge;

	// Token: 0x04001D70 RID: 7536
	public GameObject FallChecker;

	// Token: 0x04001D71 RID: 7537
	public GameObject Corpse;

	// Token: 0x04001D72 RID: 7538
	public PromptScript[] DragPrompts;

	// Token: 0x04001D73 RID: 7539
	public PromptScript Prompt;

	// Token: 0x04001D74 RID: 7540
	public float DisposalSpot;

	// Token: 0x04001D75 RID: 7541
	public float Rotation;

	// Token: 0x04001D76 RID: 7542
	public bool Slide;

	// Token: 0x04001D77 RID: 7543
	public bool Fill;

	// Token: 0x04001D78 RID: 7544
	public bool Open;

	// Token: 0x04001D79 RID: 7545
	public int StudentToGoMissing;
}
