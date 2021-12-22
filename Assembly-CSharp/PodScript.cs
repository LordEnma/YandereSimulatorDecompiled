using System;
using UnityEngine;

// Token: 0x020003A6 RID: 934
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AA3 RID: 6819 RVA: 0x00120A94 File Offset: 0x0011EC94
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AA4 RID: 6820 RVA: 0x00120AA4 File Offset: 0x0011ECA4
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

	// Token: 0x04002C64 RID: 11364
	public GameObject Projectile;

	// Token: 0x04002C65 RID: 11365
	public Transform SpawnPoint;

	// Token: 0x04002C66 RID: 11366
	public Transform PodTarget;

	// Token: 0x04002C67 RID: 11367
	public Transform AimTarget;

	// Token: 0x04002C68 RID: 11368
	public float FireRate;

	// Token: 0x04002C69 RID: 11369
	public float Timer;
}
