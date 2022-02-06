using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
[AddComponentMenu("NGUI/Interaction/Drag and Drop Container")]
public class UIDragDropContainer : MonoBehaviour
{
	// Token: 0x06000167 RID: 359 RVA: 0x0001540B File Offset: 0x0001360B
	protected virtual void Start()
	{
		if (this.reparentTarget == null)
		{
			this.reparentTarget = base.transform;
		}
	}

	// Token: 0x0400031C RID: 796
	public Transform reparentTarget;
}
