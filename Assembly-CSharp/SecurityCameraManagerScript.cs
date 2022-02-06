using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C5D RID: 7261 RVA: 0x0014B164 File Offset: 0x00149364
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

	// Token: 0x06001C5E RID: 7262 RVA: 0x0014B1B0 File Offset: 0x001493B0
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

	// Token: 0x04003254 RID: 12884
	public GameObject[] Cameras;
}
