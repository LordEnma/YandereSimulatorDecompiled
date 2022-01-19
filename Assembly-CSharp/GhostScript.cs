using System;
using UnityEngine;

// Token: 0x020002E2 RID: 738
public class GhostScript : MonoBehaviour
{
	// Token: 0x060014ED RID: 5357 RVA: 0x000D66E4 File Offset: 0x000D48E4
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

	// Token: 0x060014EE RID: 5358 RVA: 0x000D6733 File Offset: 0x000D4933
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x04002176 RID: 8566
	public Transform SmartphoneCamera;

	// Token: 0x04002177 RID: 8567
	public Transform Neck;

	// Token: 0x04002178 RID: 8568
	public Transform GhostEyeLocation;

	// Token: 0x04002179 RID: 8569
	public Transform GhostEye;

	// Token: 0x0400217A RID: 8570
	public int Frame;

	// Token: 0x0400217B RID: 8571
	public bool Move;
}
