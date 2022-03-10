using System;
using UnityEngine;

// Token: 0x02000353 RID: 851
public class ListScript : MonoBehaviour
{
	// Token: 0x06001967 RID: 6503 RVA: 0x000FF3E4 File Offset: 0x000FD5E4
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

	// Token: 0x04002842 RID: 10306
	public Transform[] List;

	// Token: 0x04002843 RID: 10307
	public bool AutoFill;
}
