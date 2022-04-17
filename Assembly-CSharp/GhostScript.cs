using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class GhostScript : MonoBehaviour
{
	// Token: 0x0600150D RID: 5389 RVA: 0x000D85D0 File Offset: 0x000D67D0
	private void Update()
	{
		if (Time.timeScale > 0.0001f)
		{
			if (this.Frame > 0)
			{
				base.GetComponent<Animation>().enabled = false;
				base.gameObject.SetActive(false);
				this.Frame = 0;
			}
			this.Frame++;
		}
	}

	// Token: 0x0600150E RID: 5390 RVA: 0x000D861F File Offset: 0x000D681F
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x040021C8 RID: 8648
	public Transform SmartphoneCamera;

	// Token: 0x040021C9 RID: 8649
	public Transform Neck;

	// Token: 0x040021CA RID: 8650
	public Transform GhostEyeLocation;

	// Token: 0x040021CB RID: 8651
	public Transform GhostEye;

	// Token: 0x040021CC RID: 8652
	public int Frame;

	// Token: 0x040021CD RID: 8653
	public bool Move;
}
