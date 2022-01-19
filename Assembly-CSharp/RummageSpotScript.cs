using System;
using UnityEngine;

// Token: 0x020003EC RID: 1004
public class RummageSpotScript : MonoBehaviour
{
	// Token: 0x06001BCD RID: 7117 RVA: 0x001445F4 File Offset: 0x001427F4
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

	// Token: 0x06001BCE RID: 7118 RVA: 0x0014467C File Offset: 0x0014287C
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

	// Token: 0x06001BCF RID: 7119 RVA: 0x001447BC File Offset: 0x001429BC
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

	// Token: 0x040030C5 RID: 12485
	public GameObject AlarmDisc;

	// Token: 0x040030C6 RID: 12486
	public DoorGapScript DoorGap;

	// Token: 0x040030C7 RID: 12487
	public SchemesScript Schemes;

	// Token: 0x040030C8 RID: 12488
	public YandereScript Yandere;

	// Token: 0x040030C9 RID: 12489
	public PromptScript Prompt;

	// Token: 0x040030CA RID: 12490
	public ClockScript Clock;

	// Token: 0x040030CB RID: 12491
	public Transform Target;

	// Token: 0x040030CC RID: 12492
	public int Phase;

	// Token: 0x040030CD RID: 12493
	public int ID;
}
