using System;
using UnityEngine;

// Token: 0x020004DF RID: 1247
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x060020BC RID: 8380 RVA: 0x001E2184 File Offset: 0x001E0384
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x060020BD RID: 8381 RVA: 0x001E21E4 File Offset: 0x001E03E4
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

	// Token: 0x040047D6 RID: 18390
	public GameObject Fire;

	// Token: 0x040047D7 RID: 18391
	public Vector3 Rotation;

	// Token: 0x040047D8 RID: 18392
	public float Value;
}
