using System;
using UnityEngine;

// Token: 0x0200041F RID: 1055
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C90 RID: 7312 RVA: 0x0014E4D4 File Offset: 0x0014C6D4
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

	// Token: 0x06001C91 RID: 7313 RVA: 0x0014E520 File Offset: 0x0014C720
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

	// Token: 0x040032DE RID: 13022
	public GameObject[] Cameras;
}
