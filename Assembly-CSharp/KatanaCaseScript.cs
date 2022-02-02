using System;
using UnityEngine;

// Token: 0x02000347 RID: 839
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x06001936 RID: 6454 RVA: 0x000FC7C9 File Offset: 0x000FA9C9
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001937 RID: 6455 RVA: 0x000FC7D8 File Offset: 0x000FA9D8
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

	// Token: 0x040027B1 RID: 10161
	public PromptScript CasePrompt;

	// Token: 0x040027B2 RID: 10162
	public PromptScript KeyPrompt;

	// Token: 0x040027B3 RID: 10163
	public Transform Door;

	// Token: 0x040027B4 RID: 10164
	public GameObject Key;

	// Token: 0x040027B5 RID: 10165
	public float Rotation;

	// Token: 0x040027B6 RID: 10166
	public bool Open;
}
