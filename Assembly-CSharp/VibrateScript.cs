using System;
using UnityEngine;

// Token: 0x020004AD RID: 1197
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F5E RID: 8030 RVA: 0x001B6711 File Offset: 0x001B4911
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x001B6724 File Offset: 0x001B4924
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004121 RID: 16673
	public Vector3 Origin;
}
