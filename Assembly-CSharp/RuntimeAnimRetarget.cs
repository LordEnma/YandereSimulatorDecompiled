using System;
using UnityEngine;

// Token: 0x020003E9 RID: 1001
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BBE RID: 7102 RVA: 0x0014216A File Offset: 0x0014036A
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BBF RID: 7103 RVA: 0x001421A0 File Offset: 0x001403A0
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x04003092 RID: 12434
	public GameObject Source;

	// Token: 0x04003093 RID: 12435
	public GameObject Target;

	// Token: 0x04003094 RID: 12436
	private Component[] SourceSkelNodes;

	// Token: 0x04003095 RID: 12437
	private Component[] TargetSkelNodes;
}
