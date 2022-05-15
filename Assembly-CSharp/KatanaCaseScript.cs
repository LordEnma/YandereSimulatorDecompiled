using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x06001969 RID: 6505 RVA: 0x000FF68D File Offset: 0x000FD88D
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x0600196A RID: 6506 RVA: 0x000FF69C File Offset: 0x000FD89C
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

	// Token: 0x04002835 RID: 10293
	public PromptScript CasePrompt;

	// Token: 0x04002836 RID: 10294
	public PromptScript KeyPrompt;

	// Token: 0x04002837 RID: 10295
	public Transform Door;

	// Token: 0x04002838 RID: 10296
	public GameObject Key;

	// Token: 0x04002839 RID: 10297
	public float Rotation;

	// Token: 0x0400283A RID: 10298
	public bool Open;
}
