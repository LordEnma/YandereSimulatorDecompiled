using System;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public class GhostScript : MonoBehaviour
{
	// Token: 0x06001513 RID: 5395 RVA: 0x000D8D54 File Offset: 0x000D6F54
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

	// Token: 0x06001514 RID: 5396 RVA: 0x000D8DA3 File Offset: 0x000D6FA3
	public void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x040021DA RID: 8666
	public Transform SmartphoneCamera;

	// Token: 0x040021DB RID: 8667
	public Transform Neck;

	// Token: 0x040021DC RID: 8668
	public Transform GhostEyeLocation;

	// Token: 0x040021DD RID: 8669
	public Transform GhostEye;

	// Token: 0x040021DE RID: 8670
	public int Frame;

	// Token: 0x040021DF RID: 8671
	public bool Move;
}
