using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class ListScript : MonoBehaviour
{
	// Token: 0x06001950 RID: 6480 RVA: 0x000FDB08 File Offset: 0x000FBD08
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

	// Token: 0x04002806 RID: 10246
	public Transform[] List;

	// Token: 0x04002807 RID: 10247
	public bool AutoFill;
}
