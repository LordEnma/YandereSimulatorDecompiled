using System;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001F78 RID: 8056 RVA: 0x001B8FF5 File Offset: 0x001B71F5
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001F79 RID: 8057 RVA: 0x001B9008 File Offset: 0x001B7208
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004173 RID: 16755
	public Vector3 Origin;
}
