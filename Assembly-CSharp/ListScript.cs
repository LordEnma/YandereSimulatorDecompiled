using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class ListScript : MonoBehaviour
{
	// Token: 0x06001957 RID: 6487 RVA: 0x000FE5D0 File Offset: 0x000FC7D0
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

	// Token: 0x04002817 RID: 10263
	public Transform[] List;

	// Token: 0x04002818 RID: 10264
	public bool AutoFill;
}
