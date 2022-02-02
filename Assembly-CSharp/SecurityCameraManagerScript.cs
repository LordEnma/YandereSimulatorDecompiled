using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C5B RID: 7259 RVA: 0x0014AEC8 File Offset: 0x001490C8
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

	// Token: 0x06001C5C RID: 7260 RVA: 0x0014AF14 File Offset: 0x00149114
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

	// Token: 0x04003250 RID: 12880
	public GameObject[] Cameras;
}
