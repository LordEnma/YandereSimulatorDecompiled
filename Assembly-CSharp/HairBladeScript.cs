using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x0600183C RID: 6204 RVA: 0x000E60FD File Offset: 0x000E42FD
	private void Update()
	{
	}

	// Token: 0x0600183D RID: 6205 RVA: 0x000E6100 File Offset: 0x000E4300
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

	// Token: 0x0400234E RID: 9038
	public GameObject FemaleBloodyScream;

	// Token: 0x0400234F RID: 9039
	public GameObject MaleBloodyScream;

	// Token: 0x04002350 RID: 9040
	public Vector3 PreviousPosition;

	// Token: 0x04002351 RID: 9041
	public Collider MyCollider;

	// Token: 0x04002352 RID: 9042
	public float Timer;

	// Token: 0x04002353 RID: 9043
	public StudentScript Student;
}
