using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BD4 RID: 7124 RVA: 0x00144F82 File Offset: 0x00143182
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BD5 RID: 7125 RVA: 0x00144FB8 File Offset: 0x001431B8
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030D8 RID: 12504
	public GameObject Source;

	// Token: 0x040030D9 RID: 12505
	public GameObject Target;

	// Token: 0x040030DA RID: 12506
	private Component[] SourceSkelNodes;

	// Token: 0x040030DB RID: 12507
	private Component[] TargetSkelNodes;
}
