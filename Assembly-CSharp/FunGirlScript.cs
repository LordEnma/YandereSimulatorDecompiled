using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014AF RID: 5295 RVA: 0x000CB195 File Offset: 0x000C9395
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014B0 RID: 5296 RVA: 0x000CB1A0 File Offset: 0x000C93A0
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

	// Token: 0x060014B1 RID: 5297 RVA: 0x000CB250 File Offset: 0x000C9450
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

	// Token: 0x04002072 RID: 8306
	public StudentManagerScript StudentManager;

	// Token: 0x04002073 RID: 8307
	public GameObject Jukebox;

	// Token: 0x04002074 RID: 8308
	public Transform Yandere;

	// Token: 0x04002075 RID: 8309
	public UIPanel HUD;

	// Token: 0x04002076 RID: 8310
	public float Speed;
}
