using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x0600195B RID: 6491 RVA: 0x000FE6ED File Offset: 0x000FC8ED
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x0600195C RID: 6492 RVA: 0x000FE6FC File Offset: 0x000FC8FC
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

	// Token: 0x04002813 RID: 10259
	public PromptScript CasePrompt;

	// Token: 0x04002814 RID: 10260
	public PromptScript KeyPrompt;

	// Token: 0x04002815 RID: 10261
	public Transform Door;

	// Token: 0x04002816 RID: 10262
	public GameObject Key;

	// Token: 0x04002817 RID: 10263
	public float Rotation;

	// Token: 0x04002818 RID: 10264
	public bool Open;
}
