using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class ListScript : MonoBehaviour
{
	// Token: 0x06001955 RID: 6485 RVA: 0x000FE408 File Offset: 0x000FC608
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

	// Token: 0x04002813 RID: 10259
	public Transform[] List;

	// Token: 0x04002814 RID: 10260
	public bool AutoFill;
}
