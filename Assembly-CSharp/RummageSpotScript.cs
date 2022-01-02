using System;
using UnityEngine;

// Token: 0x020003E9 RID: 1001
public class RummageSpotScript : MonoBehaviour
{
	// Token: 0x06001BC4 RID: 7108 RVA: 0x00142B78 File Offset: 0x00140D78
	private void Start()
	{
		if (this.ID == 1)
		{
			if (GameGlobals.AnswerSheetUnavailable)
			{
				Debug.Log("The answer sheet is no longer available, due to events on a previous day.");
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
				return;
			}
			if (DateGlobals.Weekday == DayOfWeek.Friday && this.Clock.HourTime > 13.5f)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001BC5 RID: 7109 RVA: 0x00142C00 File Offset: 0x00140E00
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.EmptyHands();
				this.Yandere.CharacterAnimation.CrossFade("f02_rummage_00");
				this.Yandere.ProgressBar.transform.parent.gameObject.SetActive(true);
				this.Yandere.RummageSpot = this;
				this.Yandere.Rummaging = true;
				this.Yandere.CanMove = false;
				component.Play();
			}
		}
		if (this.Yandere.Rummaging)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position, Quaternion.identity);
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
			gameObject.transform.localScale = new Vector3(750f, gameObject.transform.localScale.y, 750f);
		}
		if (this.Yandere.Noticed)
		{
			component.Stop();
		}
	}

	// Token: 0x06001BC6 RID: 7110 RVA: 0x00142D40 File Offset: 0x00140F40
	public void GetReward()
	{
		if (this.ID == 1)
		{
			if (this.Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 5);
				this.Schemes.UpdateInstructions();
				this.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.Phase++;
				return;
			}
			if (this.Phase == 2)
			{
				SchemeGlobals.SetSchemeStage(5, 8);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
				this.Phase++;
			}
		}
	}

	// Token: 0x040030BA RID: 12474
	public GameObject AlarmDisc;

	// Token: 0x040030BB RID: 12475
	public DoorGapScript DoorGap;

	// Token: 0x040030BC RID: 12476
	public SchemesScript Schemes;

	// Token: 0x040030BD RID: 12477
	public YandereScript Yandere;

	// Token: 0x040030BE RID: 12478
	public PromptScript Prompt;

	// Token: 0x040030BF RID: 12479
	public ClockScript Clock;

	// Token: 0x040030C0 RID: 12480
	public Transform Target;

	// Token: 0x040030C1 RID: 12481
	public int Phase;

	// Token: 0x040030C2 RID: 12482
	public int ID;
}
