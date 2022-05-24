using System;
using UnityEngine;

// Token: 0x020004BC RID: 1212
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C1845 File Offset: 0x001BFA45
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001FD1 RID: 8145 RVA: 0x001C1858 File Offset: 0x001BFA58
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x0400427C RID: 17020
	public Vector3 Origin;
}
