using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class ListScript : MonoBehaviour
{
	// Token: 0x0600197E RID: 6526 RVA: 0x00100608 File Offset: 0x000FE808
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

	// Token: 0x0400287D RID: 10365
	public Transform[] List;

	// Token: 0x0400287E RID: 10366
	public bool AutoFill;
}
