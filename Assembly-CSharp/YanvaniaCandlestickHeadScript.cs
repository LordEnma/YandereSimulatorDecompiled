using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x060020CD RID: 8397 RVA: 0x001E4168 File Offset: 0x001E2368
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x060020CE RID: 8398 RVA: 0x001E41C8 File Offset: 0x001E23C8
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

	// Token: 0x040047FE RID: 18430
	public GameObject Fire;

	// Token: 0x040047FF RID: 18431
	public Vector3 Rotation;

	// Token: 0x04004800 RID: 18432
	public float Value;
}
