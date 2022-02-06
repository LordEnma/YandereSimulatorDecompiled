using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002113 RID: 8467 RVA: 0x001E5A47 File Offset: 0x001E3C47
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x001E5A84 File Offset: 0x001E3C84
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

	// Token: 0x040048B2 RID: 18610
	public GameObject[] Checkmarks;

	// Token: 0x040048B3 RID: 18611
	public int ButtonPresses;

	// Token: 0x040048B4 RID: 18612
	public int ID;
}
