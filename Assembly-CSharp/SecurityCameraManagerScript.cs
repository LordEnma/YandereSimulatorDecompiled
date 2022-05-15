using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C9D RID: 7325 RVA: 0x0014F990 File Offset: 0x0014DB90
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

	// Token: 0x06001C9E RID: 7326 RVA: 0x0014F9DC File Offset: 0x0014DBDC
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

	// Token: 0x04003302 RID: 13058
	public GameObject[] Cameras;
}
