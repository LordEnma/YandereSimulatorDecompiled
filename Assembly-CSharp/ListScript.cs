using System;
using UnityEngine;

// Token: 0x0200034F RID: 847
public class ListScript : MonoBehaviour
{
	// Token: 0x06001947 RID: 6471 RVA: 0x000FD038 File Offset: 0x000FB238
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

	// Token: 0x040027DD RID: 10205
	public Transform[] List;

	// Token: 0x040027DE RID: 10206
	public bool AutoFill;
}
