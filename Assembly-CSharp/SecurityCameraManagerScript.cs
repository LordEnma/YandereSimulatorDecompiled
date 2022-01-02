using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C51 RID: 7249 RVA: 0x00149018 File Offset: 0x00147218
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

	// Token: 0x06001C52 RID: 7250 RVA: 0x00149064 File Offset: 0x00147264
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

	// Token: 0x0400323F RID: 12863
	public GameObject[] Cameras;
}
