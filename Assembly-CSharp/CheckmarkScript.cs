using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x060020FD RID: 8445 RVA: 0x001E361B File Offset: 0x001E181B
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x060020FE RID: 8446 RVA: 0x001E3658 File Offset: 0x001E1858
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

	// Token: 0x04004883 RID: 18563
	public GameObject[] Checkmarks;

	// Token: 0x04004884 RID: 18564
	public int ButtonPresses;

	// Token: 0x04004885 RID: 18565
	public int ID;
}
