using System;
using UnityEngine;

public class ScheduleScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public VoidGoddessScript VoidGoddess;

	public GameObject[] EventIcons;

	public UITexture[] Portraits;

	public string[] Descriptions;

	public Transform Highlight;

	public UILabel Description;

	public UILabel Header;

	public DayOfWeek Weekday;

	public int Index;

	public int X = 1;

	public int Y = 1;

	public int LimitX = 1;

	public int LimitY = 1;

	public bool Initialized;

	public void Start()
	{
		if (!Initialized)
		{
			if (VoidGoddess != null)
			{
				VoidGoddess.Start();
				Portraits[1].mainTexture = VoidGoddess.Portraits[11].mainTexture;
				Portraits[2].mainTexture = VoidGoddess.Portraits[1].mainTexture;
				Portraits[3].mainTexture = VoidGoddess.Portraits[11].mainTexture;
				Portraits[4].mainTexture = VoidGoddess.Portraits[10].mainTexture;
				Portraits[5].mainTexture = VoidGoddess.Portraits[11].mainTexture;
				Portraits[6].mainTexture = VoidGoddess.Portraits[81].mainTexture;
				Portraits[7].mainTexture = VoidGoddess.Portraits[2].mainTexture;
				Portraits[8].mainTexture = VoidGoddess.Portraits[3].mainTexture;
				Portraits[9].mainTexture = VoidGoddess.Portraits[62].mainTexture;
				Portraits[10].mainTexture = VoidGoddess.Portraits[63].mainTexture;
			}
			Initialized = true;
		}
		Weekday = DateGlobals.Weekday;
		UpdateIcons();
	}

	private void UpdateIcons()
	{
		Header.text = Weekday.ToString() + " Schedule";
		for (int i = 1; i < EventIcons.Length; i++)
		{
			EventIcons[i].SetActive(false);
		}
		EventIcons[1].SetActive(true);
		Descriptions[1] = "Every morning, Osana and Senpai will have a conversation. By eavesdropping on this conversation, you can learn about an interaction that Osana and Senpai will have later in the day.";
		if (Weekday == DayOfWeek.Monday)
		{
			EventIcons[7].SetActive(true);
			Descriptions[7] = "At lunchtime, Osana will give Senpai a bento. By sabotaging the bento, you can make Senpai dislike Osana.";
		}
		if (Weekday == DayOfWeek.Friday)
		{
			EventIcons[7].SetActive(true);
			Descriptions[7] = "At lunchtime, Osana will share her favorite music with Senpai. By replacing her music tracks with audio that sounds bad out-of-context, you can make Senpai dislike Osana.";
		}
		if (Weekday == DayOfWeek.Tuesday)
		{
			EventIcons[10].SetActive(true);
			Descriptions[10] = "Osana is going to meet up with Senpai and return the book that she borrowed.";
		}
		if (Weekday == DayOfWeek.Wednesday)
		{
			EventIcons[10].SetActive(true);
			Descriptions[10] = "Osana is going to meet up with Senpai and show him a photo she took earlier in the day.";
		}
		if (Weekday == DayOfWeek.Thursday)
		{
			EventIcons[10].SetActive(true);
			Descriptions[10] = "Osana is going to meet up with Senpai and go on a date with him.";
		}
		if (Weekday == DayOfWeek.Friday)
		{
			EventIcons[10].SetActive(true);
			Descriptions[10] = "Osana is going to put a note in Senpai's locker and tell him to meet her under the cherry tree behind the school. Under the cherry tree, Osana is going to confess her love to Senpai.";
		}
		EventIcons[12].SetActive(true);
		Descriptions[12] = "Every morning, Osana and Raibaru will have a conversation. By eavesdropping on this conversation, you can learn a clue about how to sabotage an interaction that Osana and Senpai will have later in the day.";
		if (Weekday == DayOfWeek.Monday)
		{
			EventIcons[13].SetActive(true);
			Descriptions[13] = "Osana is going to put two bento boxes on her desk. One bento is for her; the other bento is for Senpai. You can put emetic poison into Senpai's bento to make him puke and damage his relationship with Osana. You can also put lethal poison into Osana's bento to kill her, or put emetic poison into her bento to put her into a vulnerable position.";
			EventIcons[14].SetActive(true);
			Descriptions[14] = "Raibaru is going to ask Osana to talk about what kind of boys she likes. By eavesdropping on this conversation, you can learn the information you'd need in order to make another boy become appealing to Osana.";
			EventIcons[15].SetActive(true);
			Descriptions[15] = "Osana is going to recieve a distressing phone call. By eavesdropping on this call, you can learn some of the information you'd need in order to put Osana into your debt.";
			EventIcons[16].SetActive(true);
			Descriptions[16] = "Osana and Raibaru are going to tour the school and visit each of the clubrooms. By eavesdropping on their conversations, you can learn about Osana's likes and dislikes.";
			EventIcons[18].SetActive(true);
			Descriptions[18] = "Osana and Raibaru are going to have a private discussion on the school rooftop, behind the air vents. By eavesdropping on their conversations, you can learn some of the information you'd need in order to put Osana into your debt.";
		}
		else if (Weekday == DayOfWeek.Tuesday)
		{
			EventIcons[17].SetActive(true);
			Descriptions[17] = "Osana is going to read the book she borrowed from Senpai. When she leaves the book unattended, you will have an opportunity to damage the book.";
		}
		else if (Weekday == DayOfWeek.Wednesday)
		{
			EventIcons[17].SetActive(true);
			Descriptions[17] = "Osana is going to take a photo of a pretty location somewhere in school.";
		}
		else if (Weekday == DayOfWeek.Thursday)
		{
			EventIcons[13].SetActive(true);
			Descriptions[13] = "Osana is going to talk with Raibaru about how hungry she is. This is an indication that this is the one time that Osana is willing to accept food from a stranger.";
			EventIcons[17].SetActive(true);
			Descriptions[17] = "Osana is going to sunbathe at the school pool.";
			EventIcons[19].SetActive(true);
			Descriptions[19] = "Osana is going to take a nap on the school rooftop. If you sabotage her phone alarm, you can make her late for her date with Senpai.";
		}
		else if (Weekday == DayOfWeek.Friday)
		{
			EventIcons[15].SetActive(true);
			Descriptions[15] = "Osana is going to create a playlist of songs for Senpai to listen to.";
		}
		if (Weekday == DayOfWeek.Friday)
		{
			EventIcons[24].SetActive(true);
			Descriptions[24] = "Musume is going to have a private conversation with Osana. If you record this conversation, you can edit the recording to make an audio file that sounds bad when it's heard out-of-context.";
		}
		EventIcons[31].SetActive(true);
		Descriptions[31] = "Sakyu and Inkyu are going to sit down on a bench and have a conversation about the school.";
		EventIcons[47].SetActive(true);
		Descriptions[47] = "Before eating lunch, Horo and Yaku are going to have a conversation about a popular anime show called ''Magical Girl Pretty Miyuki''.";
		if (Weekday == DayOfWeek.Monday)
		{
			EventIcons[49].SetActive(true);
			Descriptions[49] = "After performing their cleaning duties, Horo and Yaku are going to have a conversation about a recent conspiracy theory revolving around a video game called ''Yanvania: Senpai of the Night''.";
		}
	}

	private void Update()
	{
		PauseScreen.Sideways = true;
		if (InputManager.TappedRight)
		{
			X++;
			UpdateHighlightPosition();
		}
		else if (InputManager.TappedLeft)
		{
			X--;
			UpdateHighlightPosition();
		}
		if (InputManager.TappedUp)
		{
			Y--;
			UpdateHighlightPosition();
		}
		else if (InputManager.TappedDown)
		{
			Y++;
			UpdateHighlightPosition();
		}
		if (Input.GetButtonDown("RB"))
		{
			Weekday++;
			if (Weekday > DayOfWeek.Friday)
			{
				Weekday = DayOfWeek.Monday;
			}
			UpdateIcons();
		}
		if (Input.GetButtonDown("LB"))
		{
			Weekday--;
			if (Weekday < DayOfWeek.Monday)
			{
				Weekday = DayOfWeek.Friday;
			}
			UpdateIcons();
		}
		if (Input.GetButtonDown("B"))
		{
			PauseScreen.PromptBar.ClearButtons();
			PauseScreen.PromptBar.Label[0].text = "Accept";
			PauseScreen.PromptBar.Label[1].text = "Exit";
			PauseScreen.PromptBar.Label[4].text = "Choose";
			PauseScreen.PromptBar.Label[5].text = "Choose";
			PauseScreen.PromptBar.UpdateButtons();
			PauseScreen.MainMenu.SetActive(true);
			PauseScreen.Sideways = false;
			base.gameObject.SetActive(false);
		}
		if (Input.GetButtonDown("X"))
		{
			PauseScreen.PromptBar.ClearButtons();
			PauseScreen.PromptBar.Label[0].text = "Accept";
			PauseScreen.PromptBar.Label[1].text = "Exit";
			PauseScreen.PromptBar.Label[4].text = "Choose";
			PauseScreen.PromptBar.UpdateButtons();
			PauseScreen.FavorMenu.SchemesMenu.UpdatePantyCount();
			PauseScreen.FavorMenu.SchemesMenu.UpdateSchemeList();
			PauseScreen.FavorMenu.SchemesMenu.UpdateSchemeInfo();
			PauseScreen.SchemesMenu.gameObject.SetActive(true);
			base.gameObject.SetActive(false);
		}
		if (Input.GetButtonDown("Y"))
		{
			PauseScreen.Hint.enabled = !PauseScreen.Hint.enabled;
			OptionGlobals.HintsOff = !OptionGlobals.HintsOff;
			PauseScreen.PromptBar.Label[3].text = (PauseScreen.Hint.enabled ? "Disable Hints" : "Enable Hints");
			PauseScreen.PromptBar.UpdateButtons();
			PauseScreen.Hint.gameObject.SetActive(PauseScreen.Hint.enabled);
		}
	}

	private void UpdateHighlightPosition()
	{
		if (X > LimitX)
		{
			X = 1;
		}
		else if (X < 1)
		{
			X = LimitX;
		}
		if (Y > LimitY)
		{
			Y = 1;
		}
		else if (Y < 1)
		{
			Y = LimitY;
		}
		Index = X + (Y - 1) * 10;
		if (EventIcons[Index].activeInHierarchy)
		{
			Description.text = Descriptions[Index];
		}
		else
		{
			Description.text = "There are no events occuring between these two students at this time of day.";
		}
		Highlight.localPosition = new Vector3(-440 + 80 * X, 266 + -66 * Y, 0f);
	}

	public void JumpToEvent(int ID)
	{
		Y = 1;
		X = ID;
		if (ID > 10)
		{
			Y = 2;
			X = ID - 10;
		}
		if (ID > 20)
		{
			Y = 3;
			X = ID - 20;
		}
		if (ID > 30)
		{
			Y = 4;
			X = ID - 30;
		}
		if (ID > 40)
		{
			Y = 5;
			X = ID - 40;
		}
		UpdateHighlightPosition();
	}
}
