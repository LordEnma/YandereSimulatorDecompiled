using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x060020A5 RID: 8357 RVA: 0x001DFF5C File Offset: 0x001DE15C
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x060020A6 RID: 8358 RVA: 0x001DFFB8 File Offset: 0x001DE1B8
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400478A RID: 18314
	public float MyRotation;

	// Token: 0x0400478B RID: 18315
	public float Rotation;
}
