using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
[AddComponentMenu("NGUI/Interaction/Drag and Drop Container")]
public class UIDragDropContainer : MonoBehaviour
{
	// Token: 0x06000167 RID: 359 RVA: 0x000156FB File Offset: 0x000138FB
	protected virtual void Start()
	{
		if (this.reparentTarget == null)
		{
			this.reparentTarget = base.transform;
		}
	}

	// Token: 0x04000327 RID: 807
	public Transform reparentTarget;
}
