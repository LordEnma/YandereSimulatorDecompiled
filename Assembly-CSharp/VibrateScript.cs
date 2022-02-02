using System;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F7A RID: 8058 RVA: 0x001B951D File Offset: 0x001B771D
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F7B RID: 8059 RVA: 0x001B9530 File Offset: 0x001B7730
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x0400417B RID: 16763
	public Vector3 Origin;
}
