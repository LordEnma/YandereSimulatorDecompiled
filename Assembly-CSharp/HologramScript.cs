using System;
using UnityEngine;

// Token: 0x02000312 RID: 786
public class HologramScript : MonoBehaviour
{
	// Token: 0x06001845 RID: 6213 RVA: 0x000EA024 File Offset: 0x000E8224
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x06001846 RID: 6214 RVA: 0x000EA054 File Offset: 0x000E8254
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x040023F5 RID: 9205
	public GameObject[] Holograms;
}
