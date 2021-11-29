using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000DC RID: 220
public class BakeSaleScript : MonoBehaviour
{
	// Token: 0x06000A0C RID: 2572 RVA: 0x0005697C File Offset: 0x00054B7C
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 60f && this.StudentManager.Students[this.ID] != null)
		{
			if (this.StudentManager.Students[this.ID].Routine)
			{
				Debug.Log(this.StudentManager.Students[this.ID].Name + " has decided to go to the bake sale.");
				this.Timer = 0f;
				this.StudentManager.Students[this.ID].Meeting = true;
				this.StudentManager.Students[this.ID].BakeSale = true;
				this.StudentManager.Students[this.ID].MeetTime = 0.0001f;
				this.StudentManager.Students[this.ID].MeetSpot = this.MeetSpot;
				this.IncreaseID();
			}
			else
			{
				this.IncreaseID();
			}
		}
		if (this.StudentManager.Yandere.Alerts > 0 || this.StudentManager.Yandere.Police.StudentFoundCorpse)
		{
			this.AmaiFail.SetActive(true);
			if (Input.GetKeyDown("`"))
			{
				SceneManager.LoadScene("LoadingScene");
				return;
			}
		}
		else if (this.StudentManager.Students[12] != null && this.StudentManager.Students[12].Ragdoll.Disposed)
		{
			this.AmaiSuccess.SetActive(true);
		}
	}

	// Token: 0x06000A0D RID: 2573 RVA: 0x00056B15 File Offset: 0x00054D15
	private void IncreaseID()
	{
		this.ID++;
		if (this.ID > 89)
		{
			this.ID = 46;
		}
	}

	// Token: 0x04000AC6 RID: 2758
	public StudentManagerScript StudentManager;

	// Token: 0x04000AC7 RID: 2759
	public GameObject AmaiSuccess;

	// Token: 0x04000AC8 RID: 2760
	public GameObject AmaiFail;

	// Token: 0x04000AC9 RID: 2761
	public Transform MeetSpot;

	// Token: 0x04000ACA RID: 2762
	public float Timer;

	// Token: 0x04000ACB RID: 2763
	public int ID = 46;
}
