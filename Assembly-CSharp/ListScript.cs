using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class ListScript : MonoBehaviour
{
	// Token: 0x06001954 RID: 6484 RVA: 0x000FDFD0 File Offset: 0x000FC1D0
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

	// Token: 0x0400280D RID: 10253
	public Transform[] List;

	// Token: 0x0400280E RID: 10254
	public bool AutoFill;
}
