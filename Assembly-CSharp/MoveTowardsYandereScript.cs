using System;
using UnityEngine;

// Token: 0x0200036C RID: 876
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019AD RID: 6573 RVA: 0x001062AE File Offset: 0x001044AE
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019AE RID: 6574 RVA: 0x001062F0 File Offset: 0x001044F0
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

	// Token: 0x04002919 RID: 10521
	public ParticleSystem Smoke;

	// Token: 0x0400291A RID: 10522
	public Transform Yandere;

	// Token: 0x0400291B RID: 10523
	public float Distance;

	// Token: 0x0400291C RID: 10524
	public float Speed;

	// Token: 0x0400291D RID: 10525
	public bool Fall;
}
