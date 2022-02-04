using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BD2 RID: 7122 RVA: 0x00144DEA File Offset: 0x00142FEA
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x00144E20 File Offset: 0x00143020
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030D5 RID: 12501
	public GameObject Source;

	// Token: 0x040030D6 RID: 12502
	public GameObject Target;

	// Token: 0x040030D7 RID: 12503
	private Component[] SourceSkelNodes;

	// Token: 0x040030D8 RID: 12504
	private Component[] TargetSkelNodes;
}
