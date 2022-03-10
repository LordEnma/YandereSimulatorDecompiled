using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AC0 RID: 6848 RVA: 0x001229E8 File Offset: 0x00120BE8
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AC1 RID: 6849 RVA: 0x001229F8 File Offset: 0x00120BF8
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

	// Token: 0x04002CA7 RID: 11431
	public GameObject Projectile;

	// Token: 0x04002CA8 RID: 11432
	public Transform SpawnPoint;

	// Token: 0x04002CA9 RID: 11433
	public Transform PodTarget;

	// Token: 0x04002CAA RID: 11434
	public Transform AimTarget;

	// Token: 0x04002CAB RID: 11435
	public float FireRate;

	// Token: 0x04002CAC RID: 11436
	public float Timer;
}
