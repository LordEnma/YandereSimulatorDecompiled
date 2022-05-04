using System;
using UnityEngine;

// Token: 0x02000509 RID: 1289
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x0600216A RID: 8554 RVA: 0x001ED19F File Offset: 0x001EB39F
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x0600216B RID: 8555 RVA: 0x001ED1DC File Offset: 0x001EB3DC
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

	// Token: 0x040049A5 RID: 18853
	public GameObject[] Checkmarks;

	// Token: 0x040049A6 RID: 18854
	public int ButtonPresses;

	// Token: 0x040049A7 RID: 18855
	public int ID;
}
