using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000CC RID: 204
public class AntiCheatScript : MonoBehaviour
{
	// Token: 0x060009C5 RID: 2501 RVA: 0x0005129A File Offset: 0x0004F49A
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x000512A8 File Offset: 0x0004F4A8
	private void Update()
	{
		if (this.Check && !this.MyAudio.isPlaying)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x000512DC File Offset: 0x0004F4DC
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YandereChan")
		{
			this.Jukebox.SetActive(false);
			this.Check = true;
			this.MyAudio.Play();
		}
	}

	// Token: 0x04000A23 RID: 2595
	public AudioSource MyAudio;

	// Token: 0x04000A24 RID: 2596
	public GameObject Jukebox;

	// Token: 0x04000A25 RID: 2597
	public bool Check;
}
