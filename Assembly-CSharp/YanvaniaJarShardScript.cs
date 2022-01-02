using System;
using UnityEngine;

// Token: 0x020004D7 RID: 1239
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x06002079 RID: 8313 RVA: 0x001DC0C4 File Offset: 0x001DA2C4
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x0600207A RID: 8314 RVA: 0x001DC120 File Offset: 0x001DA320
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004725 RID: 18213
	public float MyRotation;

	// Token: 0x04004726 RID: 18214
	public float Rotation;
}
