using System;
using UnityEngine;

// Token: 0x020002E2 RID: 738
public class GhostScript : MonoBehaviour
{
	// Token: 0x060014EE RID: 5358 RVA: 0x000D6C6C File Offset: 0x000D4E6C
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

	// Token: 0x060014EF RID: 5359 RVA: 0x000D6CBB File Offset: 0x000D4EBB
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x0400217E RID: 8574
	public Transform SmartphoneCamera;

	// Token: 0x0400217F RID: 8575
	public Transform Neck;

	// Token: 0x04002180 RID: 8576
	public Transform GhostEyeLocation;

	// Token: 0x04002181 RID: 8577
	public Transform GhostEye;

	// Token: 0x04002182 RID: 8578
	public int Frame;

	// Token: 0x04002183 RID: 8579
	public bool Move;
}
