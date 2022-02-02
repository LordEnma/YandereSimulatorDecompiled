using System;
using UnityEngine;

// Token: 0x020004D3 RID: 1235
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x06002073 RID: 8307 RVA: 0x001DC528 File Offset: 0x001DA728
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x06002074 RID: 8308 RVA: 0x001DC588 File Offset: 0x001DA788
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

	// Token: 0x04004703 RID: 18179
	public GameObject Fire;

	// Token: 0x04004704 RID: 18180
	public Vector3 Rotation;

	// Token: 0x04004705 RID: 18181
	public float Value;
}
