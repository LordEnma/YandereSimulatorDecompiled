using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014A8 RID: 5288 RVA: 0x000CA7A9 File Offset: 0x000C89A9
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014A9 RID: 5289 RVA: 0x000CA7B4 File Offset: 0x000C89B4
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

	// Token: 0x060014AA RID: 5290 RVA: 0x000CA864 File Offset: 0x000C8A64
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

	// Token: 0x0400204F RID: 8271
	public StudentManagerScript StudentManager;

	// Token: 0x04002050 RID: 8272
	public GameObject Jukebox;

	// Token: 0x04002051 RID: 8273
	public Transform Yandere;

	// Token: 0x04002052 RID: 8274
	public UIPanel HUD;

	// Token: 0x04002053 RID: 8275
	public float Speed;
}
