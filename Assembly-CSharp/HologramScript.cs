using System;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class HologramScript : MonoBehaviour
{
	// Token: 0x06001853 RID: 6227 RVA: 0x000EAB7C File Offset: 0x000E8D7C
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x06001854 RID: 6228 RVA: 0x000EABAC File Offset: 0x000E8DAC
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x0400240B RID: 9227
	public GameObject[] Holograms;
}
