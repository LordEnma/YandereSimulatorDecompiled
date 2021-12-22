using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C4F RID: 7247 RVA: 0x00148C10 File Offset: 0x00146E10
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

	// Token: 0x06001C50 RID: 7248 RVA: 0x00148C5C File Offset: 0x00146E5C
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

	// Token: 0x04003238 RID: 12856
	public GameObject[] Cameras;
}
