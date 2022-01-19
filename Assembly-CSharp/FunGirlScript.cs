using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014B3 RID: 5299 RVA: 0x000CB561 File Offset: 0x000C9761
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014B4 RID: 5300 RVA: 0x000CB56C File Offset: 0x000C976C
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

	// Token: 0x060014B5 RID: 5301 RVA: 0x000CB61C File Offset: 0x000C981C
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

	// Token: 0x04002079 RID: 8313
	public StudentManagerScript StudentManager;

	// Token: 0x0400207A RID: 8314
	public GameObject Jukebox;

	// Token: 0x0400207B RID: 8315
	public Transform Yandere;

	// Token: 0x0400207C RID: 8316
	public UIPanel HUD;

	// Token: 0x0400207D RID: 8317
	public float Speed;
}
