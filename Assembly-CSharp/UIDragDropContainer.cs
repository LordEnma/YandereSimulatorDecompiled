using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
[AddComponentMenu("NGUI/Interaction/Drag and Drop Container")]
public class UIDragDropContainer : MonoBehaviour
{
	// Token: 0x06000167 RID: 359 RVA: 0x000155BB File Offset: 0x000137BB
	protected virtual void Start()
	{
		if (this.reparentTarget == null)
		{
			this.reparentTarget = base.transform;
		}
	}

	// Token: 0x04000325 RID: 805
	public Transform reparentTarget;
}
