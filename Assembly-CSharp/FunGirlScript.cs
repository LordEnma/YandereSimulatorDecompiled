using System;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014C5 RID: 5317 RVA: 0x000CCA85 File Offset: 0x000CAC85
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014C6 RID: 5318 RVA: 0x000CCA90 File Offset: 0x000CAC90
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

	// Token: 0x060014C7 RID: 5319 RVA: 0x000CCB40 File Offset: 0x000CAD40
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

	// Token: 0x040020AF RID: 8367
	public StudentManagerScript StudentManager;

	// Token: 0x040020B0 RID: 8368
	public GameObject Jukebox;

	// Token: 0x040020B1 RID: 8369
	public Transform Yandere;

	// Token: 0x040020B2 RID: 8370
	public UIPanel HUD;

	// Token: 0x040020B3 RID: 8371
	public float Speed;
}
