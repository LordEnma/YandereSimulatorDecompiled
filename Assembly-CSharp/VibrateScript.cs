using System;
using UnityEngine;

// Token: 0x020004AE RID: 1198
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F68 RID: 8040 RVA: 0x001B74CD File Offset: 0x001B56CD
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F69 RID: 8041 RVA: 0x001B74E0 File Offset: 0x001B56E0
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004151 RID: 16721
	public Vector3 Origin;
}
