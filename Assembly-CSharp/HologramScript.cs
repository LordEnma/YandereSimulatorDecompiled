using System;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HologramScript : MonoBehaviour
{
	// Token: 0x0600186D RID: 6253 RVA: 0x000EC308 File Offset: 0x000EA508
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x0600186E RID: 6254 RVA: 0x000EC338 File Offset: 0x000EA538
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x04002455 RID: 9301
	public GameObject[] Holograms;
}
