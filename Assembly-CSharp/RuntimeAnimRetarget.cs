using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BF3 RID: 7155 RVA: 0x001470DA File Offset: 0x001452DA
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BF4 RID: 7156 RVA: 0x00147110 File Offset: 0x00145310
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x04003138 RID: 12600
	public GameObject Source;

	// Token: 0x04003139 RID: 12601
	public GameObject Target;

	// Token: 0x0400313A RID: 12602
	private Component[] SourceSkelNodes;

	// Token: 0x0400313B RID: 12603
	private Component[] TargetSkelNodes;
}
