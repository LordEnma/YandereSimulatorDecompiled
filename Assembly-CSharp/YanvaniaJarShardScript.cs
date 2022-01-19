using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x06002086 RID: 8326 RVA: 0x001DD734 File Offset: 0x001DB934
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x06002087 RID: 8327 RVA: 0x001DD790 File Offset: 0x001DB990
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004740 RID: 18240
	public float MyRotation;

	// Token: 0x04004741 RID: 18241
	public float Rotation;
}
