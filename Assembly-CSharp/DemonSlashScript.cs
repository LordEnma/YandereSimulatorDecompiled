using System;
using UnityEngine;

// Token: 0x0200027D RID: 637
public class DemonSlashScript : MonoBehaviour
{
	// Token: 0x06001371 RID: 4977 RVA: 0x000B2B59 File Offset: 0x000B0D59
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06001372 RID: 4978 RVA: 0x000B2B68 File Offset: 0x000B0D68
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

	// Token: 0x06001373 RID: 4979 RVA: 0x000B2BB8 File Offset: 0x000B0DB8
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

	// Token: 0x04001C91 RID: 7313
	public GameObject FemaleBloodyScream;

	// Token: 0x04001C92 RID: 7314
	public GameObject MaleBloodyScream;

	// Token: 0x04001C93 RID: 7315
	public AudioSource MyAudio;

	// Token: 0x04001C94 RID: 7316
	public Collider MyCollider;

	// Token: 0x04001C95 RID: 7317
	public float Timer;
}
