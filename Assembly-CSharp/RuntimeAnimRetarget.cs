using System;
using UnityEngine;

// Token: 0x020003F4 RID: 1012
public class RuntimeAnimRetarget : MonoBehaviour
{
	// Token: 0x06001C03 RID: 7171 RVA: 0x00147E7A File Offset: 0x0014607A
	private void Start()
	{
		Debug.Log(this.Source.name);
		this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
		this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
	}

	// Token: 0x06001C04 RID: 7172 RVA: 0x00147EB0 File Offset: 0x001460B0
	private void LateUpdate()
	{
		this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
		}
	}

	// Token: 0x04003154 RID: 12628
	public GameObject Source;

	// Token: 0x04003155 RID: 12629
	public GameObject Target;

	// Token: 0x04003156 RID: 12630
	private Component[] SourceSkelNodes;

	// Token: 0x04003157 RID: 12631
	private Component[] TargetSkelNodes;
}
