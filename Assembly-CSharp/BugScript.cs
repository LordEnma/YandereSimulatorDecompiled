using System;
using UnityEngine;

// Token: 0x02000100 RID: 256
public class BugScript : MonoBehaviour
{
	// Token: 0x06000A8F RID: 2703 RVA: 0x0005EE90 File Offset: 0x0005D090
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

	// Token: 0x06000A90 RID: 2704 RVA: 0x0005EEC8 File Offset: 0x0005D0C8
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

	// Token: 0x06000A91 RID: 2705 RVA: 0x0005EFBF File Offset: 0x0005D1BF
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

	// Token: 0x04000C6F RID: 3183
	public PromptScript Prompt;

	// Token: 0x04000C70 RID: 3184
	public Renderer MyRenderer;

	// Token: 0x04000C71 RID: 3185
	public AudioSource MyAudio;

	// Token: 0x04000C72 RID: 3186
	public AudioClip[] Praise;

	// Token: 0x04000C73 RID: 3187
	public bool Placed;
}
