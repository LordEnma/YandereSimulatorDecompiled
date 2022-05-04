using System;
using UnityEngine;

// Token: 0x020002D8 RID: 728
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014D4 RID: 5332 RVA: 0x000CD445 File Offset: 0x000CB645
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014D5 RID: 5333 RVA: 0x000CD450 File Offset: 0x000CB650
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

	// Token: 0x060014D6 RID: 5334 RVA: 0x000CD500 File Offset: 0x000CB700
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

	// Token: 0x040020C1 RID: 8385
	public StudentManagerScript StudentManager;

	// Token: 0x040020C2 RID: 8386
	public GameObject Jukebox;

	// Token: 0x040020C3 RID: 8387
	public Transform Yandere;

	// Token: 0x040020C4 RID: 8388
	public UIPanel HUD;

	// Token: 0x040020C5 RID: 8389
	public float Speed;
}
