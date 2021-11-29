using System;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class ARMiyukiScript : MonoBehaviour
{
	// Token: 0x06000990 RID: 2448 RVA: 0x0004C885 File Offset: 0x0004AA85
	private void Start()
	{
		if (this.Enemy == null && this.MyStudent.StudentManager != null)
		{
			this.Enemy = this.MyStudent.StudentManager.MiyukiCat;
		}
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x0004C8BE File Offset: 0x0004AABE
	private void Update()
	{
		if (!this.Student && this.Yandere.AR)
		{
			base.transform.LookAt(this.Enemy.position);
			if (Input.GetButtonDown("X"))
			{
				this.Shoot();
			}
		}
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x0004C900 File Offset: 0x0004AB00
	public void Shoot()
	{
		if (this.Enemy == null)
		{
			this.Enemy = this.MyStudent.StudentManager.MiyukiCat;
		}
		base.transform.LookAt(this.Enemy.position);
		UnityEngine.Object.Instantiate<GameObject>(this.Bullet, this.BulletSpawnPoint.position, base.transform.rotation);
	}

	// Token: 0x04000836 RID: 2102
	public Transform BulletSpawnPoint;

	// Token: 0x04000837 RID: 2103
	public StudentScript MyStudent;

	// Token: 0x04000838 RID: 2104
	public YandereScript Yandere;

	// Token: 0x04000839 RID: 2105
	public GameObject Bullet;

	// Token: 0x0400083A RID: 2106
	public Transform Enemy;

	// Token: 0x0400083B RID: 2107
	public GameObject MagicalGirl;

	// Token: 0x0400083C RID: 2108
	public bool Student;
}
