using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002123 RID: 8483 RVA: 0x001E6ADB File Offset: 0x001E4CDB
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x001E6B18 File Offset: 0x001E4D18
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

	// Token: 0x040048CB RID: 18635
	public GameObject[] Checkmarks;

	// Token: 0x040048CC RID: 18636
	public int ButtonPresses;

	// Token: 0x040048CD RID: 18637
	public int ID;
}
