using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x0600204E RID: 8270 RVA: 0x001D88F4 File Offset: 0x001D6AF4
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x0600204F RID: 8271 RVA: 0x001D8954 File Offset: 0x001D6B54
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

	// Token: 0x04004695 RID: 18069
	public GameObject Fire;

	// Token: 0x04004696 RID: 18070
	public Vector3 Rotation;

	// Token: 0x04004697 RID: 18071
	public float Value;
}
