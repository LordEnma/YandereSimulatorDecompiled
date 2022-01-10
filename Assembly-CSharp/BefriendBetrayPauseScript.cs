using System;
using UnityEngine;

// Token: 0x020000E2 RID: 226
public class BefriendBetrayPauseScript : MonoBehaviour
{
	// Token: 0x06000A24 RID: 2596 RVA: 0x00059DDA File Offset: 0x00057FDA
	private void Start()
	{
		this.Panel.enabled = false;
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x00059DE8 File Offset: 0x00057FE8
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

	// Token: 0x04000B75 RID: 2933
	public StalkerYandereScript Yandere;

	// Token: 0x04000B76 RID: 2934
	public UIPanel Panel;
}
