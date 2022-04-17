using System;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HologramScript : MonoBehaviour
{
	// Token: 0x06001871 RID: 6257 RVA: 0x000EC5A8 File Offset: 0x000EA7A8
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x06001872 RID: 6258 RVA: 0x000EC5D8 File Offset: 0x000EA7D8
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x0400245D RID: 9309
	public GameObject[] Holograms;
}
