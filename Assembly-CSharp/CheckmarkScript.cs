using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x060020FA RID: 8442 RVA: 0x001E302B File Offset: 0x001E122B
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E3068 File Offset: 0x001E1268
	private void Update()
	{
		if (Input.GetKeyDown("space") && this.ButtonPresses < 26)
		{
			this.ButtonPresses++;
			this.ID = UnityEngine.Random.Range(0, this.Checkmarks.Length - 4);
			while (this.Checkmarks[this.ID].active)
			{
				this.ID = UnityEngine.Random.Range(0, this.Checkmarks.Length - 4);
			}
			this.Checkmarks[this.ID].SetActive(true);
		}
	}

	// Token: 0x0400487A RID: 18554
	public GameObject[] Checkmarks;

	// Token: 0x0400487B RID: 18555
	public int ButtonPresses;

	// Token: 0x0400487C RID: 18556
	public int ID;
}
