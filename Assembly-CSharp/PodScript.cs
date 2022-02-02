using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AAD RID: 6829 RVA: 0x001216A0 File Offset: 0x0011F8A0
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AAE RID: 6830 RVA: 0x001216B0 File Offset: 0x0011F8B0
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

	// Token: 0x04002C77 RID: 11383
	public GameObject Projectile;

	// Token: 0x04002C78 RID: 11384
	public Transform SpawnPoint;

	// Token: 0x04002C79 RID: 11385
	public Transform PodTarget;

	// Token: 0x04002C7A RID: 11386
	public Transform AimTarget;

	// Token: 0x04002C7B RID: 11387
	public float FireRate;

	// Token: 0x04002C7C RID: 11388
	public float Timer;
}
