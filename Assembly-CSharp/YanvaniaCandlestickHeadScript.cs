using System;
using UnityEngine;

// Token: 0x020004D3 RID: 1235
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x06002078 RID: 8312 RVA: 0x001DCA44 File Offset: 0x001DAC44
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x06002079 RID: 8313 RVA: 0x001DCAA4 File Offset: 0x001DACA4
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

	// Token: 0x0400470C RID: 18188
	public GameObject Fire;

	// Token: 0x0400470D RID: 18189
	public Vector3 Rotation;

	// Token: 0x0400470E RID: 18190
	public float Value;
}
