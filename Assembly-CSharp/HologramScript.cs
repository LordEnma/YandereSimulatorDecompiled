using System;
using UnityEngine;

// Token: 0x02000313 RID: 787
public class HologramScript : MonoBehaviour
{
	// Token: 0x0600184C RID: 6220 RVA: 0x000EAA08 File Offset: 0x000E8C08
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x0600184D RID: 6221 RVA: 0x000EAA38 File Offset: 0x000E8C38
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x04002405 RID: 9221
	public GameObject[] Holograms;
}
