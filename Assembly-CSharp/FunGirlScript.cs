using System;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014C2 RID: 5314 RVA: 0x000CC499 File Offset: 0x000CA699
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x000CC4A4 File Offset: 0x000CA6A4
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

	// Token: 0x060014C4 RID: 5316 RVA: 0x000CC554 File Offset: 0x000CA754
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

	// Token: 0x04002095 RID: 8341
	public StudentManagerScript StudentManager;

	// Token: 0x04002096 RID: 8342
	public GameObject Jukebox;

	// Token: 0x04002097 RID: 8343
	public Transform Yandere;

	// Token: 0x04002098 RID: 8344
	public UIPanel HUD;

	// Token: 0x04002099 RID: 8345
	public float Speed;
}
