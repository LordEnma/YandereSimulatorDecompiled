using System;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002159 RID: 8537 RVA: 0x001EB1BB File Offset: 0x001E93BB
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x0600215A RID: 8538 RVA: 0x001EB1F8 File Offset: 0x001E93F8
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

	// Token: 0x0400497D RID: 18813
	public GameObject[] Checkmarks;

	// Token: 0x0400497E RID: 18814
	public int ButtonPresses;

	// Token: 0x0400497F RID: 18815
	public int ID;
}
