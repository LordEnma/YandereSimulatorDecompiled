using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x06001955 RID: 6485 RVA: 0x000FE5ED File Offset: 0x000FC7ED
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001956 RID: 6486 RVA: 0x000FE5FC File Offset: 0x000FC7FC
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

	// Token: 0x04002810 RID: 10256
	public PromptScript CasePrompt;

	// Token: 0x04002811 RID: 10257
	public PromptScript KeyPrompt;

	// Token: 0x04002812 RID: 10258
	public Transform Door;

	// Token: 0x04002813 RID: 10259
	public GameObject Key;

	// Token: 0x04002814 RID: 10260
	public float Rotation;

	// Token: 0x04002815 RID: 10261
	public bool Open;
}
