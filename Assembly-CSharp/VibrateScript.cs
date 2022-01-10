using System;
using UnityEngine;

// Token: 0x020004B0 RID: 1200
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F76 RID: 8054 RVA: 0x001B8325 File Offset: 0x001B6525
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F77 RID: 8055 RVA: 0x001B8338 File Offset: 0x001B6538
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x0400416C RID: 16748
	public Vector3 Origin;
}
