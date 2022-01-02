using System;
using UnityEngine;

// Token: 0x02000346 RID: 838
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x06001931 RID: 6449 RVA: 0x000FBEC9 File Offset: 0x000FA0C9
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001932 RID: 6450 RVA: 0x000FBED8 File Offset: 0x000FA0D8
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

	// Token: 0x040027A4 RID: 10148
	public PromptScript CasePrompt;

	// Token: 0x040027A5 RID: 10149
	public PromptScript KeyPrompt;

	// Token: 0x040027A6 RID: 10150
	public Transform Door;

	// Token: 0x040027A7 RID: 10151
	public GameObject Key;

	// Token: 0x040027A8 RID: 10152
	public float Rotation;

	// Token: 0x040027A9 RID: 10153
	public bool Open;
}
