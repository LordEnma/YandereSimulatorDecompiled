using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public class DemonSlashScript : MonoBehaviour
{
	// Token: 0x0600137D RID: 4989 RVA: 0x000B34C9 File Offset: 0x000B16C9
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x000B34D8 File Offset: 0x000B16D8
	private void Update()
	{
		if (this.MyCollider.enabled)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.33333334f)
			{
				this.MyCollider.enabled = false;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x000B3528 File Offset: 0x000B1728
	private void OnTriggerEnter(Collider other)
	{
		Transform root = other.gameObject.transform.root;
		StudentScript component = root.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID != 1 && component.Alive)
		{
			component.DeathType = DeathType.EasterEgg;
			if (!component.Male)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.FemaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
			}
			else
			{
				UnityEngine.Object.Instantiate<GameObject>(this.MaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
			}
			component.BecomeRagdoll();
			component.Ragdoll.Dismember();
			this.MyAudio.Play();
		}
	}

	// Token: 0x04001CBF RID: 7359
	public GameObject FemaleBloodyScream;

	// Token: 0x04001CC0 RID: 7360
	public GameObject MaleBloodyScream;

	// Token: 0x04001CC1 RID: 7361
	public AudioSource MyAudio;

	// Token: 0x04001CC2 RID: 7362
	public Collider MyCollider;

	// Token: 0x04001CC3 RID: 7363
	public float Timer;
}
