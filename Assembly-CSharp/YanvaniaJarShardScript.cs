using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x0600208F RID: 8335 RVA: 0x001DE4F0 File Offset: 0x001DC6F0
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x06002090 RID: 8336 RVA: 0x001DE54C File Offset: 0x001DC74C
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004754 RID: 18260
	public float MyRotation;

	// Token: 0x04004755 RID: 18261
	public float Rotation;
}
