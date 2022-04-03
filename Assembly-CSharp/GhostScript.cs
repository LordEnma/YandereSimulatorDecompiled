using System;
using UnityEngine;

// Token: 0x020002E5 RID: 741
public class GhostScript : MonoBehaviour
{
	// Token: 0x06001505 RID: 5381 RVA: 0x000D82D8 File Offset: 0x000D64D8
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

	// Token: 0x06001506 RID: 5382 RVA: 0x000D8327 File Offset: 0x000D6527
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x040021C4 RID: 8644
	public Transform SmartphoneCamera;

	// Token: 0x040021C5 RID: 8645
	public Transform Neck;

	// Token: 0x040021C6 RID: 8646
	public Transform GhostEyeLocation;

	// Token: 0x040021C7 RID: 8647
	public Transform GhostEye;

	// Token: 0x040021C8 RID: 8648
	public int Frame;

	// Token: 0x040021C9 RID: 8649
	public bool Move;
}
