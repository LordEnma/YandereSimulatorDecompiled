using System;
using UnityEngine;

// Token: 0x020002E1 RID: 737
public class GhostScript : MonoBehaviour
{
	// Token: 0x060014E9 RID: 5353 RVA: 0x000D6080 File Offset: 0x000D4280
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

	// Token: 0x060014EA RID: 5354 RVA: 0x000D60CF File Offset: 0x000D42CF
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x0400216C RID: 8556
	public Transform SmartphoneCamera;

	// Token: 0x0400216D RID: 8557
	public Transform Neck;

	// Token: 0x0400216E RID: 8558
	public Transform GhostEyeLocation;

	// Token: 0x0400216F RID: 8559
	public Transform GhostEye;

	// Token: 0x04002170 RID: 8560
	public int Frame;

	// Token: 0x04002171 RID: 8561
	public bool Move;
}
