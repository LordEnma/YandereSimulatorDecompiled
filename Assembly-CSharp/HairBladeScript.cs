using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001820 RID: 6176 RVA: 0x000E44F5 File Offset: 0x000E26F5
	private void Update()
	{
	}

	// Token: 0x06001821 RID: 6177 RVA: 0x000E44F8 File Offset: 0x000E26F8
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

	// Token: 0x04002304 RID: 8964
	public GameObject FemaleBloodyScream;

	// Token: 0x04002305 RID: 8965
	public GameObject MaleBloodyScream;

	// Token: 0x04002306 RID: 8966
	public Vector3 PreviousPosition;

	// Token: 0x04002307 RID: 8967
	public Collider MyCollider;

	// Token: 0x04002308 RID: 8968
	public float Timer;

	// Token: 0x04002309 RID: 8969
	public StudentScript Student;
}
