using System;
using UnityEngine;

// Token: 0x02000345 RID: 837
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x06001928 RID: 6440 RVA: 0x000FB3F9 File Offset: 0x000F95F9
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001929 RID: 6441 RVA: 0x000FB408 File Offset: 0x000F9608
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

	// Token: 0x0400277B RID: 10107
	public PromptScript CasePrompt;

	// Token: 0x0400277C RID: 10108
	public PromptScript KeyPrompt;

	// Token: 0x0400277D RID: 10109
	public Transform Door;

	// Token: 0x0400277E RID: 10110
	public GameObject Key;

	// Token: 0x0400277F RID: 10111
	public float Rotation;

	// Token: 0x04002780 RID: 10112
	public bool Open;
}
