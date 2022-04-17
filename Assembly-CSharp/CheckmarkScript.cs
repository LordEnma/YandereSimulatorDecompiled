using System;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002160 RID: 8544 RVA: 0x001EBC17 File Offset: 0x001E9E17
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002161 RID: 8545 RVA: 0x001EBC54 File Offset: 0x001E9E54
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

	// Token: 0x0400498F RID: 18831
	public GameObject[] Checkmarks;

	// Token: 0x04004990 RID: 18832
	public int ButtonPresses;

	// Token: 0x04004991 RID: 18833
	public int ID;
}
