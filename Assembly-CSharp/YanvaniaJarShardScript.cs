using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x06002096 RID: 8342 RVA: 0x001DE9A4 File Offset: 0x001DCBA4
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x06002097 RID: 8343 RVA: 0x001DEA00 File Offset: 0x001DCC00
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400475D RID: 18269
	public float MyRotation;

	// Token: 0x0400475E RID: 18270
	public float Rotation;
}
