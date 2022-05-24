using System;
using UnityEngine;

// Token: 0x02000104 RID: 260
public class BushSpawnerScript : MonoBehaviour
{
	// Token: 0x06000A9F RID: 2719 RVA: 0x00061E58 File Offset: 0x00060058
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.Begin = true;
		}
		if (this.Begin)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Bush, new Vector3(UnityEngine.Random.Range(-16f, 16f), UnityEngine.Random.Range(0f, 4f), UnityEngine.Random.Range(-16f, 16f)), Quaternion.identity);
		}
	}

	// Token: 0x04000CC8 RID: 3272
	public GameObject Bush;

	// Token: 0x04000CC9 RID: 3273
	public bool Begin;
}
