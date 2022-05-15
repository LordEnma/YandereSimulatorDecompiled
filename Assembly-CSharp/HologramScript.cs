using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HologramScript : MonoBehaviour
{
	// Token: 0x0600187A RID: 6266 RVA: 0x000ECD70 File Offset: 0x000EAF70
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x0600187B RID: 6267 RVA: 0x000ECDA0 File Offset: 0x000EAFA0
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x04002471 RID: 9329
	public GameObject[] Holograms;
}
