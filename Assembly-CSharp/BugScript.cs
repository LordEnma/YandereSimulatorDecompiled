using System;
using UnityEngine;

// Token: 0x020000FF RID: 255
public class BugScript : MonoBehaviour
{
	// Token: 0x06000A8B RID: 2699 RVA: 0x0005EA74 File Offset: 0x0005CC74
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

	// Token: 0x06000A8C RID: 2700 RVA: 0x0005EAAC File Offset: 0x0005CCAC
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

	// Token: 0x06000A8D RID: 2701 RVA: 0x0005EBA3 File Offset: 0x0005CDA3
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

	// Token: 0x04000C60 RID: 3168
	public PromptScript Prompt;

	// Token: 0x04000C61 RID: 3169
	public Renderer MyRenderer;

	// Token: 0x04000C62 RID: 3170
	public AudioSource MyAudio;

	// Token: 0x04000C63 RID: 3171
	public AudioClip[] Praise;

	// Token: 0x04000C64 RID: 3172
	public bool Placed;
}
