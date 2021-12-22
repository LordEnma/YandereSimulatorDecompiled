using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x0600181E RID: 6174 RVA: 0x000E4225 File Offset: 0x000E2425
	private void Update()
	{
	}

	// Token: 0x0600181F RID: 6175 RVA: 0x000E4228 File Offset: 0x000E2428
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

	// Token: 0x04002300 RID: 8960
	public GameObject FemaleBloodyScream;

	// Token: 0x04002301 RID: 8961
	public GameObject MaleBloodyScream;

	// Token: 0x04002302 RID: 8962
	public Vector3 PreviousPosition;

	// Token: 0x04002303 RID: 8963
	public Collider MyCollider;

	// Token: 0x04002304 RID: 8964
	public float Timer;

	// Token: 0x04002305 RID: 8965
	public StudentScript Student;
}
