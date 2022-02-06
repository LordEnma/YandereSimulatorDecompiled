using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014B4 RID: 5300 RVA: 0x000CBAC1 File Offset: 0x000C9CC1
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014B5 RID: 5301 RVA: 0x000CBACC File Offset: 0x000C9CCC
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

	// Token: 0x060014B6 RID: 5302 RVA: 0x000CBB7C File Offset: 0x000C9D7C
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

	// Token: 0x04002081 RID: 8321
	public StudentManagerScript StudentManager;

	// Token: 0x04002082 RID: 8322
	public GameObject Jukebox;

	// Token: 0x04002083 RID: 8323
	public Transform Yandere;

	// Token: 0x04002084 RID: 8324
	public UIPanel HUD;

	// Token: 0x04002085 RID: 8325
	public float Speed;
}
