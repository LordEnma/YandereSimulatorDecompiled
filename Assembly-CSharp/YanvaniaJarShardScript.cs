using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x06002084 RID: 8324 RVA: 0x001DCA64 File Offset: 0x001DAC64
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x06002085 RID: 8325 RVA: 0x001DCAC0 File Offset: 0x001DACC0
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004739 RID: 18233
	public float MyRotation;

	// Token: 0x0400473A RID: 18234
	public float Rotation;
}
