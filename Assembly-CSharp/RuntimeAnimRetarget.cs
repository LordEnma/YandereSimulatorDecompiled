using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001BC8 RID: 7112 RVA: 0x00142E26 File Offset: 0x00141026
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001BC9 RID: 7113 RVA: 0x00142E5C File Offset: 0x0014105C
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x040030C3 RID: 12483
	public GameObject Source;

	// Token: 0x040030C4 RID: 12484
	public GameObject Target;

	// Token: 0x040030C5 RID: 12485
	private Component[] SourceSkelNodes;

	// Token: 0x040030C6 RID: 12486
	private Component[] TargetSkelNodes;
}
