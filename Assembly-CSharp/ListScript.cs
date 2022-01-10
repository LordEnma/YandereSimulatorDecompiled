using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class ListScript : MonoBehaviour
{
	// Token: 0x06001954 RID: 6484 RVA: 0x000FDE68 File Offset: 0x000FC068
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

	// Token: 0x0400280A RID: 10250
	public Transform[] List;

	// Token: 0x0400280B RID: 10251
	public bool AutoFill;
}
