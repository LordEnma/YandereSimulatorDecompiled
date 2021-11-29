using System;
using UnityEngine;

// Token: 0x02000102 RID: 258
public class BushSpawnerScript : MonoBehaviour
{
	// Token: 0x06000A97 RID: 2711 RVA: 0x00060FC4 File Offset: 0x0005F1C4
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

	// Token: 0x04000CA9 RID: 3241
	public GameObject Bush;

	// Token: 0x04000CAA RID: 3242
	public bool Begin;
}
