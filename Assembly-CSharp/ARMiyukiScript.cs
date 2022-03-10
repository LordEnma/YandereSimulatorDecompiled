using System;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class ARMiyukiScript : MonoBehaviour
{
	// Token: 0x06000990 RID: 2448 RVA: 0x0004C975 File Offset: 0x0004AB75
	private void Start()
	{
		if (this.Enemy == null && this.MyStudent.StudentManager != null)
		{
			this.Enemy = this.MyStudent.StudentManager.MiyukiCat;
		}
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x0004C9B0 File Offset: 0x0004ABB0
	private void Update()
	{
		if (!this.Student && this.Yandere.AR && Time.timeScale == 1f)
		{
			base.transform.LookAt(this.Enemy.position);
			if (Input.GetButtonDown("X"))
			{
				this.Shoot();
			}
		}
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x0004CA08 File Offset: 0x0004AC08
	public void Shoot()
	{
		if (this.Enemy == null)
		{
			this.Enemy = this.MyStudent.StudentManager.MiyukiCat;
		}
		base.transform.LookAt(this.Enemy.position);
		UnityEngine.Object.Instantiate<GameObject>(this.Bullet, this.BulletSpawnPoint.position, base.transform.rotation);
	}

	// Token: 0x04000841 RID: 2113
	public Transform BulletSpawnPoint;

	// Token: 0x04000842 RID: 2114
	public StudentScript MyStudent;

	// Token: 0x04000843 RID: 2115
	public YandereScript Yandere;

	// Token: 0x04000844 RID: 2116
	public GameObject Bullet;

	// Token: 0x04000845 RID: 2117
	public Transform Enemy;

	// Token: 0x04000846 RID: 2118
	public GameObject MagicalGirl;

	// Token: 0x04000847 RID: 2119
	public bool Student;
}
