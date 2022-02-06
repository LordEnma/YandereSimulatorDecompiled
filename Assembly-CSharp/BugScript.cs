using System;
using UnityEngine;

// Token: 0x02000100 RID: 256
public class BugScript : MonoBehaviour
{
	// Token: 0x06000A8E RID: 2702 RVA: 0x0005EC10 File Offset: 0x0005CE10
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

	// Token: 0x06000A8F RID: 2703 RVA: 0x0005EC48 File Offset: 0x0005CE48
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

	// Token: 0x06000A90 RID: 2704 RVA: 0x0005ED3F File Offset: 0x0005CF3F
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

	// Token: 0x04000C65 RID: 3173
	public PromptScript Prompt;

	// Token: 0x04000C66 RID: 3174
	public Renderer MyRenderer;

	// Token: 0x04000C67 RID: 3175
	public AudioSource MyAudio;

	// Token: 0x04000C68 RID: 3176
	public AudioClip[] Praise;

	// Token: 0x04000C69 RID: 3177
	public bool Placed;
}
