using System;
using UnityEngine;

// Token: 0x02000353 RID: 851
public class ListScript : MonoBehaviour
{
	// Token: 0x0600196E RID: 6510 RVA: 0x000FFBC8 File Offset: 0x000FDDC8
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

	// Token: 0x0400285F RID: 10335
	public Transform[] List;

	// Token: 0x04002860 RID: 10336
	public bool AutoFill;
}
