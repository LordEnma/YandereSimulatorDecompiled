using System;
using UnityEngine;

// Token: 0x0200030D RID: 781
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001848 RID: 6216 RVA: 0x000E670D File Offset: 0x000E490D
	private void Update()
	{
	}

	// Token: 0x06001849 RID: 6217 RVA: 0x000E6710 File Offset: 0x000E4910
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

	// Token: 0x0400235E RID: 9054
	public GameObject FemaleBloodyScream;

	// Token: 0x0400235F RID: 9055
	public GameObject MaleBloodyScream;

	// Token: 0x04002360 RID: 9056
	public Vector3 PreviousPosition;

	// Token: 0x04002361 RID: 9057
	public Collider MyCollider;

	// Token: 0x04002362 RID: 9058
	public float Timer;

	// Token: 0x04002363 RID: 9059
	public StudentScript Student;
}
