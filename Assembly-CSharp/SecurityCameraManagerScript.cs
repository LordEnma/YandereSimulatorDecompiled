using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C9E RID: 7326 RVA: 0x0014FC4C File Offset: 0x0014DE4C
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

	// Token: 0x06001C9F RID: 7327 RVA: 0x0014FC98 File Offset: 0x0014DE98
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

	// Token: 0x0400330A RID: 13066
	public GameObject[] Cameras;
}
