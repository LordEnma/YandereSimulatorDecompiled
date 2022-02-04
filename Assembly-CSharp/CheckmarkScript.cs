using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002110 RID: 8464 RVA: 0x001E5843 File Offset: 0x001E3A43
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002111 RID: 8465 RVA: 0x001E5880 File Offset: 0x001E3A80
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

	// Token: 0x040048AF RID: 18607
	public GameObject[] Checkmarks;

	// Token: 0x040048B0 RID: 18608
	public int ButtonPresses;

	// Token: 0x040048B1 RID: 18609
	public int ID;
}
