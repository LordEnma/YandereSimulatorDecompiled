using System;
using UnityEngine;

// Token: 0x02000103 RID: 259
public class BushSpawnerScript : MonoBehaviour
{
	// Token: 0x06000A9B RID: 2715 RVA: 0x000613E0 File Offset: 0x0005F5E0
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

	// Token: 0x04000CB8 RID: 3256
	public GameObject Bush;

	// Token: 0x04000CB9 RID: 3257
	public bool Begin;
}
