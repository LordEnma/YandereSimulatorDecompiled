using System;
using UnityEngine;

// Token: 0x020004AE RID: 1198
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F6B RID: 8043 RVA: 0x001B79A5 File Offset: 0x001B5BA5
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x001B79B8 File Offset: 0x001B5BB8
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004158 RID: 16728
	public Vector3 Origin;
}
