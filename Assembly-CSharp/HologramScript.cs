using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HologramScript : MonoBehaviour
{
	// Token: 0x06001861 RID: 6241 RVA: 0x000EBC50 File Offset: 0x000E9E50
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x06001862 RID: 6242 RVA: 0x000EBC80 File Offset: 0x000E9E80
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x0400243F RID: 9279
	public GameObject[] Holograms;
}
