using System;
using UnityEngine;

// Token: 0x020004B3 RID: 1203
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F8F RID: 8079 RVA: 0x001BA9E9 File Offset: 0x001B8BE9
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F90 RID: 8080 RVA: 0x001BA9FC File Offset: 0x001B8BFC
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x0400419D RID: 16797
	public Vector3 Origin;
}
