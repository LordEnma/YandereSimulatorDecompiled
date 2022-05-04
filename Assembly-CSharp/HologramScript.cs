using System;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HologramScript : MonoBehaviour
{
	// Token: 0x06001875 RID: 6261 RVA: 0x000ECA70 File Offset: 0x000EAC70
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x06001876 RID: 6262 RVA: 0x000ECAA0 File Offset: 0x000EACA0
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x04002466 RID: 9318
	public GameObject[] Holograms;
}
