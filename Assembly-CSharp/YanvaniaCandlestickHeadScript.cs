using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x060020A6 RID: 8358 RVA: 0x001E0418 File Offset: 0x001DE618
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x060020A7 RID: 8359 RVA: 0x001E0478 File Offset: 0x001DE678
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

	// Token: 0x040047A1 RID: 18337
	public GameObject Fire;

	// Token: 0x040047A2 RID: 18338
	public Vector3 Rotation;

	// Token: 0x040047A3 RID: 18339
	public float Value;
}
