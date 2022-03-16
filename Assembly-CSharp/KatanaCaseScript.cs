using System;
using UnityEngine;

// Token: 0x02000349 RID: 841
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x0600194F RID: 6479 RVA: 0x000FDF61 File Offset: 0x000FC161
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001950 RID: 6480 RVA: 0x000FDF70 File Offset: 0x000FC170
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

	// Token: 0x040027FD RID: 10237
	public PromptScript CasePrompt;

	// Token: 0x040027FE RID: 10238
	public PromptScript KeyPrompt;

	// Token: 0x040027FF RID: 10239
	public Transform Door;

	// Token: 0x04002800 RID: 10240
	public GameObject Key;

	// Token: 0x04002801 RID: 10241
	public float Rotation;

	// Token: 0x04002802 RID: 10242
	public bool Open;
}
