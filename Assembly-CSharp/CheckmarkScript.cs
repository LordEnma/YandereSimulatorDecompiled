using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x0600210E RID: 8462 RVA: 0x001E552B File Offset: 0x001E372B
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x001E5568 File Offset: 0x001E3768
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

	// Token: 0x040048A9 RID: 18601
	public GameObject[] Checkmarks;

	// Token: 0x040048AA RID: 18602
	public int ButtonPresses;

	// Token: 0x040048AB RID: 18603
	public int ID;
}
