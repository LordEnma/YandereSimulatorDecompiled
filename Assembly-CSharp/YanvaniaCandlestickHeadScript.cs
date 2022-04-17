using System;
using UnityEngine;

// Token: 0x020004DF RID: 1247
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x060020C3 RID: 8387 RVA: 0x001E2BE0 File Offset: 0x001E0DE0
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x060020C4 RID: 8388 RVA: 0x001E2C40 File Offset: 0x001E0E40
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

	// Token: 0x040047E8 RID: 18408
	public GameObject Fire;

	// Token: 0x040047E9 RID: 18409
	public Vector3 Rotation;

	// Token: 0x040047EA RID: 18410
	public float Value;
}
