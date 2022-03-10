using System;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014C2 RID: 5314 RVA: 0x000CC615 File Offset: 0x000CA815
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x000CC620 File Offset: 0x000CA820
	private void Update()
	{
		if (this.Speed < 5f)
		{
			this.Speed += Time.deltaTime * 0.1f;
		}
		else
		{
			this.Speed = 5f;
		}
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yandere.position, Time.deltaTime * this.Speed);
		base.transform.LookAt(this.Yandere.position);
		if (Vector3.Distance(base.transform.position, this.Yandere.position) < 0.5f)
		{
			Application.Quit();
		}
	}

	// Token: 0x060014C4 RID: 5316 RVA: 0x000CC6D0 File Offset: 0x000CA8D0
	private void ChaseYandereChan()
	{
		SchoolGlobals.SchoolAtmosphereSet = true;
		SchoolGlobals.SchoolAtmosphere = 0f;
		this.StudentManager.SetAtmosphere();
		foreach (StudentScript studentScript in this.StudentManager.Students)
		{
			if (studentScript != null)
			{
				studentScript.gameObject.SetActive(false);
			}
		}
		this.StudentManager.Yandere.NoDebug = true;
		base.gameObject.SetActive(true);
		this.Jukebox.SetActive(false);
		this.HUD.enabled = false;
	}

	// Token: 0x0400209F RID: 8351
	public StudentManagerScript StudentManager;

	// Token: 0x040020A0 RID: 8352
	public GameObject Jukebox;

	// Token: 0x040020A1 RID: 8353
	public Transform Yandere;

	// Token: 0x040020A2 RID: 8354
	public UIPanel HUD;

	// Token: 0x040020A3 RID: 8355
	public float Speed;
}
