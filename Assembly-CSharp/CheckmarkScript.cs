using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x0600211A RID: 8474 RVA: 0x001E5EFB File Offset: 0x001E40FB
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x0600211B RID: 8475 RVA: 0x001E5F38 File Offset: 0x001E4138
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

	// Token: 0x040048BB RID: 18619
	public GameObject[] Checkmarks;

	// Token: 0x040048BC RID: 18620
	public int ButtonPresses;

	// Token: 0x040048BD RID: 18621
	public int ID;
}
