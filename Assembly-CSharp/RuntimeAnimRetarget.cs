using System;
using UnityEngine;

// Token: 0x020003F5 RID: 1013
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001C0E RID: 7182 RVA: 0x00148A92 File Offset: 0x00146C92
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001C0F RID: 7183 RVA: 0x00148AC8 File Offset: 0x00146CC8
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x0400316E RID: 12654
	public GameObject Source;

	// Token: 0x0400316F RID: 12655
	public GameObject Target;

	// Token: 0x04003170 RID: 12656
	private Component[] SourceSkelNodes;

	// Token: 0x04003171 RID: 12657
	private Component[] TargetSkelNodes;
}
