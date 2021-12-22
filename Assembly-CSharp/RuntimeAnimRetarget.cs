using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BC6 RID: 7110 RVA: 0x00142A2A File Offset: 0x00140C2A
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BC7 RID: 7111 RVA: 0x00142A60 File Offset: 0x00140C60
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030BC RID: 12476
	public GameObject Source;

	// Token: 0x040030BD RID: 12477
	public GameObject Target;

	// Token: 0x040030BE RID: 12478
	private Component[] SourceSkelNodes;

	// Token: 0x040030BF RID: 12479
	private Component[] TargetSkelNodes;
}
