using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001824 RID: 6180 RVA: 0x000E4909 File Offset: 0x000E2B09
	private void Update()
	{
	}

	// Token: 0x06001825 RID: 6181 RVA: 0x000E490C File Offset: 0x000E2B0C
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

	// Token: 0x0400230B RID: 8971
	public GameObject FemaleBloodyScream;

	// Token: 0x0400230C RID: 8972
	public GameObject MaleBloodyScream;

	// Token: 0x0400230D RID: 8973
	public Vector3 PreviousPosition;

	// Token: 0x0400230E RID: 8974
	public Collider MyCollider;

	// Token: 0x0400230F RID: 8975
	public float Timer;

	// Token: 0x04002310 RID: 8976
	public StudentScript Student;
}
