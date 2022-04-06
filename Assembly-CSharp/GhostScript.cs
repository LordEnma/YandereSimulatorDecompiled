using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class GhostScript : MonoBehaviour
{
	// Token: 0x0600150B RID: 5387 RVA: 0x000D83E8 File Offset: 0x000D65E8
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

	// Token: 0x0600150C RID: 5388 RVA: 0x000D8437 File Offset: 0x000D6637
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x040021C6 RID: 8646
	public Transform SmartphoneCamera;

	// Token: 0x040021C7 RID: 8647
	public Transform Neck;

	// Token: 0x040021C8 RID: 8648
	public Transform GhostEyeLocation;

	// Token: 0x040021C9 RID: 8649
	public Transform GhostEye;

	// Token: 0x040021CA RID: 8650
	public int Frame;

	// Token: 0x040021CB RID: 8651
	public bool Move;
}
