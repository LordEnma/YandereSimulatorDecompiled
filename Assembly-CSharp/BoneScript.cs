using System;
using UnityEngine;

// Token: 0x020000F1 RID: 241
public class BoneScript : MonoBehaviour
{
	// Token: 0x06000A52 RID: 2642 RVA: 0x0005C0D0 File Offset: 0x0005A2D0
	private void Start()
	{
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, UnityEngine.Random.Range(0f, 360f), base.transform.eulerAngles.z);
		this.Origin = base.transform.position.y;
		this.MyAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x0005C14C File Offset: 0x0005A34C
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

	// Token: 0x06000A54 RID: 2644 RVA: 0x0005C270 File Offset: 0x0005A470
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

	// Token: 0x04000BE5 RID: 3045
	public AudioSource MyAudio;

	// Token: 0x04000BE6 RID: 3046
	public float Height;

	// Token: 0x04000BE7 RID: 3047
	public float Origin;

	// Token: 0x04000BE8 RID: 3048
	public bool Drop;
}
