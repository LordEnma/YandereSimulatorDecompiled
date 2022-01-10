using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002108 RID: 8456 RVA: 0x001E3FBB File Offset: 0x001E21BB
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x001E3FF8 File Offset: 0x001E21F8
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

	// Token: 0x04004897 RID: 18583
	public GameObject[] Checkmarks;

	// Token: 0x04004898 RID: 18584
	public int ButtonPresses;

	// Token: 0x04004899 RID: 18585
	public int ID;
}
