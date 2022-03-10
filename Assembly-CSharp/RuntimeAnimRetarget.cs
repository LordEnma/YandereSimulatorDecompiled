using System;
using UnityEngine;

// Token: 0x020003EF RID: 1007
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BE6 RID: 7142 RVA: 0x00146236 File Offset: 0x00144436
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BE7 RID: 7143 RVA: 0x0014626C File Offset: 0x0014446C
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x04003104 RID: 12548
	public GameObject Source;

	// Token: 0x04003105 RID: 12549
	public GameObject Target;

	// Token: 0x04003106 RID: 12550
	private Component[] SourceSkelNodes;

	// Token: 0x04003107 RID: 12551
	private Component[] TargetSkelNodes;
}
