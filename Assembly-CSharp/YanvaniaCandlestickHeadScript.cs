using System;
using UnityEngine;

// Token: 0x020004D2 RID: 1234
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x0600206D RID: 8301 RVA: 0x001DAFB8 File Offset: 0x001D91B8
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x0600206E RID: 8302 RVA: 0x001DB018 File Offset: 0x001D9218
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

	// Token: 0x040046F1 RID: 18161
	public GameObject Fire;

	// Token: 0x040046F2 RID: 18162
	public Vector3 Rotation;

	// Token: 0x040046F3 RID: 18163
	public float Value;
}
