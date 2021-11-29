using System;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x060020E9 RID: 8425 RVA: 0x001E18F7 File Offset: 0x001DFAF7
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x060020EA RID: 8426 RVA: 0x001E1934 File Offset: 0x001DFB34
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

	// Token: 0x0400483B RID: 18491
	public GameObject[] Checkmarks;

	// Token: 0x0400483C RID: 18492
	public int ButtonPresses;

	// Token: 0x0400483D RID: 18493
	public int ID;
}
