using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public class DemonSlashScript : MonoBehaviour
{
	// Token: 0x06001385 RID: 4997 RVA: 0x000B42B5 File Offset: 0x000B24B5
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06001386 RID: 4998 RVA: 0x000B42C4 File Offset: 0x000B24C4
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

	// Token: 0x06001387 RID: 4999 RVA: 0x000B4314 File Offset: 0x000B2514
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

	// Token: 0x04001CE3 RID: 7395
	public GameObject FemaleBloodyScream;

	// Token: 0x04001CE4 RID: 7396
	public GameObject MaleBloodyScream;

	// Token: 0x04001CE5 RID: 7397
	public AudioSource MyAudio;

	// Token: 0x04001CE6 RID: 7398
	public Collider MyCollider;

	// Token: 0x04001CE7 RID: 7399
	public float Timer;
}
