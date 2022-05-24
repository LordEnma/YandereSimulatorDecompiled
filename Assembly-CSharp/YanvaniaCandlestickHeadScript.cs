using System;
using UnityEngine;

// Token: 0x020004E1 RID: 1249
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x060020D8 RID: 8408 RVA: 0x001E5D20 File Offset: 0x001E3F20
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x001E5D80 File Offset: 0x001E3F80
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

	// Token: 0x0400482E RID: 18478
	public GameObject Fire;

	// Token: 0x0400482F RID: 18479
	public Vector3 Rotation;

	// Token: 0x04004830 RID: 18480
	public float Value;
}
