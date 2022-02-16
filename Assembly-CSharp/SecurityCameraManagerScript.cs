using System;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C64 RID: 7268 RVA: 0x0014B464 File Offset: 0x00149664
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

	// Token: 0x06001C65 RID: 7269 RVA: 0x0014B4B0 File Offset: 0x001496B0
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

	// Token: 0x0400325A RID: 12890
	public GameObject[] Cameras;
}
