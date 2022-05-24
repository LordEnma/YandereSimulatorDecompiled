using System;
using UnityEngine;

// Token: 0x0200050A RID: 1290
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002175 RID: 8565 RVA: 0x001EED57 File Offset: 0x001ECF57
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002176 RID: 8566 RVA: 0x001EED94 File Offset: 0x001ECF94
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

	// Token: 0x040049D5 RID: 18901
	public GameObject[] Checkmarks;

	// Token: 0x040049D6 RID: 18902
	public int ButtonPresses;

	// Token: 0x040049D7 RID: 18903
	public int ID;
}
