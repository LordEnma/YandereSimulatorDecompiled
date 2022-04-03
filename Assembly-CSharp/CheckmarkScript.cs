using System;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002151 RID: 8529 RVA: 0x001EAC8B File Offset: 0x001E8E8B
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x001EACC8 File Offset: 0x001E8EC8
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

	// Token: 0x04004979 RID: 18809
	public GameObject[] Checkmarks;

	// Token: 0x0400497A RID: 18810
	public int ButtonPresses;

	// Token: 0x0400497B RID: 18811
	public int ID;
}
