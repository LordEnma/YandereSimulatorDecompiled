using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x0600205F RID: 8287 RVA: 0x001DA028 File Offset: 0x001D8228
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x06002060 RID: 8288 RVA: 0x001DA088 File Offset: 0x001D8288
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

	// Token: 0x040046D4 RID: 18132
	public GameObject Fire;

	// Token: 0x040046D5 RID: 18133
	public Vector3 Rotation;

	// Token: 0x040046D6 RID: 18134
	public float Value;
}
