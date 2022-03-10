using System;
using UnityEngine;

// Token: 0x02000349 RID: 841
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x06001948 RID: 6472 RVA: 0x000FD7A5 File Offset: 0x000FB9A5
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001949 RID: 6473 RVA: 0x000FD7B4 File Offset: 0x000FB9B4
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

	// Token: 0x040027E0 RID: 10208
	public PromptScript CasePrompt;

	// Token: 0x040027E1 RID: 10209
	public PromptScript KeyPrompt;

	// Token: 0x040027E2 RID: 10210
	public Transform Door;

	// Token: 0x040027E3 RID: 10211
	public GameObject Key;

	// Token: 0x040027E4 RID: 10212
	public float Rotation;

	// Token: 0x040027E5 RID: 10213
	public bool Open;
}
