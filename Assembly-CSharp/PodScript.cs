using System;
using UnityEngine;

// Token: 0x020003AE RID: 942
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AD9 RID: 6873 RVA: 0x00123F10 File Offset: 0x00122110
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001ADA RID: 6874 RVA: 0x00123F20 File Offset: 0x00122120
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

	// Token: 0x04002CEE RID: 11502
	public GameObject Projectile;

	// Token: 0x04002CEF RID: 11503
	public Transform SpawnPoint;

	// Token: 0x04002CF0 RID: 11504
	public Transform PodTarget;

	// Token: 0x04002CF1 RID: 11505
	public Transform AimTarget;

	// Token: 0x04002CF2 RID: 11506
	public float FireRate;

	// Token: 0x04002CF3 RID: 11507
	public float Timer;
}
