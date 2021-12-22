using System;
using UnityEngine;

// Token: 0x020003E9 RID: 1001
public class RummageSpotScript : MonoBehaviour
{
	// Token: 0x06001BC2 RID: 7106 RVA: 0x0014277C File Offset: 0x0014097C
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

	// Token: 0x06001BC3 RID: 7107 RVA: 0x00142804 File Offset: 0x00140A04
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

	// Token: 0x06001BC4 RID: 7108 RVA: 0x00142944 File Offset: 0x00140B44
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

	// Token: 0x040030B3 RID: 12467
	public GameObject AlarmDisc;

	// Token: 0x040030B4 RID: 12468
	public DoorGapScript DoorGap;

	// Token: 0x040030B5 RID: 12469
	public SchemesScript Schemes;

	// Token: 0x040030B6 RID: 12470
	public YandereScript Yandere;

	// Token: 0x040030B7 RID: 12471
	public PromptScript Prompt;

	// Token: 0x040030B8 RID: 12472
	public ClockScript Clock;

	// Token: 0x040030B9 RID: 12473
	public Transform Target;

	// Token: 0x040030BA RID: 12474
	public int Phase;

	// Token: 0x040030BB RID: 12475
	public int ID;
}
