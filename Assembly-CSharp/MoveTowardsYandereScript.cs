using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019A4 RID: 6564 RVA: 0x00105732 File Offset: 0x00103932
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019A5 RID: 6565 RVA: 0x00105774 File Offset: 0x00103974
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.position) > this.Distance * 0.5f && base.transform.position.y < this.Yandere.position.y + 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
		}
		this.Speed += Time.deltaTime;
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yandere.position, this.Speed * Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yandere.position) == 0f)
		{
			this.Smoke.emission.enabled = false;
		}
	}

	// Token: 0x040028F0 RID: 10480
	public ParticleSystem Smoke;

	// Token: 0x040028F1 RID: 10481
	public Transform Yandere;

	// Token: 0x040028F2 RID: 10482
	public float Distance;

	// Token: 0x040028F3 RID: 10483
	public float Speed;

	// Token: 0x040028F4 RID: 10484
	public bool Fall;
}
