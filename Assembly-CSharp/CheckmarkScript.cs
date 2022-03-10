using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002129 RID: 8489 RVA: 0x001E74B3 File Offset: 0x001E56B3
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x0600212A RID: 8490 RVA: 0x001E74F0 File Offset: 0x001E56F0
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

	// Token: 0x040048E8 RID: 18664
	public GameObject[] Checkmarks;

	// Token: 0x040048E9 RID: 18665
	public int ButtonPresses;

	// Token: 0x040048EA RID: 18666
	public int ID;
}
