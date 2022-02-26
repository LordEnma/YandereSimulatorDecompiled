using System;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public class GhostScript : MonoBehaviour
{
	// Token: 0x060014FC RID: 5372 RVA: 0x000D7644 File Offset: 0x000D5844
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

	// Token: 0x060014FD RID: 5373 RVA: 0x000D7693 File Offset: 0x000D5893
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x04002192 RID: 8594
	public Transform SmartphoneCamera;

	// Token: 0x04002193 RID: 8595
	public Transform Neck;

	// Token: 0x04002194 RID: 8596
	public Transform GhostEyeLocation;

	// Token: 0x04002195 RID: 8597
	public Transform GhostEye;

	// Token: 0x04002196 RID: 8598
	public int Frame;

	// Token: 0x04002197 RID: 8599
	public bool Move;
}
