using System;
using UnityEngine;

// Token: 0x02000354 RID: 852
public class ListScript : MonoBehaviour
{
	// Token: 0x06001974 RID: 6516 RVA: 0x00100274 File Offset: 0x000FE474
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

	// Token: 0x04002872 RID: 10354
	public Transform[] List;

	// Token: 0x04002873 RID: 10355
	public bool AutoFill;
}
