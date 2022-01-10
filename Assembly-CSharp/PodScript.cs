using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AAC RID: 6828 RVA: 0x001210F4 File Offset: 0x0011F2F4
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AAD RID: 6829 RVA: 0x00121104 File Offset: 0x0011F304
	private void LateUpdate()
	{
		this.PodTarget.transform.parent.eulerAngles = new Vector3(0f, this.AimTarget.parent.eulerAngles.y, 0f);
		base.transform.position = Vector3.Lerp(base.transform.position, this.PodTarget.position, Time.deltaTime * 100f);
		base.transform.rotation = this.AimTarget.parent.rotation;
		base.transform.eulerAngles += new Vector3(-15f, 7.5f, 0f);
		if (Input.GetButton("RB"))
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > this.FireRate)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, base.transform.rotation);
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x04002C6E RID: 11374
	public GameObject Projectile;

	// Token: 0x04002C6F RID: 11375
	public Transform SpawnPoint;

	// Token: 0x04002C70 RID: 11376
	public Transform PodTarget;

	// Token: 0x04002C71 RID: 11377
	public Transform AimTarget;

	// Token: 0x04002C72 RID: 11378
	public float FireRate;

	// Token: 0x04002C73 RID: 11379
	public float Timer;
}
