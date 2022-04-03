using System;
using UnityEngine;

// Token: 0x020003F3 RID: 1011
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BFD RID: 7165 RVA: 0x00147B96 File Offset: 0x00145D96
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BFE RID: 7166 RVA: 0x00147BCC File Offset: 0x00145DCC
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x04003151 RID: 12625
	public GameObject Source;

	// Token: 0x04003152 RID: 12626
	public GameObject Target;

	// Token: 0x04003153 RID: 12627
	private Component[] SourceSkelNodes;

	// Token: 0x04003154 RID: 12628
	private Component[] TargetSkelNodes;
}
