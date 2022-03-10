using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001837 RID: 6199 RVA: 0x000E5C51 File Offset: 0x000E3E51
	private void Update()
	{
	}

	// Token: 0x06001838 RID: 6200 RVA: 0x000E5C54 File Offset: 0x000E3E54
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

	// Token: 0x0400233D RID: 9021
	public GameObject FemaleBloodyScream;

	// Token: 0x0400233E RID: 9022
	public GameObject MaleBloodyScream;

	// Token: 0x0400233F RID: 9023
	public Vector3 PreviousPosition;

	// Token: 0x04002340 RID: 9024
	public Collider MyCollider;

	// Token: 0x04002341 RID: 9025
	public float Timer;

	// Token: 0x04002342 RID: 9026
	public StudentScript Student;
}
