using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DumpsterLidScript : MonoBehaviour
{
	// Token: 0x060013B7 RID: 5047 RVA: 0x000BA85D File Offset: 0x000B8A5D
	private void Start()
	{
		this.FallChecker.SetActive(false);
		this.Prompt.HideButton[3] = true;
	}

	// Token: 0x060013B8 RID: 5048 RVA: 0x000BA87C File Offset: 0x000B8A7C
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

	// Token: 0x060013B9 RID: 5049 RVA: 0x000BAD3C File Offset: 0x000B8F3C
	public void SetVictimMissing()
	{
		StudentGlobals.SetStudentMissing(this.StudentToGoMissing, true);
	}

	// Token: 0x04001D48 RID: 7496
	public StudentScript Victim;

	// Token: 0x04001D49 RID: 7497
	public Transform SlideLocation;

	// Token: 0x04001D4A RID: 7498
	public Transform GarbageDebris;

	// Token: 0x04001D4B RID: 7499
	public Transform Hinge;

	// Token: 0x04001D4C RID: 7500
	public GameObject FallChecker;

	// Token: 0x04001D4D RID: 7501
	public GameObject Corpse;

	// Token: 0x04001D4E RID: 7502
	public PromptScript[] DragPrompts;

	// Token: 0x04001D4F RID: 7503
	public PromptScript Prompt;

	// Token: 0x04001D50 RID: 7504
	public float DisposalSpot;

	// Token: 0x04001D51 RID: 7505
	public float Rotation;

	// Token: 0x04001D52 RID: 7506
	public bool Slide;

	// Token: 0x04001D53 RID: 7507
	public bool Fill;

	// Token: 0x04001D54 RID: 7508
	public bool Open;

	// Token: 0x04001D55 RID: 7509
	public int StudentToGoMissing;
}
