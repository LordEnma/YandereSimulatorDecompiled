using System;
using UnityEngine;

// Token: 0x02000312 RID: 786
public class HologramScript : MonoBehaviour
{
	// Token: 0x06001843 RID: 6211 RVA: 0x000E9D40 File Offset: 0x000E7F40
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x06001844 RID: 6212 RVA: 0x000E9D70 File Offset: 0x000E7F70
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x040023F1 RID: 9201
	public GameObject[] Holograms;
}
