using System;
using UnityEngine;

// Token: 0x02000313 RID: 787
public class HologramScript : MonoBehaviour
{
	// Token: 0x06001849 RID: 6217 RVA: 0x000EA35C File Offset: 0x000E855C
	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	// Token: 0x0600184A RID: 6218 RVA: 0x000EA38C File Offset: 0x000E858C
	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}

	// Token: 0x040023F9 RID: 9209
	public GameObject[] Holograms;
}
