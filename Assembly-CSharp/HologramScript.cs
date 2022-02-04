using System;
using UnityEngine;

// Token: 0x02000313 RID: 787
public class HologramScript : MonoBehaviour
{
	// Token: 0x0600184A RID: 6218 RVA: 0x000EA91C File Offset: 0x000E8B1C
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x0600184B RID: 6219 RVA: 0x000EA94C File Offset: 0x000E8B4C
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x04002402 RID: 9218
	public GameObject[] Holograms;
}
