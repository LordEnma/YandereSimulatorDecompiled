using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000DC RID: 220
public class BakeSaleScript : MonoBehaviour
{
	// Token: 0x06000A0C RID: 2572 RVA: 0x00056C9C File Offset: 0x00054E9C
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

	// Token: 0x06000A0D RID: 2573 RVA: 0x00056E35 File Offset: 0x00055035
	private void IncreaseID()
	{
		this.ID++;
		if (this.ID > 89)
		{
			this.ID = 46;
		}
	}

	// Token: 0x04000AD2 RID: 2770
	public StudentManagerScript StudentManager;

	// Token: 0x04000AD3 RID: 2771
	public GameObject AmaiSuccess;

	// Token: 0x04000AD4 RID: 2772
	public GameObject AmaiFail;

	// Token: 0x04000AD5 RID: 2773
	public Transform MeetSpot;

	// Token: 0x04000AD6 RID: 2774
	public float Timer;

	// Token: 0x04000AD7 RID: 2775
	public int ID = 46;
}
