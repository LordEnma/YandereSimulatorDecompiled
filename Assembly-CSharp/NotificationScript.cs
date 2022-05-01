using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A3B RID: 6715 RVA: 0x00115164 File Offset: 0x00113364
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

	// Token: 0x06001A3C RID: 6716 RVA: 0x001151F4 File Offset: 0x001133F4
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

	// Token: 0x04002AE8 RID: 10984
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002AE9 RID: 10985
	public UISprite[] Icon;

	// Token: 0x04002AEA RID: 10986
	public UIPanel Panel;

	// Token: 0x04002AEB RID: 10987
	public UILabel Label;

	// Token: 0x04002AEC RID: 10988
	public bool Display;

	// Token: 0x04002AED RID: 10989
	public float Timer;

	// Token: 0x04002AEE RID: 10990
	public int ID;
}
