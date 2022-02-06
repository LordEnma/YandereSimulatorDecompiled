using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AAF RID: 6831 RVA: 0x001218BC File Offset: 0x0011FABC
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AB0 RID: 6832 RVA: 0x001218CC File Offset: 0x0011FACC
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

	// Token: 0x04002C7B RID: 11387
	public GameObject Projectile;

	// Token: 0x04002C7C RID: 11388
	public Transform SpawnPoint;

	// Token: 0x04002C7D RID: 11389
	public Transform PodTarget;

	// Token: 0x04002C7E RID: 11390
	public Transform AimTarget;

	// Token: 0x04002C7F RID: 11391
	public float FireRate;

	// Token: 0x04002C80 RID: 11392
	public float Timer;
}
