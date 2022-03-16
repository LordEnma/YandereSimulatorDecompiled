using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public class DemonSlashScript : MonoBehaviour
{
	// Token: 0x06001380 RID: 4992 RVA: 0x000B3C19 File Offset: 0x000B1E19
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06001381 RID: 4993 RVA: 0x000B3C28 File Offset: 0x000B1E28
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

	// Token: 0x06001382 RID: 4994 RVA: 0x000B3C78 File Offset: 0x000B1E78
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

	// Token: 0x04001CD7 RID: 7383
	public GameObject FemaleBloodyScream;

	// Token: 0x04001CD8 RID: 7384
	public GameObject MaleBloodyScream;

	// Token: 0x04001CD9 RID: 7385
	public AudioSource MyAudio;

	// Token: 0x04001CDA RID: 7386
	public Collider MyCollider;

	// Token: 0x04001CDB RID: 7387
	public float Timer;
}
