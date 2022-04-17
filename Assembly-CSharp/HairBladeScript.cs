using System;
using UnityEngine;

// Token: 0x0200030D RID: 781
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x0600184C RID: 6220 RVA: 0x000E6975 File Offset: 0x000E4B75
	private void Update()
	{
	}

	// Token: 0x0600184D RID: 6221 RVA: 0x000E6978 File Offset: 0x000E4B78
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

	// Token: 0x04002361 RID: 9057
	public GameObject FemaleBloodyScream;

	// Token: 0x04002362 RID: 9058
	public GameObject MaleBloodyScream;

	// Token: 0x04002363 RID: 9059
	public Vector3 PreviousPosition;

	// Token: 0x04002364 RID: 9060
	public Collider MyCollider;

	// Token: 0x04002365 RID: 9061
	public float Timer;

	// Token: 0x04002366 RID: 9062
	public StudentScript Student;
}
