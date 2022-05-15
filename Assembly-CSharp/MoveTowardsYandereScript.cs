using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019E6 RID: 6630 RVA: 0x00109EEA File Offset: 0x001080EA
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019E7 RID: 6631 RVA: 0x00109F2C File Offset: 0x0010812C
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

	// Token: 0x040029B2 RID: 10674
	public ParticleSystem Smoke;

	// Token: 0x040029B3 RID: 10675
	public Transform Yandere;

	// Token: 0x040029B4 RID: 10676
	public float Distance;

	// Token: 0x040029B5 RID: 10677
	public float Speed;

	// Token: 0x040029B6 RID: 10678
	public bool Fall;
}
