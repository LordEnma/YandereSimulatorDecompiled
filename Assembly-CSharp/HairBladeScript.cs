using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001827 RID: 6183 RVA: 0x000E4EC9 File Offset: 0x000E30C9
	private void Update()
	{
	}

	// Token: 0x06001828 RID: 6184 RVA: 0x000E4ECC File Offset: 0x000E30CC
	private void OnTriggerEnter(Collider other)
	{
		GameObject gameObject = other.gameObject.transform.root.gameObject;
		if (gameObject.GetComponent<StudentScript>() != null)
		{
			this.Student = gameObject.GetComponent<StudentScript>();
			if (this.Student.StudentID != 1 && this.Student.Alive)
			{
				this.Student.DeathType = DeathType.EasterEgg;
				UnityEngine.Object.Instantiate<GameObject>(this.Student.Male ? this.MaleBloodyScream : this.FemaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
				this.Student.BecomeRagdoll();
				this.Student.Ragdoll.Dismember();
				base.GetComponent<AudioSource>().Play();
			}
		}
	}

	// Token: 0x04002314 RID: 8980
	public GameObject FemaleBloodyScream;

	// Token: 0x04002315 RID: 8981
	public GameObject MaleBloodyScream;

	// Token: 0x04002316 RID: 8982
	public Vector3 PreviousPosition;

	// Token: 0x04002317 RID: 8983
	public Collider MyCollider;

	// Token: 0x04002318 RID: 8984
	public float Timer;

	// Token: 0x04002319 RID: 8985
	public StudentScript Student;
}
