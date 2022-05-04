using System;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x060020E4 RID: 8420 RVA: 0x001E5C14 File Offset: 0x001E3E14
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x001E5C70 File Offset: 0x001E3E70
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004846 RID: 18502
	public float MyRotation;

	// Token: 0x04004847 RID: 18503
	public float Rotation;
}
