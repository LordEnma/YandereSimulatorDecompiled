using System;
using UnityEngine;

// Token: 0x020004E5 RID: 1253
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x060020CB RID: 8395 RVA: 0x001E3700 File Offset: 0x001E1900
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x060020CC RID: 8396 RVA: 0x001E375C File Offset: 0x001E195C
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400481A RID: 18458
	public float MyRotation;

	// Token: 0x0400481B RID: 18459
	public float Rotation;
}
