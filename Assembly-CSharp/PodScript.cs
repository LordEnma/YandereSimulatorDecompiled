using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PodScript : MonoBehaviour
{
	// Token: 0x06001ABF RID: 6847 RVA: 0x00122610 File Offset: 0x00120810
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AC0 RID: 6848 RVA: 0x00122620 File Offset: 0x00120820
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

	// Token: 0x04002C91 RID: 11409
	public GameObject Projectile;

	// Token: 0x04002C92 RID: 11410
	public Transform SpawnPoint;

	// Token: 0x04002C93 RID: 11411
	public Transform PodTarget;

	// Token: 0x04002C94 RID: 11412
	public Transform AimTarget;

	// Token: 0x04002C95 RID: 11413
	public float FireRate;

	// Token: 0x04002C96 RID: 11414
	public float Timer;
}
