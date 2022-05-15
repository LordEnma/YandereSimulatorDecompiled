using System;
using UnityEngine;

// Token: 0x020002D9 RID: 729
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014D6 RID: 5334 RVA: 0x000CD745 File Offset: 0x000CB945
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014D7 RID: 5335 RVA: 0x000CD750 File Offset: 0x000CB950
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

	// Token: 0x060014D8 RID: 5336 RVA: 0x000CD800 File Offset: 0x000CBA00
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

	// Token: 0x040020CA RID: 8394
	public StudentManagerScript StudentManager;

	// Token: 0x040020CB RID: 8395
	public GameObject Jukebox;

	// Token: 0x040020CC RID: 8396
	public Transform Yandere;

	// Token: 0x040020CD RID: 8397
	public UIPanel HUD;

	// Token: 0x040020CE RID: 8398
	public float Speed;
}
