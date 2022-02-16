using System;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019BB RID: 6587 RVA: 0x001070E2 File Offset: 0x001052E2
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019BC RID: 6588 RVA: 0x00107124 File Offset: 0x00105324
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

	// Token: 0x04002932 RID: 10546
	public ParticleSystem Smoke;

	// Token: 0x04002933 RID: 10547
	public Transform Yandere;

	// Token: 0x04002934 RID: 10548
	public float Distance;

	// Token: 0x04002935 RID: 10549
	public float Speed;

	// Token: 0x04002936 RID: 10550
	public bool Fall;
}
