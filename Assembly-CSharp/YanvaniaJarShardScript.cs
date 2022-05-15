using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x060020EE RID: 8430 RVA: 0x001E7264 File Offset: 0x001E5464
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x001E72C0 File Offset: 0x001E54C0
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400486D RID: 18541
	public float MyRotation;

	// Token: 0x0400486E RID: 18542
	public float Rotation;
}
