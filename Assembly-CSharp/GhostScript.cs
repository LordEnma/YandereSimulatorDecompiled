using System;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public class GhostScript : MonoBehaviour
{
	// Token: 0x060014FF RID: 5375 RVA: 0x000D7DD8 File Offset: 0x000D5FD8
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

	// Token: 0x06001500 RID: 5376 RVA: 0x000D7E27 File Offset: 0x000D6027
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x040021B6 RID: 8630
	public Transform SmartphoneCamera;

	// Token: 0x040021B7 RID: 8631
	public Transform Neck;

	// Token: 0x040021B8 RID: 8632
	public Transform GhostEyeLocation;

	// Token: 0x040021B9 RID: 8633
	public Transform GhostEye;

	// Token: 0x040021BA RID: 8634
	public int Frame;

	// Token: 0x040021BB RID: 8635
	public bool Move;
}
