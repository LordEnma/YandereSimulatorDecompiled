using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001837 RID: 6199 RVA: 0x000E5921 File Offset: 0x000E3B21
	private void Update()
	{
	}

	// Token: 0x06001838 RID: 6200 RVA: 0x000E5924 File Offset: 0x000E3B24
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

	// Token: 0x04002329 RID: 9001
	public GameObject FemaleBloodyScream;

	// Token: 0x0400232A RID: 9002
	public GameObject MaleBloodyScream;

	// Token: 0x0400232B RID: 9003
	public Vector3 PreviousPosition;

	// Token: 0x0400232C RID: 9004
	public Collider MyCollider;

	// Token: 0x0400232D RID: 9005
	public float Timer;

	// Token: 0x0400232E RID: 9006
	public StudentScript Student;
}
