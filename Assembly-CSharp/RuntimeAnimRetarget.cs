using System;
using UnityEngine;

// Token: 0x020003EF RID: 1007
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BE4 RID: 7140 RVA: 0x00145CFA File Offset: 0x00143EFA
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BE5 RID: 7141 RVA: 0x00145D30 File Offset: 0x00143F30
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030EE RID: 12526
	public GameObject Source;

	// Token: 0x040030EF RID: 12527
	public GameObject Target;

	// Token: 0x040030F0 RID: 12528
	private Component[] SourceSkelNodes;

	// Token: 0x040030F1 RID: 12529
	private Component[] TargetSkelNodes;
}
