using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001817 RID: 6167 RVA: 0x000E3A65 File Offset: 0x000E1C65
	private void Update()
	{
	}

	// Token: 0x06001818 RID: 6168 RVA: 0x000E3A68 File Offset: 0x000E1C68
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

	// Token: 0x040022E0 RID: 8928
	public GameObject FemaleBloodyScream;

	// Token: 0x040022E1 RID: 8929
	public GameObject MaleBloodyScream;

	// Token: 0x040022E2 RID: 8930
	public Vector3 PreviousPosition;

	// Token: 0x040022E3 RID: 8931
	public Collider MyCollider;

	// Token: 0x040022E4 RID: 8932
	public float Timer;

	// Token: 0x040022E5 RID: 8933
	public StudentScript Student;
}
