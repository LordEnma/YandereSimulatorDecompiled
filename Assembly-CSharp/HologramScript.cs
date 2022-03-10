using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HologramScript : MonoBehaviour
{
	// Token: 0x0600185C RID: 6236 RVA: 0x000EB790 File Offset: 0x000E9990
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x0600185D RID: 6237 RVA: 0x000EB7C0 File Offset: 0x000E99C0
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x0400242E RID: 9262
	public GameObject[] Holograms;
}
