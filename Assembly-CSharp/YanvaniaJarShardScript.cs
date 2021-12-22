using System;
using UnityEngine;

// Token: 0x020004D7 RID: 1239
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x06002076 RID: 8310 RVA: 0x001DBAD4 File Offset: 0x001D9CD4
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x06002077 RID: 8311 RVA: 0x001DBB30 File Offset: 0x001D9D30
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400471C RID: 18204
	public float MyRotation;

	// Token: 0x0400471D RID: 18205
	public float Rotation;
}
