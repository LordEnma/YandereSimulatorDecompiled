using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A41 RID: 6721 RVA: 0x00115A08 File Offset: 0x00113C08
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

	// Token: 0x06001A42 RID: 6722 RVA: 0x00115A98 File Offset: 0x00113C98
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

	// Token: 0x04002AFA RID: 11002
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002AFB RID: 11003
	public UISprite[] Icon;

	// Token: 0x04002AFC RID: 11004
	public UIPanel Panel;

	// Token: 0x04002AFD RID: 11005
	public UILabel Label;

	// Token: 0x04002AFE RID: 11006
	public bool Display;

	// Token: 0x04002AFF RID: 11007
	public float Timer;

	// Token: 0x04002B00 RID: 11008
	public int ID;
}
