using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x06002062 RID: 8290 RVA: 0x001DA618 File Offset: 0x001D8818
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x06002063 RID: 8291 RVA: 0x001DA678 File Offset: 0x001D8878
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

	// Token: 0x040046DD RID: 18141
	public GameObject Fire;

	// Token: 0x040046DE RID: 18142
	public Vector3 Rotation;

	// Token: 0x040046DF RID: 18143
	public float Value;
}
