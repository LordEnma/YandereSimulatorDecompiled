using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x060020B4 RID: 8372 RVA: 0x001E1C54 File Offset: 0x001DFE54
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x060020B5 RID: 8373 RVA: 0x001E1CB4 File Offset: 0x001DFEB4
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

	// Token: 0x040047D2 RID: 18386
	public GameObject Fire;

	// Token: 0x040047D3 RID: 18387
	public Vector3 Rotation;

	// Token: 0x040047D4 RID: 18388
	public float Value;
}
