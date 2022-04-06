using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x060020D3 RID: 8403 RVA: 0x001E3C30 File Offset: 0x001E1E30
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x060020D4 RID: 8404 RVA: 0x001E3C8C File Offset: 0x001E1E8C
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400481E RID: 18462
	public float MyRotation;

	// Token: 0x0400481F RID: 18463
	public float Rotation;
}
