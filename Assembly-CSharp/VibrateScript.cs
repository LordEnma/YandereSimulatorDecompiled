using System;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F7F RID: 8063 RVA: 0x001B9A49 File Offset: 0x001B7C49
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x001B9A5C File Offset: 0x001B7C5C
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004184 RID: 16772
	public Vector3 Origin;
}
