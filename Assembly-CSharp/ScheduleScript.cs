using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class ScheduleScript : MonoBehaviour
{
	// Token: 0x06001C7D RID: 7293 RVA: 0x0014DD90 File Offset: 0x0014BF90
	public void Start()
	{
		if (!this.Initialized)
		{
			if (this.VoidGoddess != null)
			{
				this.VoidGoddess.Start();
				this.Portraits[1].mainTexture = this.VoidGoddess.Portraits[11].mainTexture;
				this.Portraits[2].mainTexture = this.VoidGoddess.Portraits[1].mainTexture;
				this.Portraits[3].mainTexture = this.VoidGoddess.Portraits[11].mainTexture;
				this.Portraits[4].mainTexture = this.VoidGoddess.Portraits[10].mainTexture;
				this.Portraits[5].mainTexture = this.VoidGoddess.Portraits[11].mainTexture;
				this.Portraits[6].mainTexture = this.VoidGoddess.Portraits[81].mainTexture;
				this.Portraits[7].mainTexture = this.VoidGoddess.Portraits[2].mainTexture;
				this.Portraits[8].mainTexture = this.VoidGoddess.Portraits[3].mainTexture;
				this.Portraits[9].mainTexture = this.VoidGoddess.Portraits[62].mainTexture;
				this.Portraits[10].mainTexture = this.VoidGoddess.Portraits[63].mainTexture;
			}
			this.Initialized = true;
		}
		this.Weekday = DateGlobals.Weekday;
		this.UpdateIcons();
	}

	// Token: 0x06001C7E RID: 7294 RVA: 0x0014DF1C File Offset: 0x0014C11C
	private void UpdateIcons()
	{
		this.Header.text = this.Weekday.ToString() + " Schedule";
		for (int i = 1; i < this.EventIcons.Length; i++)
		{
			this.EventIcons[i].SetActive(false);
		}
		this.EventIcons[1].SetActive(true);
		this.Descriptions[1] = "Every morning, Osana and Senpai will have a conversation. By eavesdropping on this conversation, you can learn about an interaction that Osana and Senpai will have later in the day.";
		if (this.Weekday == DayOfWeek.Monday)
		{
			this.EventIcons[7].SetActive(true);
			this.Descriptions[7] = "At lunchtime, Osana will give Senpai a bento. By sabotaging the bento, you can make Senpai dislike Osana.";
		}
		if (this.Weekday == DayOfWeek.Friday)
		{
			this.EventIcons[7].SetActive(true);
			this.Descriptions[7] = "At lunchtime, Osana will share her favorite music with Senpai. By replacing her music tracks with audio that sounds bad out-of-context, you can make Senpai dislike Osana.";
		}
		if (this.Weekday == DayOfWeek.Tuesday)
		{
			this.EventIcons[10].SetActive(true);
			this.Descriptions[10] = "Osana is going to meet up with Senpai and return the book that she borrowed.";
		}
		if (this.Weekday == DayOfWeek.Wednesday)
		{
			this.EventIcons[10].SetActive(true);
			this.Descriptions[10] = "Osana is going to meet up with Senpai and show him a photo she took earlier in the day.";
		}
		if (this.Weekday == DayOfWeek.Thursday)
		{
			this.EventIcons[10].SetActive(true);
			this.Descriptions[10] = "Osana is going to meet up with Senpai and go on a date with him.";
		}
		if (this.Weekday == DayOfWeek.Friday)
		{
			this.EventIcons[10].SetActive(true);
			this.Descriptions[10] = "Osana is going to put a note in Senpai's locker and tell him to meet her under the cherry tree behind the school. Under the cherry tree, Osana is going to confess her love to Senpai.";
		}
		this.EventIcons[12].SetActive(true);
		this.Descriptions[12] = "Every morning, Osana and Raibaru will have a conversation. By eavesdropping on this conversation, you can learn a clue about how to sabotage an interaction that Osana and Senpai will have later in the day.";
		if (this.Weekday == DayOfWeek.Monday)
		{
			this.EventIcons[13].SetActive(true);
			this.Descriptions[13] = "Osana is going to put two bento boxes on her desk. One bento is for her; the other bento is for Senpai. You can put emetic poison into Senpai's bento to make him puke and damage his relationship with Osana. You can also put lethal poison into Osana's bento to kill her, or put emetic poison into her bento to put her into a vulnerable position.";
			this.EventIcons[14].SetActive(true);
			this.Descriptions[14] = "Raibaru is going to ask Osana to talk about what kind of boys she likes. By eavesdropping on this conversation, you can learn the information you'd need in order to make another boy become appealing to Osana.";
			this.EventIcons[15].SetActive(true);
			this.Descriptions[15] = "Osana is going to recieve a distressing phone call. By eavesdropping on this call, you can learn some of the information you'd need in order to put Osana into your debt.";
			this.EventIcons[16].SetActive(true);
			this.Descriptions[16] = "Osana and Raibaru are going to tour the school and visit each of the clubrooms. By eavesdropping on their conversations, you can learn about Osana's likes and dislikes.";
			this.EventIcons[18].SetActive(true);
			this.Descriptions[18] = "Osana and Raibaru are going to have a private discussion on the school rooftop, behind the air vents. By eavesdropping on their conversations, you can learn some of the information you'd need in order to put Osana into your debt.";
		}
		else if (this.Weekday == DayOfWeek.Tuesday)
		{
			this.EventIcons[17].SetActive(true);
			this.Descriptions[17] = "Osana is going to read the book she borrowed from Senpai. When she leaves the book unattended, you will have an opportunity to damage the book.";
		}
		else if (this.Weekday == DayOfWeek.Wednesday)
		{
			this.EventIcons[17].SetActive(true);
			this.Descriptions[17] = "Osana is going to take a photo of a pretty location somewhere in school.";
		}
		else if (this.Weekday == DayOfWeek.Thursday)
		{
			this.EventIcons[13].SetActive(true);
			this.Descriptions[13] = "Osana is going to talk with Raibaru about how hungry she is. This is an indication that this is the one time that Osana is willing to accept food from a stranger.";
			this.EventIcons[17].SetActive(true);
			this.Descriptions[17] = "Osana is going to sunbathe at the school pool.";
			this.EventIcons[19].SetActive(true);
			this.Descriptions[19] = "Osana is going to take a nap on the school rooftop. If you sabotage her phone alarm, you can make her late for her date with Senpai.";
		}
		else if (this.Weekday == DayOfWeek.Friday)
		{
			this.EventIcons[15].SetActive(true);
			this.Descriptions[15] = "Osana is going to create a playlist of songs for Senpai to listen to.";
		}
		if (this.Weekday == DayOfWeek.Friday)
		{
			this.EventIcons[24].SetActive(true);
			this.Descriptions[24] = "Musume is going to have a private conversation with Osana. If you record this conversation, you can edit the recording to make an audio file that sounds bad when it's heard out-of-context.";
		}
		this.EventIcons[31].SetActive(true);
		this.Descriptions[31] = "Sakyu and Inkyu are going to sit down on a bench and have a conversation about the school.";
		this.EventIcons[37].SetActive(true);
		this.Descriptions[37] = "Before eating lunch, Sakyu is going to remove the large, gaudy ring that she usually wears.";
		this.EventIcons[47].SetActive(true);
		this.Descriptions[47] = "Before eating lunch, Horo and Yaku are going to have a conversation about a popular anime show called ''Magical Girl Pretty Miyuki''.";
		if (this.Weekday == DayOfWeek.Monday)
		{
			this.EventIcons[49].SetActive(true);
			this.Descriptions[49] = "After performing their cleaning duties, Horo and Yaku are going to have a conversation about a recent conspiracy theory revolving around a video game called ''Yanvania: Senpai of the Night''.";
		}
	}

	// Token: 0x06001C7F RID: 7295 RVA: 0x0014E2AC File Offset: 0x0014C4AC
	private void Update()
	{
		this.PauseScreen.Sideways = true;
		if (this.InputManager.TappedRight)
		{
			this.X++;
			this.UpdateHighlightPosition();
		}
		else if (this.InputManager.TappedLeft)
		{
			this.X--;
			this.UpdateHighlightPosition();
		}
		if (this.InputManager.TappedUp)
		{
			this.Y--;
			this.UpdateHighlightPosition();
		}
		else if (this.InputManager.TappedDown)
		{
			this.Y++;
			this.UpdateHighlightPosition();
		}
		if (Input.GetButtonDown("RB"))
		{
			this.Weekday++;
			if (this.Weekday > DayOfWeek.Friday)
			{
				this.Weekday = DayOfWeek.Monday;
			}
			this.UpdateIcons();
		}
		if (Input.GetButtonDown("LB"))
		{
			this.Weekday--;
			if (this.Weekday < DayOfWeek.Monday)
			{
				this.Weekday = DayOfWeek.Friday;
			}
			this.UpdateIcons();
		}
		if (Input.GetButtonDown("B"))
		{
			this.PauseScreen.PromptBar.ClearButtons();
			this.PauseScreen.PromptBar.Label[0].text = "Accept";
			this.PauseScreen.PromptBar.Label[1].text = "Exit";
			this.PauseScreen.PromptBar.Label[4].text = "Choose";
			this.PauseScreen.PromptBar.Label[5].text = "Choose";
			this.PauseScreen.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			base.gameObject.SetActive(false);
		}
		if (Input.GetButtonDown("X"))
		{
			this.PauseScreen.PromptBar.ClearButtons();
			this.PauseScreen.PromptBar.Label[0].text = "Accept";
			this.PauseScreen.PromptBar.Label[1].text = "Exit";
			this.PauseScreen.PromptBar.Label[4].text = "Choose";
			this.PauseScreen.PromptBar.UpdateButtons();
			this.PauseScreen.FavorMenu.SchemesMenu.UpdatePantyCount();
			this.PauseScreen.FavorMenu.SchemesMenu.UpdateSchemeList();
			this.PauseScreen.FavorMenu.SchemesMenu.UpdateSchemeInfo();
			this.PauseScreen.SchemesMenu.gameObject.SetActive(true);
			base.gameObject.SetActive(false);
		}
		if (Input.GetButtonDown("Y"))
		{
			this.PauseScreen.Hint.enabled = !this.PauseScreen.Hint.enabled;
			OptionGlobals.HintsOff = !OptionGlobals.HintsOff;
			this.PauseScreen.PromptBar.Label[3].text = (this.PauseScreen.Hint.enabled ? "Disable Hints" : "Enable Hints");
			this.PauseScreen.PromptBar.UpdateButtons();
			this.PauseScreen.Hint.gameObject.SetActive(this.PauseScreen.Hint.enabled);
		}
	}

	// Token: 0x06001C80 RID: 7296 RVA: 0x0014E604 File Offset: 0x0014C804
	private void UpdateHighlightPosition()
	{
		if (this.X > this.LimitX)
		{
			this.X = 1;
		}
		else if (this.X < 1)
		{
			this.X = this.LimitX;
		}
		if (this.Y > this.LimitY)
		{
			this.Y = 1;
		}
		else if (this.Y < 1)
		{
			this.Y = this.LimitY;
		}
		this.Index = this.X + (this.Y - 1) * 10;
		if (this.EventIcons[this.Index].activeInHierarchy)
		{
			this.Description.text = this.Descriptions[this.Index];
		}
		else
		{
			this.Description.text = "There are no events occuring between these two students at this time of day.";
		}
		this.Highlight.localPosition = new Vector3((float)(-440 + 80 * this.X), (float)(266 + -66 * this.Y), 0f);
	}

	// Token: 0x06001C81 RID: 7297 RVA: 0x0014E6F4 File Offset: 0x0014C8F4
	public void JumpToEvent(int ID)
	{
		this.Y = 1;
		this.X = ID;
		if (ID > 10)
		{
			this.Y = 2;
			this.X = ID - 10;
		}
		if (ID > 20)
		{
			this.Y = 3;
			this.X = ID - 20;
		}
		if (ID > 30)
		{
			this.Y = 4;
			this.X = ID - 30;
		}
		if (ID > 40)
		{
			this.Y = 5;
			this.X = ID - 40;
		}
		this.UpdateHighlightPosition();
	}

	// Token: 0x040032A4 RID: 12964
	public InputManagerScript InputManager;

	// Token: 0x040032A5 RID: 12965
	public PauseScreenScript PauseScreen;

	// Token: 0x040032A6 RID: 12966
	public VoidGoddessScript VoidGoddess;

	// Token: 0x040032A7 RID: 12967
	public GameObject[] EventIcons;

	// Token: 0x040032A8 RID: 12968
	public UITexture[] Portraits;

	// Token: 0x040032A9 RID: 12969
	public string[] Descriptions;

	// Token: 0x040032AA RID: 12970
	public Transform Highlight;

	// Token: 0x040032AB RID: 12971
	public UILabel Description;

	// Token: 0x040032AC RID: 12972
	public UILabel Header;

	// Token: 0x040032AD RID: 12973
	public DayOfWeek Weekday;

	// Token: 0x040032AE RID: 12974
	public int Index;

	// Token: 0x040032AF RID: 12975
	public int X = 1;

	// Token: 0x040032B0 RID: 12976
	public int Y = 1;

	// Token: 0x040032B1 RID: 12977
	public int LimitX = 1;

	// Token: 0x040032B2 RID: 12978
	public int LimitY = 1;

	// Token: 0x040032B3 RID: 12979
	public bool Initialized;
}
