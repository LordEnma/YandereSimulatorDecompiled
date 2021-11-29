using System;
using UnityEngine;

// Token: 0x02000268 RID: 616
public class CubeFlickerScript : MonoBehaviour
{
	// Token: 0x060012FA RID: 4858 RVA: 0x000A796C File Offset: 0x000A5B6C
	private void Update()
	{
		this.Cube[0].localScale = new Vector3(UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f));
		this.Cube[1].localScale = new Vector3(UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f));
		this.Cube[2].localScale = new Vector3(UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f));
		this.Cube[3].localScale = new Vector3(UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f));
		this.Cube[4].localScale = new Vector3(UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f), UnityEngine.Random.Range(0f, 0.1f));
		this.Cube[0].position = base.transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(-1f, 1f));
		this.Cube[1].position = base.transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(-1f, 1f));
		this.Cube[2].position = base.transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(-1f, 1f));
		this.Cube[3].position = base.transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(-1f, 1f));
		this.Cube[4].position = base.transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(-1f, 1f));
	}

	// Token: 0x04001AEC RID: 6892
	public Transform[] Cube;
}
