using System;
using UnityEngine;

// Token: 0x020004E1 RID: 1249
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x060020BD RID: 8381 RVA: 0x001E1EC4 File Offset: 0x001E00C4
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x060020BE RID: 8382 RVA: 0x001E1F20 File Offset: 0x001E0120
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047E9 RID: 18409
	public float MyRotation;

	// Token: 0x040047EA RID: 18410
	public float Rotation;
}
