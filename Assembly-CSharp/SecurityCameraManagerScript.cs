using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C6F RID: 7279 RVA: 0x0014C418 File Offset: 0x0014A618
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

	// Token: 0x06001C70 RID: 7280 RVA: 0x0014C464 File Offset: 0x0014A664
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

	// Token: 0x04003280 RID: 12928
	public GameObject[] Cameras;
}
