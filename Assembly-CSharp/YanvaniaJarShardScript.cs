using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x0600208A RID: 8330 RVA: 0x001DDFD4 File Offset: 0x001DC1D4
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x0600208B RID: 8331 RVA: 0x001DE030 File Offset: 0x001DC230
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400474B RID: 18251
	public float MyRotation;

	// Token: 0x0400474C RID: 18252
	public float Rotation;
}
