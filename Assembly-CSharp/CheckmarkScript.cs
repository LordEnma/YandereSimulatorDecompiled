using System;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002141 RID: 8513 RVA: 0x001E941B File Offset: 0x001E761B
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002142 RID: 8514 RVA: 0x001E9458 File Offset: 0x001E7658
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

	// Token: 0x04004947 RID: 18759
	public GameObject[] Checkmarks;

	// Token: 0x04004948 RID: 18760
	public int ButtonPresses;

	// Token: 0x04004949 RID: 18761
	public int ID;
}
