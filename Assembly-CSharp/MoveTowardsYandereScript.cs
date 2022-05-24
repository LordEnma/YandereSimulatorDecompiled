using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019E7 RID: 6631 RVA: 0x0010A0EE File Offset: 0x001082EE
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019E8 RID: 6632 RVA: 0x0010A130 File Offset: 0x00108330
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

	// Token: 0x040029B9 RID: 10681
	public ParticleSystem Smoke;

	// Token: 0x040029BA RID: 10682
	public Transform Yandere;

	// Token: 0x040029BB RID: 10683
	public float Distance;

	// Token: 0x040029BC RID: 10684
	public float Speed;

	// Token: 0x040029BD RID: 10685
	public bool Fall;
}
