using System;
using UnityEngine;

// Token: 0x02000050 RID: 80
[AddComponentMenu("NGUI/Interaction/Drag and Drop Root")]
public class UIDragDropRoot : MonoBehaviour
{
	// Token: 0x06000182 RID: 386 RVA: 0x000161F8 File Offset: 0x000143F8
	private void OnEnable()
	{
		UIDragDropRoot.root = base.transform;
	}

	// Token: 0x06000183 RID: 387 RVA: 0x00016205 File Offset: 0x00014405
	private void OnDisable()
	{
		if (UIDragDropRoot.root == base.transform)
		{
			UIDragDropRoot.root = null;
		}
	}

	// Token: 0x0400033C RID: 828
	public static Transform root;
}
