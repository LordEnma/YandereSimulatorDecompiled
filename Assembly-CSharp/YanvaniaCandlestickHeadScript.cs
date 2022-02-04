using System;
using UnityEngine;

// Token: 0x020004D3 RID: 1235
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x06002075 RID: 8309 RVA: 0x001DC840 File Offset: 0x001DAA40
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x06002076 RID: 8310 RVA: 0x001DC8A0 File Offset: 0x001DAAA0
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

	// Token: 0x04004709 RID: 18185
	public GameObject Fire;

	// Token: 0x0400470A RID: 18186
	public Vector3 Rotation;

	// Token: 0x0400470B RID: 18187
	public float Value;
}
