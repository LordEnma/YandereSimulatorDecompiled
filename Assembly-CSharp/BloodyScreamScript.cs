using System;
using UnityEngine;

// Token: 0x020000ED RID: 237
public class BloodyScreamScript : MonoBehaviour
{
	// Token: 0x06000A49 RID: 2633 RVA: 0x0005BB43 File Offset: 0x00059D43
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Screams[UnityEngine.Random.Range(0, this.Screams.Length)];
		component.Play();
	}

	// Token: 0x04000BCB RID: 3019
	public AudioClip[] Screams;
}
