using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x0600182E RID: 6190 RVA: 0x000E503D File Offset: 0x000E323D
	private void Update()
	{
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x000E5040 File Offset: 0x000E3240
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

	// Token: 0x0400231A RID: 8986
	public GameObject FemaleBloodyScream;

	// Token: 0x0400231B RID: 8987
	public GameObject MaleBloodyScream;

	// Token: 0x0400231C RID: 8988
	public Vector3 PreviousPosition;

	// Token: 0x0400231D RID: 8989
	public Collider MyCollider;

	// Token: 0x0400231E RID: 8990
	public float Timer;

	// Token: 0x0400231F RID: 8991
	public StudentScript Student;
}
