using System;
using UnityEngine;

// Token: 0x02000103 RID: 259
public class BushSpawnerScript : MonoBehaviour
{
	// Token: 0x06000A9D RID: 2717 RVA: 0x00061AB4 File Offset: 0x0005FCB4
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

	// Token: 0x04000CC2 RID: 3266
	public GameObject Bush;

	// Token: 0x04000CC3 RID: 3267
	public bool Begin;
}
