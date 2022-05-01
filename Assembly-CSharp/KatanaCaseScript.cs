using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x06001963 RID: 6499 RVA: 0x000FEE85 File Offset: 0x000FD085
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001964 RID: 6500 RVA: 0x000FEE94 File Offset: 0x000FD094
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

	// Token: 0x04002824 RID: 10276
	public PromptScript CasePrompt;

	// Token: 0x04002825 RID: 10277
	public PromptScript KeyPrompt;

	// Token: 0x04002826 RID: 10278
	public Transform Door;

	// Token: 0x04002827 RID: 10279
	public GameObject Key;

	// Token: 0x04002828 RID: 10280
	public float Rotation;

	// Token: 0x04002829 RID: 10281
	public bool Open;
}
