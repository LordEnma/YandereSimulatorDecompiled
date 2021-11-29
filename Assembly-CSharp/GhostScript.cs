using System;
using UnityEngine;

// Token: 0x020002E0 RID: 736
public class GhostScript : MonoBehaviour
{
	// Token: 0x060014E2 RID: 5346 RVA: 0x000D58C0 File Offset: 0x000D3AC0
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

	// Token: 0x060014E3 RID: 5347 RVA: 0x000D590F File Offset: 0x000D3B0F
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x0400214C RID: 8524
	public Transform SmartphoneCamera;

	// Token: 0x0400214D RID: 8525
	public Transform Neck;

	// Token: 0x0400214E RID: 8526
	public Transform GhostEyeLocation;

	// Token: 0x0400214F RID: 8527
	public Transform GhostEye;

	// Token: 0x04002150 RID: 8528
	public int Frame;

	// Token: 0x04002151 RID: 8529
	public bool Move;
}
