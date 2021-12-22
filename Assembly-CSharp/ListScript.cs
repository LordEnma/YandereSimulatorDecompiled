using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class ListScript : MonoBehaviour
{
	// Token: 0x0600194E RID: 6478 RVA: 0x000FD848 File Offset: 0x000FBA48
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

	// Token: 0x04002802 RID: 10242
	public Transform[] List;

	// Token: 0x04002803 RID: 10243
	public bool AutoFill;
}
