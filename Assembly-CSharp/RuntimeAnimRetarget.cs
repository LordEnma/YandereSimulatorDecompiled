using System;
using UnityEngine;

// Token: 0x020003F6 RID: 1014
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001C14 RID: 7188 RVA: 0x00149746 File Offset: 0x00147946
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001C15 RID: 7189 RVA: 0x0014977C File Offset: 0x0014797C
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x04003183 RID: 12675
	public GameObject Source;

	// Token: 0x04003184 RID: 12676
	public GameObject Target;

	// Token: 0x04003185 RID: 12677
	private Component[] SourceSkelNodes;

	// Token: 0x04003186 RID: 12678
	private Component[] TargetSkelNodes;
}
