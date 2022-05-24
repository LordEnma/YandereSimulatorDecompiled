using System;
using UnityEngine;

// Token: 0x020000E3 RID: 227
public class BefriendBetrayPauseScript : MonoBehaviour
{
	// Token: 0x06000A26 RID: 2598 RVA: 0x0005A3CE File Offset: 0x000585CE
	private void Start()
	{
		this.Panel.enabled = false;
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x0005A3DC File Offset: 0x000585DC
	private void Update()
	{
		if (this.Yandere.CanMove && Input.GetButtonDown("Start"))
		{
			if (!this.Panel.enabled)
			{
				this.Panel.enabled = true;
				Time.timeScale = 0f;
				return;
			}
			this.Panel.enabled = false;
			Time.timeScale = 1f;
		}
	}

	// Token: 0x04000B87 RID: 2951
	public StalkerYandereScript Yandere;

	// Token: 0x04000B88 RID: 2952
	public UIPanel Panel;
}
