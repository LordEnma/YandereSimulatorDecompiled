using System;
using UnityEngine;

// Token: 0x020004B2 RID: 1202
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F86 RID: 8070 RVA: 0x001B9E9D File Offset: 0x001B809D
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F87 RID: 8071 RVA: 0x001B9EB0 File Offset: 0x001B80B0
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x0400418D RID: 16781
	public Vector3 Origin;
}
