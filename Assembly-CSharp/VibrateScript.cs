using System;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F7C RID: 8060 RVA: 0x001B9829 File Offset: 0x001B7A29
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F7D RID: 8061 RVA: 0x001B983C File Offset: 0x001B7A3C
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004181 RID: 16769
	public Vector3 Origin;
}
