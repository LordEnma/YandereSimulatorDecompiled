using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x0600208E RID: 8334 RVA: 0x001DE4B0 File Offset: 0x001DC6B0
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x0600208F RID: 8335 RVA: 0x001DE510 File Offset: 0x001DC710
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

	// Token: 0x04004742 RID: 18242
	public GameObject Fire;

	// Token: 0x04004743 RID: 18243
	public Vector3 Rotation;

	// Token: 0x04004744 RID: 18244
	public float Value;
}
