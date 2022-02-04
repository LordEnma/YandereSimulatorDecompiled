using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaJarShardScript : MonoBehaviour
{
	// Token: 0x0600208C RID: 8332 RVA: 0x001DE2EC File Offset: 0x001DC4EC
	private void Start()
	{
		this.Rotation = UnityEngine.Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	// Token: 0x0600208D RID: 8333 RVA: 0x001DE348 File Offset: 0x001DC548
	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004751 RID: 18257
	public float MyRotation;

	// Token: 0x04004752 RID: 18258
	public float Rotation;
}
