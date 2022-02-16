using System;
using UnityEngine;

// Token: 0x020003EE RID: 1006
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BDB RID: 7131 RVA: 0x00145282 File Offset: 0x00143482
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BDC RID: 7132 RVA: 0x001452B8 File Offset: 0x001434B8
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030DE RID: 12510
	public GameObject Source;

	// Token: 0x040030DF RID: 12511
	public GameObject Target;

	// Token: 0x040030E0 RID: 12512
	private Component[] SourceSkelNodes;

	// Token: 0x040030E1 RID: 12513
	private Component[] TargetSkelNodes;
}
