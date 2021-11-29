using System;
using UnityEngine;

// Token: 0x020000EB RID: 235
public class BloodyScreamScript : MonoBehaviour
{
	// Token: 0x06000A44 RID: 2628 RVA: 0x0005B20F File Offset: 0x0005940F
	private void Start()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Screams[UnityEngine.Random.Range(0, this.Screams.Length)];
		component.Play();
	}

	// Token: 0x04000BB1 RID: 2993
	public AudioClip[] Screams;
}
