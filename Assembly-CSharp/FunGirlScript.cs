using System;
using UnityEngine;

// Token: 0x020002D8 RID: 728
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014D0 RID: 5328 RVA: 0x000CCFB1 File Offset: 0x000CB1B1
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014D1 RID: 5329 RVA: 0x000CCFBC File Offset: 0x000CB1BC
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

	// Token: 0x060014D2 RID: 5330 RVA: 0x000CD06C File Offset: 0x000CB26C
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

	// Token: 0x040020B8 RID: 8376
	public StudentManagerScript StudentManager;

	// Token: 0x040020B9 RID: 8377
	public GameObject Jukebox;

	// Token: 0x040020BA RID: 8378
	public Transform Yandere;

	// Token: 0x040020BB RID: 8379
	public UIPanel HUD;

	// Token: 0x040020BC RID: 8380
	public float Speed;
}
