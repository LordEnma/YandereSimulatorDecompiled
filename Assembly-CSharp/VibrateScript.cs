using System;
using UnityEngine;

// Token: 0x020004B3 RID: 1203
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F92 RID: 8082 RVA: 0x001BB189 File Offset: 0x001B9389
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F93 RID: 8083 RVA: 0x001BB19C File Offset: 0x001B939C
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x040041B4 RID: 16820
	public Vector3 Origin;
}
