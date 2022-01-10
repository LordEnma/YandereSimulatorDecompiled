using System;
using UnityEngine;

// Token: 0x020003EC RID: 1004
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BCF RID: 7119 RVA: 0x0014319A File Offset: 0x0014139A
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BD0 RID: 7120 RVA: 0x001431D0 File Offset: 0x001413D0
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030C9 RID: 12489
	public GameObject Source;

	// Token: 0x040030CA RID: 12490
	public GameObject Target;

	// Token: 0x040030CB RID: 12491
	private Component[] SourceSkelNodes;

	// Token: 0x040030CC RID: 12492
	private Component[] TargetSkelNodes;
}
