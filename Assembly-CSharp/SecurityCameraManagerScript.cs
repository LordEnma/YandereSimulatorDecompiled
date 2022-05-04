using System;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C97 RID: 7319 RVA: 0x0014ECDC File Offset: 0x0014CEDC
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

	// Token: 0x06001C98 RID: 7320 RVA: 0x0014ED28 File Offset: 0x0014CF28
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

	// Token: 0x040032ED RID: 13037
	public GameObject[] Cameras;
}
