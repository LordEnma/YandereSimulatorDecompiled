using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class ListScript : MonoBehaviour
{
	// Token: 0x0600197A RID: 6522 RVA: 0x00100374 File Offset: 0x000FE574
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

	// Token: 0x04002875 RID: 10357
	public Transform[] List;

	// Token: 0x04002876 RID: 10358
	public bool AutoFill;
}
