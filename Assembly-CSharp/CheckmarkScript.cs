using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x0600210A RID: 8458 RVA: 0x001E4C8B File Offset: 0x001E2E8B
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x0600210B RID: 8459 RVA: 0x001E4CC8 File Offset: 0x001E2EC8
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

	// Token: 0x0400489E RID: 18590
	public GameObject[] Checkmarks;

	// Token: 0x0400489F RID: 18591
	public int ButtonPresses;

	// Token: 0x040048A0 RID: 18592
	public int ID;
}
