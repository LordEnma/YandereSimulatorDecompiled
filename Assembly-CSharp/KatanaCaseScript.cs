using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x0600196A RID: 6506 RVA: 0x000FF891 File Offset: 0x000FDA91
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x0600196B RID: 6507 RVA: 0x000FF8A0 File Offset: 0x000FDAA0
	private void Update()
	{
		if (this.Key.activeInHierarchy && this.KeyPrompt.Circle[0].fillAmount == 0f)
		{
			this.KeyPrompt.Yandere.Inventory.CaseKey = true;
			this.CasePrompt.HideButton[0] = false;
			this.CasePrompt.enabled = true;
			this.Key.SetActive(false);
		}
		if (this.CasePrompt.Circle[0].fillAmount == 0f)
		{
			this.KeyPrompt.Yandere.Inventory.CaseKey = false;
			this.Open = true;
			this.CasePrompt.Hide();
			this.CasePrompt.enabled = false;
		}
		if (this.CasePrompt.Yandere.Inventory.LockPick)
		{
			this.CasePrompt.HideButton[2] = false;
			this.CasePrompt.enabled = true;
			if (this.CasePrompt.Circle[2].fillAmount == 0f)
			{
				this.KeyPrompt.Hide();
				this.KeyPrompt.enabled = false;
				this.CasePrompt.Yandere.Inventory.LockPick = false;
				this.CasePrompt.Label[0].text = "     Open";
				this.CasePrompt.HideButton[2] = true;
				this.CasePrompt.HideButton[0] = true;
				this.Open = true;
			}
		}
		else if (!this.CasePrompt.HideButton[2])
		{
			this.CasePrompt.HideButton[2] = true;
		}
		if (this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
			this.Door.eulerAngles = new Vector3(this.Door.eulerAngles.x, this.Door.eulerAngles.y, this.Rotation);
			if (this.Rotation < -179.9f)
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x0400283C RID: 10300
	public PromptScript CasePrompt;

	// Token: 0x0400283D RID: 10301
	public PromptScript KeyPrompt;

	// Token: 0x0400283E RID: 10302
	public Transform Door;

	// Token: 0x0400283F RID: 10303
	public GameObject Key;

	// Token: 0x04002840 RID: 10304
	public float Rotation;

	// Token: 0x04002841 RID: 10305
	public bool Open;
}
