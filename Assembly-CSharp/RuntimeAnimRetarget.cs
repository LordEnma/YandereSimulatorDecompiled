using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BD1 RID: 7121 RVA: 0x001448A2 File Offset: 0x00142AA2
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BD2 RID: 7122 RVA: 0x001448D8 File Offset: 0x00142AD8
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030CE RID: 12494
	public GameObject Source;

	// Token: 0x040030CF RID: 12495
	public GameObject Target;

	// Token: 0x040030D0 RID: 12496
	private Component[] SourceSkelNodes;

	// Token: 0x040030D1 RID: 12497
	private Component[] TargetSkelNodes;
}
