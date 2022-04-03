using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HologramScript : MonoBehaviour
{
	// Token: 0x06001867 RID: 6247 RVA: 0x000EC208 File Offset: 0x000EA408
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x06001868 RID: 6248 RVA: 0x000EC238 File Offset: 0x000EA438
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x04002452 RID: 9298
	public GameObject[] Holograms;
}
