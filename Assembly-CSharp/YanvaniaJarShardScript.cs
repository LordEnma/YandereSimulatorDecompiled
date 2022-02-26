using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x0600209F RID: 8351 RVA: 0x001DF584 File Offset: 0x001DD784
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x060020A0 RID: 8352 RVA: 0x001DF5E0 File Offset: 0x001DD7E0
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400476D RID: 18285
	public float MyRotation;

	// Token: 0x0400476E RID: 18286
	public float Rotation;
}
