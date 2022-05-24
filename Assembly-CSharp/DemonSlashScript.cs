using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DemonSlashScript : MonoBehaviour
{
	// Token: 0x06001387 RID: 4999 RVA: 0x000B45C9 File Offset: 0x000B27C9
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06001388 RID: 5000 RVA: 0x000B45D8 File Offset: 0x000B27D8
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

	// Token: 0x06001389 RID: 5001 RVA: 0x000B4628 File Offset: 0x000B2828
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

	// Token: 0x04001CEA RID: 7402
	public GameObject FemaleBloodyScream;

	// Token: 0x04001CEB RID: 7403
	public GameObject MaleBloodyScream;

	// Token: 0x04001CEC RID: 7404
	public AudioSource MyAudio;

	// Token: 0x04001CED RID: 7405
	public Collider MyCollider;

	// Token: 0x04001CEE RID: 7406
	public float Timer;
}
