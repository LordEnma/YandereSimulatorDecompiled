using System;
using UnityEngine;

// Token: 0x020004D3 RID: 1235
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x0600206F RID: 8303 RVA: 0x001DBC88 File Offset: 0x001D9E88
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x06002070 RID: 8304 RVA: 0x001DBCE8 File Offset: 0x001D9EE8
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

	// Token: 0x040046F8 RID: 18168
	public GameObject Fire;

	// Token: 0x040046F9 RID: 18169
	public Vector3 Rotation;

	// Token: 0x040046FA RID: 18170
	public float Value;
}
