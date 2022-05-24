using System;
using UnityEngine;

// Token: 0x020003F6 RID: 1014
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001C15 RID: 7189 RVA: 0x00149A02 File Offset: 0x00147C02
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001C16 RID: 7190 RVA: 0x00149A38 File Offset: 0x00147C38
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x0400318B RID: 12683
	public GameObject Source;

	// Token: 0x0400318C RID: 12684
	public GameObject Target;

	// Token: 0x0400318D RID: 12685
	private Component[] SourceSkelNodes;

	// Token: 0x0400318E RID: 12686
	private Component[] TargetSkelNodes;
}
