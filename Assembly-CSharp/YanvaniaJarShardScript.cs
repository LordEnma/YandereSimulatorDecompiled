using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x06002065 RID: 8293 RVA: 0x001DA3A0 File Offset: 0x001D85A0
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x06002066 RID: 8294 RVA: 0x001DA3FC File Offset: 0x001D85FC
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046DD RID: 18141
	public float MyRotation;

	// Token: 0x040046DE RID: 18142
	public float Rotation;
}
