using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HologramScript : MonoBehaviour
{
	// Token: 0x0600187A RID: 6266 RVA: 0x000ECEEC File Offset: 0x000EB0EC
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x0600187B RID: 6267 RVA: 0x000ECF1C File Offset: 0x000EB11C
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x04002472 RID: 9330
	public GameObject[] Holograms;
}
