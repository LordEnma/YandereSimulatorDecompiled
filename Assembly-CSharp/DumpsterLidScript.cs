using System;
using UnityEngine;

// Token: 0x02000293 RID: 659
public class DumpsterLidScript : MonoBehaviour
{
	// Token: 0x060013C2 RID: 5058 RVA: 0x000BB3E1 File Offset: 0x000B95E1
	private void Start()
	{
		this.FallChecker.SetActive(false);
		this.Prompt.HideButton[3] = true;
	}

	// Token: 0x060013C3 RID: 5059 RVA: 0x000BB400 File Offset: 0x000B9600
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

	// Token: 0x060013C4 RID: 5060 RVA: 0x000BB8C0 File Offset: 0x000B9AC0
	public void SetVictimMissing()
	{
		StudentGlobals.SetStudentMissing(this.StudentToGoMissing, true);
	}

	// Token: 0x04001D75 RID: 7541
	public StudentScript Victim;

	// Token: 0x04001D76 RID: 7542
	public Transform SlideLocation;

	// Token: 0x04001D77 RID: 7543
	public Transform GarbageDebris;

	// Token: 0x04001D78 RID: 7544
	public Transform Hinge;

	// Token: 0x04001D79 RID: 7545
	public GameObject FallChecker;

	// Token: 0x04001D7A RID: 7546
	public GameObject Corpse;

	// Token: 0x04001D7B RID: 7547
	public PromptScript[] DragPrompts;

	// Token: 0x04001D7C RID: 7548
	public PromptScript Prompt;

	// Token: 0x04001D7D RID: 7549
	public float DisposalSpot;

	// Token: 0x04001D7E RID: 7550
	public float Rotation;

	// Token: 0x04001D7F RID: 7551
	public bool Slide;

	// Token: 0x04001D80 RID: 7552
	public bool Fill;

	// Token: 0x04001D81 RID: 7553
	public bool Open;

	// Token: 0x04001D82 RID: 7554
	public int StudentToGoMissing;
}
