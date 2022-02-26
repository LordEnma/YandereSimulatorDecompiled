using System;
using UnityEngine;

// Token: 0x02000349 RID: 841
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x06001948 RID: 6472 RVA: 0x000FD465 File Offset: 0x000FB665
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001949 RID: 6473 RVA: 0x000FD474 File Offset: 0x000FB674
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

	// Token: 0x040027CA RID: 10186
	public PromptScript CasePrompt;

	// Token: 0x040027CB RID: 10187
	public PromptScript KeyPrompt;

	// Token: 0x040027CC RID: 10188
	public Transform Door;

	// Token: 0x040027CD RID: 10189
	public GameObject Key;

	// Token: 0x040027CE RID: 10190
	public float Rotation;

	// Token: 0x040027CF RID: 10191
	public bool Open;
}
