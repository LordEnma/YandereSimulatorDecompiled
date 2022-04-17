using System;
using UnityEngine;

// Token: 0x020004BA RID: 1210
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001FBC RID: 8124 RVA: 0x001BED79 File Offset: 0x001BCF79
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001FBD RID: 8125 RVA: 0x001BED8C File Offset: 0x001BCF8C
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x0400423F RID: 16959
	public Vector3 Origin;
}
