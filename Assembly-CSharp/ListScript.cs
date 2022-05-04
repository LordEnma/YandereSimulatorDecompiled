using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class ListScript : MonoBehaviour
{
	// Token: 0x06001982 RID: 6530 RVA: 0x00100AD4 File Offset: 0x000FECD4
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

	// Token: 0x04002886 RID: 10374
	public Transform[] List;

	// Token: 0x04002887 RID: 10375
	public bool AutoFill;
}
