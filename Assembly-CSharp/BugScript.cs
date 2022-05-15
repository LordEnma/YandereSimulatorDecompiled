using System;
using UnityEngine;

// Token: 0x02000101 RID: 257
public class BugScript : MonoBehaviour
{
	// Token: 0x06000A93 RID: 2707 RVA: 0x0005F8DB File Offset: 0x0005DADB
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.gameObject.SetActive(false);
		}
		this.MyRenderer.enabled = false;
	}

	// Token: 0x06000A94 RID: 2708 RVA: 0x0005F914 File Offset: 0x0005DB14
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.MyAudio.clip = this.Praise[UnityEngine.Random.Range(0, this.Praise.Length)];
			this.MyAudio.Play();
			this.MyRenderer.enabled = true;
			this.Prompt.Yandere.Inventory.PantyShots += 5;
			this.Prompt.Yandere.NotificationManager.CustomText = "+5 Info Points! You have " + this.Prompt.Yandere.Inventory.PantyShots.ToString() + " in total";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			this.Placed = true;
			base.enabled = false;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x06000A95 RID: 2709 RVA: 0x0005FA0B File Offset: 0x0005DC0B
	public void CheckStatus()
	{
		if (this.Placed)
		{
			this.MyRenderer.enabled = true;
			base.enabled = false;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x04000C7F RID: 3199
	public PromptScript Prompt;

	// Token: 0x04000C80 RID: 3200
	public Renderer MyRenderer;

	// Token: 0x04000C81 RID: 3201
	public AudioSource MyAudio;

	// Token: 0x04000C82 RID: 3202
	public AudioClip[] Praise;

	// Token: 0x04000C83 RID: 3203
	public bool Placed;
}
