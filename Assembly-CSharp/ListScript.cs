using System;
using UnityEngine;

// Token: 0x02000356 RID: 854
public class ListScript : MonoBehaviour
{
	// Token: 0x06001988 RID: 6536 RVA: 0x00101310 File Offset: 0x000FF510
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

	// Token: 0x04002897 RID: 10391
	public Transform[] List;

	// Token: 0x04002898 RID: 10392
	public bool AutoFill;
}
