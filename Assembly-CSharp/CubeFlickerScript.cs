using System;
using UnityEngine;

// Token: 0x0200026A RID: 618
public class CubeFlickerScript : MonoBehaviour
{
	// Token: 0x06001306 RID: 4870 RVA: 0x000A84F8 File Offset: 0x000A66F8
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

	// Token: 0x04001B1C RID: 6940
	public Transform[] Cube;
}
