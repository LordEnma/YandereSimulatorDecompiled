using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001842 RID: 6210 RVA: 0x000E65FD File Offset: 0x000E47FD
	private void Update()
	{
	}

	// Token: 0x06001843 RID: 6211 RVA: 0x000E6600 File Offset: 0x000E4800
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

	// Token: 0x0400235C RID: 9052
	public GameObject FemaleBloodyScream;

	// Token: 0x0400235D RID: 9053
	public GameObject MaleBloodyScream;

	// Token: 0x0400235E RID: 9054
	public Vector3 PreviousPosition;

	// Token: 0x0400235F RID: 9055
	public Collider MyCollider;

	// Token: 0x04002360 RID: 9056
	public float Timer;

	// Token: 0x04002361 RID: 9057
	public StudentScript Student;
}
