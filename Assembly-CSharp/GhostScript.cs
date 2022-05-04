using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class GhostScript : MonoBehaviour
{
	// Token: 0x06001511 RID: 5393 RVA: 0x000D8A6C File Offset: 0x000D6C6C
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

	// Token: 0x06001512 RID: 5394 RVA: 0x000D8ABB File Offset: 0x000D6CBB
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x040021D1 RID: 8657
	public Transform SmartphoneCamera;

	// Token: 0x040021D2 RID: 8658
	public Transform Neck;

	// Token: 0x040021D3 RID: 8659
	public Transform GhostEyeLocation;

	// Token: 0x040021D4 RID: 8660
	public Transform GhostEye;

	// Token: 0x040021D5 RID: 8661
	public int Frame;

	// Token: 0x040021D6 RID: 8662
	public bool Move;
}
