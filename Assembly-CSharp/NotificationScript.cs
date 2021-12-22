using System;
using UnityEngine;

// Token: 0x0200037D RID: 893
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A03 RID: 6659 RVA: 0x001117C0 File Offset: 0x0010F9C0
	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.Icon[0].color = new Color(1f, 1f, 1f, 1f);
			this.Icon[1].color = new Color(1f, 1f, 1f, 1f);
			this.Label.color = new Color(1f, 1f, 1f, 1f);
			this.Label.applyGradient = false;
		}
	}

	// Token: 0x06001A04 RID: 6660 RVA: 0x00111850 File Offset: 0x0010FA50
	private void Update()
	{
		if (!this.Display)
		{
			this.Panel.alpha -= Time.deltaTime * ((this.NotificationManager.NotificationsSpawned > this.ID + 2) ? 3f : 1f);
			if (this.Panel.alpha <= 0f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 4f)
			{
				this.Display = false;
			}
			if (this.NotificationManager.NotificationsSpawned > this.ID + 2)
			{
				this.Display = false;
			}
		}
	}

	// Token: 0x04002A55 RID: 10837
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A56 RID: 10838
	public UISprite[] Icon;

	// Token: 0x04002A57 RID: 10839
	public UIPanel Panel;

	// Token: 0x04002A58 RID: 10840
	public UILabel Label;

	// Token: 0x04002A59 RID: 10841
	public bool Display;

	// Token: 0x04002A5A RID: 10842
	public float Timer;

	// Token: 0x04002A5B RID: 10843
	public int ID;
}
