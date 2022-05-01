using System;
using UnityEngine;

// Token: 0x020003AE RID: 942
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AE1 RID: 6881 RVA: 0x00124930 File Offset: 0x00122B30
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AE2 RID: 6882 RVA: 0x00124940 File Offset: 0x00122B40
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

	// Token: 0x04002D01 RID: 11521
	public GameObject Projectile;

	// Token: 0x04002D02 RID: 11522
	public Transform SpawnPoint;

	// Token: 0x04002D03 RID: 11523
	public Transform PodTarget;

	// Token: 0x04002D04 RID: 11524
	public Transform AimTarget;

	// Token: 0x04002D05 RID: 11525
	public float FireRate;

	// Token: 0x04002D06 RID: 11526
	public float Timer;
}
