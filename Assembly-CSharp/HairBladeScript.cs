using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001825 RID: 6181 RVA: 0x000E4D25 File Offset: 0x000E2F25
	private void Update()
	{
	}

	// Token: 0x06001826 RID: 6182 RVA: 0x000E4D28 File Offset: 0x000E2F28
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

	// Token: 0x04002310 RID: 8976
	public GameObject FemaleBloodyScream;

	// Token: 0x04002311 RID: 8977
	public GameObject MaleBloodyScream;

	// Token: 0x04002312 RID: 8978
	public Vector3 PreviousPosition;

	// Token: 0x04002313 RID: 8979
	public Collider MyCollider;

	// Token: 0x04002314 RID: 8980
	public float Timer;

	// Token: 0x04002315 RID: 8981
	public StudentScript Student;
}
