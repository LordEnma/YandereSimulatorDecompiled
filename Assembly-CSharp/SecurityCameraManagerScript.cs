using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C47 RID: 7239 RVA: 0x00148334 File Offset: 0x00146534
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

	// Token: 0x06001C48 RID: 7240 RVA: 0x00148380 File Offset: 0x00146580
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

	// Token: 0x0400320D RID: 12813
	public GameObject[] Cameras;
}
