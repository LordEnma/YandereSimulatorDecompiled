using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019C4 RID: 6596 RVA: 0x00107A12 File Offset: 0x00105C12
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019C5 RID: 6597 RVA: 0x00107A54 File Offset: 0x00105C54
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

	// Token: 0x04002941 RID: 10561
	public ParticleSystem Smoke;

	// Token: 0x04002942 RID: 10562
	public Transform Yandere;

	// Token: 0x04002943 RID: 10563
	public float Distance;

	// Token: 0x04002944 RID: 10564
	public float Speed;

	// Token: 0x04002945 RID: 10565
	public bool Fall;
}
