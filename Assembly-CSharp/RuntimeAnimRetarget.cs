using System;
using UnityEngine;

// Token: 0x020003F4 RID: 1012
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x0014828A File Offset: 0x0014648A
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001C08 RID: 7176 RVA: 0x001482C0 File Offset: 0x001464C0
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x0400315F RID: 12639
	public GameObject Source;

	// Token: 0x04003160 RID: 12640
	public GameObject Target;

	// Token: 0x04003161 RID: 12641
	private Component[] SourceSkelNodes;

	// Token: 0x04003162 RID: 12642
	private Component[] TargetSkelNodes;
}
