using System;
using UnityEngine;

// Token: 0x02000311 RID: 785
public class HologramScript : MonoBehaviour
{
	// Token: 0x0600183C RID: 6204 RVA: 0x000E9580 File Offset: 0x000E7780
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x0600183D RID: 6205 RVA: 0x000E95B0 File Offset: 0x000E77B0
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x040023D1 RID: 9169
	public GameObject[] Holograms;
}
