using System;
using UnityEngine;

// Token: 0x02000348 RID: 840
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x0600193F RID: 6463 RVA: 0x000FCB35 File Offset: 0x000FAD35
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001940 RID: 6464 RVA: 0x000FCB44 File Offset: 0x000FAD44
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

	// Token: 0x040027BB RID: 10171
	public PromptScript CasePrompt;

	// Token: 0x040027BC RID: 10172
	public PromptScript KeyPrompt;

	// Token: 0x040027BD RID: 10173
	public Transform Door;

	// Token: 0x040027BE RID: 10174
	public GameObject Key;

	// Token: 0x040027BF RID: 10175
	public float Rotation;

	// Token: 0x040027C0 RID: 10176
	public bool Open;
}
