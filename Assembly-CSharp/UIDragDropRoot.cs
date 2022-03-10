using System;
using UnityEngine;

// Token: 0x02000050 RID: 80
[AddComponentMenu("NGUI/Interaction/Drag and Drop Root")]
public class UIDragDropRoot : MonoBehaviour
{
	// Token: 0x06000182 RID: 386 RVA: 0x00016000 File Offset: 0x00014200
	private void OnEnable()
	{
		UIDragDropRoot.root = base.transform;
	}

	// Token: 0x06000183 RID: 387 RVA: 0x0001600D File Offset: 0x0001420D
	private void OnDisable()
	{
		if (UIDragDropRoot.root == base.transform)
		{
			UIDragDropRoot.root = null;
		}
	}

	// Token: 0x0400033A RID: 826
	public static Transform root;
}
