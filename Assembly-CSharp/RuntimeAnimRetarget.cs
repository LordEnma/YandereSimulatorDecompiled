using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BD2 RID: 7122 RVA: 0x00144CE6 File Offset: 0x00142EE6
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x00144D1C File Offset: 0x00142F1C
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030D4 RID: 12500
	public GameObject Source;

	// Token: 0x040030D5 RID: 12501
	public GameObject Target;

	// Token: 0x040030D6 RID: 12502
	private Component[] SourceSkelNodes;

	// Token: 0x040030D7 RID: 12503
	private Component[] TargetSkelNodes;
}
