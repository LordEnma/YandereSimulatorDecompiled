using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C5B RID: 7259 RVA: 0x0014AFCC File Offset: 0x001491CC
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

	// Token: 0x06001C5C RID: 7260 RVA: 0x0014B018 File Offset: 0x00149218
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

	// Token: 0x04003251 RID: 12881
	public GameObject[] Cameras;
}
