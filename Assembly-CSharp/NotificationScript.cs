using System;
using UnityEngine;

// Token: 0x0200037C RID: 892
public class NotificationScript : MonoBehaviour
{
	// Token: 0x060019FB RID: 6651 RVA: 0x00110FC4 File Offset: 0x0010F1C4
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

	// Token: 0x060019FC RID: 6652 RVA: 0x00111054 File Offset: 0x0010F254
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

	// Token: 0x04002A2E RID: 10798
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A2F RID: 10799
	public UISprite[] Icon;

	// Token: 0x04002A30 RID: 10800
	public UIPanel Panel;

	// Token: 0x04002A31 RID: 10801
	public UILabel Label;

	// Token: 0x04002A32 RID: 10802
	public bool Display;

	// Token: 0x04002A33 RID: 10803
	public float Timer;

	// Token: 0x04002A34 RID: 10804
	public int ID;
}
