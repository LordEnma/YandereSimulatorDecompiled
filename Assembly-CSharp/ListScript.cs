using System;
using UnityEngine;

// Token: 0x02000353 RID: 851
public class ListScript : MonoBehaviour
{
	// Token: 0x06001967 RID: 6503 RVA: 0x000FF0A4 File Offset: 0x000FD2A4
	public void Start()
	{
		if (this.AutoFill)
		{
			for (int i = 1; i < this.List.Length; i++)
			{
				this.List[i] = base.transform.GetChild(i - 1);
			}
		}
	}

	// Token: 0x0400282C RID: 10284
	public Transform[] List;

	// Token: 0x0400282D RID: 10285
	public bool AutoFill;
}
