using System;
using UnityEngine;

// Token: 0x020002E3 RID: 739
public class GhostScript : MonoBehaviour
{
	// Token: 0x060014F3 RID: 5363 RVA: 0x000D6D60 File Offset: 0x000D4F60
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

	// Token: 0x060014F4 RID: 5364 RVA: 0x000D6DAF File Offset: 0x000D4FAF
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x04002183 RID: 8579
	public Transform SmartphoneCamera;

	// Token: 0x04002184 RID: 8580
	public Transform Neck;

	// Token: 0x04002185 RID: 8581
	public Transform GhostEyeLocation;

	// Token: 0x04002186 RID: 8582
	public Transform GhostEye;

	// Token: 0x04002187 RID: 8583
	public int Frame;

	// Token: 0x04002188 RID: 8584
	public bool Move;
}
