using System;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014C8 RID: 5320 RVA: 0x000CCCC1 File Offset: 0x000CAEC1
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014C9 RID: 5321 RVA: 0x000CCCCC File Offset: 0x000CAECC
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

	// Token: 0x060014CA RID: 5322 RVA: 0x000CCD7C File Offset: 0x000CAF7C
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

	// Token: 0x040020B4 RID: 8372
	public StudentManagerScript StudentManager;

	// Token: 0x040020B5 RID: 8373
	public GameObject Jukebox;

	// Token: 0x040020B6 RID: 8374
	public Transform Yandere;

	// Token: 0x040020B7 RID: 8375
	public UIPanel HUD;

	// Token: 0x040020B8 RID: 8376
	public float Speed;
}
