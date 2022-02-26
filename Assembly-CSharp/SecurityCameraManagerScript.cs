using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C6D RID: 7277 RVA: 0x0014BEDC File Offset: 0x0014A0DC
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

	// Token: 0x06001C6E RID: 7278 RVA: 0x0014BF28 File Offset: 0x0014A128
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

	// Token: 0x0400326A RID: 12906
	public GameObject[] Cameras;
}
