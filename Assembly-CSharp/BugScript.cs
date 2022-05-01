using System;
using UnityEngine;

// Token: 0x02000100 RID: 256
public class BugScript : MonoBehaviour
{
	// Token: 0x06000A91 RID: 2705 RVA: 0x0005F563 File Offset: 0x0005D763
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

	// Token: 0x06000A92 RID: 2706 RVA: 0x0005F59C File Offset: 0x0005D79C
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

	// Token: 0x06000A93 RID: 2707 RVA: 0x0005F693 File Offset: 0x0005D893
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

	// Token: 0x04000C79 RID: 3193
	public PromptScript Prompt;

	// Token: 0x04000C7A RID: 3194
	public Renderer MyRenderer;

	// Token: 0x04000C7B RID: 3195
	public AudioSource MyAudio;

	// Token: 0x04000C7C RID: 3196
	public AudioClip[] Praise;

	// Token: 0x04000C7D RID: 3197
	public bool Placed;
}
