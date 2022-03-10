using System;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public class GhostScript : MonoBehaviour
{
	// Token: 0x060014FC RID: 5372 RVA: 0x000D7968 File Offset: 0x000D5B68
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

	// Token: 0x060014FD RID: 5373 RVA: 0x000D79B7 File Offset: 0x000D5BB7
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x040021A6 RID: 8614
	public Transform SmartphoneCamera;

	// Token: 0x040021A7 RID: 8615
	public Transform Neck;

	// Token: 0x040021A8 RID: 8616
	public Transform GhostEyeLocation;

	// Token: 0x040021A9 RID: 8617
	public Transform GhostEye;

	// Token: 0x040021AA RID: 8618
	public int Frame;

	// Token: 0x040021AB RID: 8619
	public bool Move;
}
