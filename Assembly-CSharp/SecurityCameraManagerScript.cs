using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SecurityCameraManagerScript : MonoBehaviour
{
	// Token: 0x06001C5A RID: 7258 RVA: 0x0014AA94 File Offset: 0x00148C94
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

	// Token: 0x06001C5B RID: 7259 RVA: 0x0014AAE0 File Offset: 0x00148CE0
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

	// Token: 0x0400324A RID: 12874
	public GameObject[] Cameras;
}
