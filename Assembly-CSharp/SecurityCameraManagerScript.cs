using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C86 RID: 7302 RVA: 0x0014DDE0 File Offset: 0x0014BFE0
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

	// Token: 0x06001C87 RID: 7303 RVA: 0x0014DE2C File Offset: 0x0014C02C
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

	// Token: 0x040032D0 RID: 13008
	public GameObject[] Cameras;
}
