using System;
using UnityEngine;

// Token: 0x020003EF RID: 1007
public class SafeScript : MonoBehaviour
{
	// Token: 0x06001BD7 RID: 7127 RVA: 0x00144AB1 File Offset: 0x00142CB1
	private void Start()
	{
		this.ContentsPrompt.MyCollider.enabled = false;
		this.SafePrompt.enabled = false;
	}

	// Token: 0x06001BD8 RID: 7128 RVA: 0x00144AD0 File Offset: 0x00142CD0
	private void Update()
	{
		if (this.Key.activeInHierarchy && this.KeyPrompt.Circle[0].fillAmount == 0f)
		{
			this.KeyPrompt.Yandere.Inventory.SafeKey = true;
			this.SafePrompt.HideButton[0] = false;
			this.SafePrompt.enabled = true;
			this.Key.SetActive(false);
		}
		if (this.SafePrompt.Circle[0].fillAmount == 0f)
		{
			this.KeyPrompt.Yandere.Inventory.SafeKey = false;
			this.ContentsPrompt.MyCollider.enabled = true;
			this.Open = true;
			this.SafePrompt.Hide();
			this.SafePrompt.enabled = false;
		}
		if (this.ContentsPrompt.Circle[0].fillAmount == 0f)
		{
			this.MissionMode.DocumentsStolen = true;
			base.enabled = false;
			this.ContentsPrompt.Hide();
			this.ContentsPrompt.enabled = false;
			this.ContentsPrompt.gameObject.SetActive(false);
		}
		if (this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
			this.Door.localEulerAngles = new Vector3(this.Door.localEulerAngles.x, this.Rotation, this.Door.localEulerAngles.z);
			if (this.Rotation < 1f)
			{
				this.Open = false;
				return;
			}
		}
		else if (this.SafePrompt.Yandere.Inventory.LockPick)
		{
			this.SafePrompt.HideButton[2] = false;
			this.SafePrompt.enabled = true;
			if (this.SafePrompt.Circle[2].fillAmount == 0f)
			{
				this.KeyPrompt.Hide();
				this.KeyPrompt.enabled = false;
				this.SafePrompt.Yandere.Inventory.LockPick = false;
				this.SafePrompt.HideButton[2] = true;
				this.ContentsPrompt.MyCollider.enabled = true;
				this.Open = true;
				return;
			}
		}
		else if (!this.SafePrompt.HideButton[2])
		{
			this.SafePrompt.HideButton[2] = true;
		}
	}

	// Token: 0x040030D6 RID: 12502
	public MissionModeScript MissionMode;

	// Token: 0x040030D7 RID: 12503
	public PromptScript ContentsPrompt;

	// Token: 0x040030D8 RID: 12504
	public PromptScript SafePrompt;

	// Token: 0x040030D9 RID: 12505
	public PromptScript KeyPrompt;

	// Token: 0x040030DA RID: 12506
	public Transform Door;

	// Token: 0x040030DB RID: 12507
	public GameObject Key;

	// Token: 0x040030DC RID: 12508
	public float Rotation;

	// Token: 0x040030DD RID: 12509
	public bool Open;
}
