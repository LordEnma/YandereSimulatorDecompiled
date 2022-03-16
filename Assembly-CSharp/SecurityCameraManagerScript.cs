using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C7C RID: 7292 RVA: 0x0014D2BC File Offset: 0x0014B4BC
	private void Start()
	{
		int i;
		if (SchoolGlobals.HighSecurity)
		{
			i = this.Cameras.Length;
		}
		else
		{
			i = PlayerGlobals.CorpsesDiscovered;
		}
		while (i > 0)
		{
			if (i < this.Cameras.Length)
			{
				this.Cameras[i].SetActive(true);
			}
			i--;
		}
	}

	// Token: 0x06001C7D RID: 7293 RVA: 0x0014D308 File Offset: 0x0014B508
	public void ActivateAllCameras()
	{
		for (int i = this.Cameras.Length; i > 0; i--)
		{
			if (i < this.Cameras.Length)
			{
				this.Cameras[i].SetActive(true);
			}
		}
	}

	// Token: 0x040032B4 RID: 12980
	public GameObject[] Cameras;
}
