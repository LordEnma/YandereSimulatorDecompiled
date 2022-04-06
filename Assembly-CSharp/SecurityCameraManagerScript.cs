using System;
using UnityEngine;

// Token: 0x0200041F RID: 1055
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C8C RID: 7308 RVA: 0x0014E0C4 File Offset: 0x0014C2C4
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

	// Token: 0x06001C8D RID: 7309 RVA: 0x0014E110 File Offset: 0x0014C310
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

	// Token: 0x040032D3 RID: 13011
	public GameObject[] Cameras;
}
