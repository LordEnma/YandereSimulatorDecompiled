using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A27 RID: 6695 RVA: 0x0011419C File Offset: 0x0011239C
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

	// Token: 0x06001A28 RID: 6696 RVA: 0x0011422C File Offset: 0x0011242C
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

	// Token: 0x04002AC1 RID: 10945
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002AC2 RID: 10946
	public UISprite[] Icon;

	// Token: 0x04002AC3 RID: 10947
	public UIPanel Panel;

	// Token: 0x04002AC4 RID: 10948
	public UILabel Label;

	// Token: 0x04002AC5 RID: 10949
	public bool Display;

	// Token: 0x04002AC6 RID: 10950
	public float Timer;

	// Token: 0x04002AC7 RID: 10951
	public int ID;
}
