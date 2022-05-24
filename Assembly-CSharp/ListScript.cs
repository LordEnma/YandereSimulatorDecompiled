using System;
using UnityEngine;

// Token: 0x02000356 RID: 854
public class ListScript : MonoBehaviour
{
	// Token: 0x06001989 RID: 6537 RVA: 0x00101514 File Offset: 0x000FF714
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

	// Token: 0x0400289E RID: 10398
	public Transform[] List;

	// Token: 0x0400289F RID: 10399
	public bool AutoFill;
}
