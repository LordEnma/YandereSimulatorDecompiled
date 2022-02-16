using System;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014B9 RID: 5305 RVA: 0x000CBBB5 File Offset: 0x000C9DB5
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014BA RID: 5306 RVA: 0x000CBBC0 File Offset: 0x000C9DC0
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

	// Token: 0x060014BB RID: 5307 RVA: 0x000CBC70 File Offset: 0x000C9E70
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

	// Token: 0x04002086 RID: 8326
	public StudentManagerScript StudentManager;

	// Token: 0x04002087 RID: 8327
	public GameObject Jukebox;

	// Token: 0x04002088 RID: 8328
	public Transform Yandere;

	// Token: 0x04002089 RID: 8329
	public UIPanel HUD;

	// Token: 0x0400208A RID: 8330
	public float Speed;
}
