using System;
using UnityEngine;

// Token: 0x02000352 RID: 850
public class ListScript : MonoBehaviour
{
	// Token: 0x0600195E RID: 6494 RVA: 0x000FE774 File Offset: 0x000FC974
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

	// Token: 0x0400281D RID: 10269
	public Transform[] List;

	// Token: 0x0400281E RID: 10270
	public bool AutoFill;
}
