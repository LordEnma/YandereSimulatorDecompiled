using System;
using UnityEngine;

// Token: 0x0200050A RID: 1290
public class CheckmarkScript : MonoBehaviour
{
	// Token: 0x06002174 RID: 8564 RVA: 0x001EE7EF File Offset: 0x001EC9EF
	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x06002175 RID: 8565 RVA: 0x001EE82C File Offset: 0x001ECA2C
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

	// Token: 0x040049CC RID: 18892
	public GameObject[] Checkmarks;

	// Token: 0x040049CD RID: 18893
	public int ButtonPresses;

	// Token: 0x040049CE RID: 18894
	public int ID;
}
