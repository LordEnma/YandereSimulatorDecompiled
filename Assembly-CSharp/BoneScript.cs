using System;
using UnityEngine;

// Token: 0x020000F0 RID: 240
public class BoneScript : MonoBehaviour
{
	// Token: 0x06000A4E RID: 2638 RVA: 0x0005BA64 File Offset: 0x00059C64
	private void Start()
	{
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, UnityEngine.Random.Range(0f, 360f), base.transform.eulerAngles.z);
		this.Origin = base.transform.position.y;
		this.MyAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x0005BAE0 File Offset: 0x00059CE0
	private void Update()
	{
		if (this.Drop)
		{
			this.Height -= Time.deltaTime;
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + this.Height, base.transform.position.z);
			if (base.transform.position.y < this.Origin - 2.155f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			return;
		}
		if (base.transform.position.y < this.Origin + 2f - 0.0001f)
		{
			base.transform.position = new Vector3(base.transform.position.x, Mathf.Lerp(base.transform.position.y, this.Origin + 2f, Time.deltaTime * 10f), base.transform.position.z);
			return;
		}
		this.Drop = true;
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x0005BC04 File Offset: 0x00059E04
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				component.DeathType = DeathType.EasterEgg;
				component.BecomeRagdoll();
				Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
				rigidbody.isKinematic = false;
				rigidbody.AddForce(base.transform.up);
			}
		}
	}

	// Token: 0x04000BCF RID: 3023
	public AudioSource MyAudio;

	// Token: 0x04000BD0 RID: 3024
	public float Height;

	// Token: 0x04000BD1 RID: 3025
	public float Origin;

	// Token: 0x04000BD2 RID: 3026
	public bool Drop;
}
