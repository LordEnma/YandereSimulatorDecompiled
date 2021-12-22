using System;
using UnityEngine;

// Token: 0x02000346 RID: 838
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x0600192F RID: 6447 RVA: 0x000FBC09 File Offset: 0x000F9E09
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001930 RID: 6448 RVA: 0x000FBC18 File Offset: 0x000F9E18
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

	// Token: 0x040027A0 RID: 10144
	public PromptScript CasePrompt;

	// Token: 0x040027A1 RID: 10145
	public PromptScript KeyPrompt;

	// Token: 0x040027A2 RID: 10146
	public Transform Door;

	// Token: 0x040027A3 RID: 10147
	public GameObject Key;

	// Token: 0x040027A4 RID: 10148
	public float Rotation;

	// Token: 0x040027A5 RID: 10149
	public bool Open;
}
