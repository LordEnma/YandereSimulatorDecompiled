using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x06002088 RID: 8328 RVA: 0x001DDAD8 File Offset: 0x001DBCD8
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x06002089 RID: 8329 RVA: 0x001DDB38 File Offset: 0x001DBD38
	private void Update()
	{
		this.Rotation += new Vector3(this.Value, this.Value, this.Value);
		base.transform.localEulerAngles = this.Rotation;
		if (base.transform.localPosition.y < 0.23f)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Fire, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004725 RID: 18213
	public GameObject Fire;

	// Token: 0x04004726 RID: 18214
	public Vector3 Rotation;

	// Token: 0x04004727 RID: 18215
	public float Value;
}
