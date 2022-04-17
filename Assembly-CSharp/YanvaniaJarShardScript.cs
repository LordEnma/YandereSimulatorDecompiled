using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x060020DA RID: 8410 RVA: 0x001E468C File Offset: 0x001E288C
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x001E46E8 File Offset: 0x001E28E8
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004830 RID: 18480
	public float MyRotation;

	// Token: 0x04004831 RID: 18481
	public float Rotation;
}
