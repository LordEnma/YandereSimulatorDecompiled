using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C58 RID: 7256 RVA: 0x0014938C File Offset: 0x0014758C
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

	// Token: 0x06001C59 RID: 7257 RVA: 0x001493D8 File Offset: 0x001475D8
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

	// Token: 0x04003245 RID: 12869
	public GameObject[] Cameras;
}
