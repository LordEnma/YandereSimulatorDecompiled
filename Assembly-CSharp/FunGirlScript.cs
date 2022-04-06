using System;
using UnityEngine;

// Token: 0x020002D8 RID: 728
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014CE RID: 5326 RVA: 0x000CCDC9 File Offset: 0x000CAFC9
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014CF RID: 5327 RVA: 0x000CCDD4 File Offset: 0x000CAFD4
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

	// Token: 0x060014D0 RID: 5328 RVA: 0x000CCE84 File Offset: 0x000CB084
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

	// Token: 0x040020B6 RID: 8374
	public StudentManagerScript StudentManager;

	// Token: 0x040020B7 RID: 8375
	public GameObject Jukebox;

	// Token: 0x040020B8 RID: 8376
	public Transform Yandere;

	// Token: 0x040020B9 RID: 8377
	public UIPanel HUD;

	// Token: 0x040020BA RID: 8378
	public float Speed;
}
