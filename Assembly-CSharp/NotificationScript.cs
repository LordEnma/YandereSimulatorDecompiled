using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A42 RID: 6722 RVA: 0x00115C38 File Offset: 0x00113E38
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

	// Token: 0x06001A43 RID: 6723 RVA: 0x00115CC8 File Offset: 0x00113EC8
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

	// Token: 0x04002B01 RID: 11009
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002B02 RID: 11010
	public UISprite[] Icon;

	// Token: 0x04002B03 RID: 11011
	public UIPanel Panel;

	// Token: 0x04002B04 RID: 11012
	public UILabel Label;

	// Token: 0x04002B05 RID: 11013
	public bool Display;

	// Token: 0x04002B06 RID: 11014
	public float Timer;

	// Token: 0x04002B07 RID: 11015
	public int ID;
}
