using System;
using UnityEngine;

// Token: 0x0200030D RID: 781
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001850 RID: 6224 RVA: 0x000E6E71 File Offset: 0x000E5071
	private void Update()
	{
	}

	// Token: 0x06001851 RID: 6225 RVA: 0x000E6E74 File Offset: 0x000E5074
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

	// Token: 0x0400236A RID: 9066
	public GameObject FemaleBloodyScream;

	// Token: 0x0400236B RID: 9067
	public GameObject MaleBloodyScream;

	// Token: 0x0400236C RID: 9068
	public Vector3 PreviousPosition;

	// Token: 0x0400236D RID: 9069
	public Collider MyCollider;

	// Token: 0x0400236E RID: 9070
	public float Timer;

	// Token: 0x0400236F RID: 9071
	public StudentScript Student;
}
