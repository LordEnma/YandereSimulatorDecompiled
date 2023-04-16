using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleExtrasScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public Transform Arrow;

	public UISprite[] MenuList;

	public UITexture[] VideoThumbnailTextures;

	public UISprite[] VideoContainers;

	public UILabel[] VideoTitleLabels;

	public UISprite[] VideoBGs;

	public string[] PromoTitles;

	public string[] HumorTitles;

	public string[] ParodyTitles;

	public string[] LoreTitles;

	public Texture[] PromoThumbnails;

	public Texture[] HumorThumbnails;

	public Texture[] ParodyThumbnails;

	public Texture[] LoreThumbnails;

	public string[] PromoURLs;

	public string[] HumorURLs;

	public string[] ParodyURLs;

	public string[] LoreURLs;

	public bool FadeOut;

	public bool FadeIn;

	public bool Show;

	public float Height;

	public int Selected;

	public int NextMenu;

	public int Video;

	public int Menu;

	public int Column;

	public int Row;

	private void Start()
	{
		MenuList[0].alpha = 1f;
		MenuList[1].alpha = 0f;
		MenuList[2].alpha = 0f;
		MenuList[3].alpha = 0f;
		MenuList[4].alpha = 0f;
		MenuList[5].alpha = 0f;
	}

	private void Update()
	{
		if (Show)
		{
			if (FadeOut)
			{
				MenuList[Menu].alpha = Mathf.MoveTowards(MenuList[Menu].alpha, 0f, Time.deltaTime * 2f);
				if (MenuList[Menu].alpha == 0f)
				{
					FadeOut = false;
					FadeIn = true;
					if (NextMenu > 0 && NextMenu < 5)
					{
						Row = 1;
						Video = 1;
						Column = 1;
						PinkAllVideoBGs();
						UpdateThumbnails();
					}
				}
			}
			else if (FadeIn)
			{
				MenuList[NextMenu].alpha = Mathf.MoveTowards(MenuList[NextMenu].alpha, 1f, Time.deltaTime * 2f);
				if (MenuList[NextMenu].alpha == 1f)
				{
					FadeIn = false;
					Menu = NextMenu;
					if (Menu == 5)
					{
						PromptBar.ClearButtons();
						PromptBar.Label[1].text = "Back";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
					}
					else
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Make Selection";
						PromptBar.Label[1].text = "Back";
						PromptBar.Label[4].text = "Change Selection";
						PromptBar.Label[5].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
					}
				}
			}
			else if (Menu == 0)
			{
				if (InputManager.TappedDown)
				{
					Selected++;
					if (Selected > 5)
					{
						Selected = 1;
					}
				}
				if (InputManager.TappedUp)
				{
					Selected--;
					if (Selected < 1)
					{
						Selected = 5;
					}
				}
				if (Input.GetButtonDown("A"))
				{
					NextMenu = Selected;
					FadeOut = true;
					PromptBar.ClearButtons();
					PromptBar.UpdateButtons();
					PromptBar.Show = false;
				}
				if (Input.GetButtonDown("B"))
				{
					Show = false;
					PromptBar.Show = false;
					NewTitleScreen.Speed = 0f;
					NewTitleScreen.Phase = 2;
				}
				Height = 192 - 64 * Selected;
			}
			else if (Menu == 5)
			{
				if (Input.GetKeyDown(KeyCode.P))
				{
					Screen.SetResolution(512, 512, fullscreen: false);
					SceneManager.LoadScene("PortraitScene");
				}
				if (Input.GetButtonDown("B"))
				{
					ReturnToMain();
				}
			}
			else
			{
				if (InputManager.TappedDown)
				{
					Row++;
					if (Row > 3)
					{
						Row = 1;
					}
				}
				if (InputManager.TappedUp)
				{
					Row--;
					if (Row < 1)
					{
						Row = 3;
					}
				}
				if (InputManager.TappedRight)
				{
					Column++;
					if (Column > 4)
					{
						Column = 1;
					}
				}
				if (InputManager.TappedLeft)
				{
					Column--;
					if (Column < 1)
					{
						Column = 4;
					}
				}
				Video = (Row - 1) * 4 + Column;
				PinkAllVideoBGs();
				VideoBGs[Video].color = Color.white;
				for (int i = 1; i < 13; i++)
				{
					if (VideoTitleLabels[i].text == "")
					{
						VideoContainers[i].alpha = 0.5f;
					}
					else
					{
						VideoContainers[i].alpha = 1f;
					}
				}
				if (Input.GetButtonDown("A"))
				{
					if (Menu == 1)
					{
						Application.OpenURL(PromoURLs[Video]);
					}
					else if (Menu == 2)
					{
						Application.OpenURL(HumorURLs[Video]);
					}
					else if (Menu == 3)
					{
						Application.OpenURL(ParodyURLs[Video]);
					}
					else if (Menu == 4)
					{
						Application.OpenURL(LoreURLs[Video]);
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					ReturnToMain();
				}
			}
		}
		Arrow.transform.localPosition = Vector3.Lerp(Arrow.transform.localPosition, new Vector3(-100f, Height, 0f), Time.deltaTime * 10f);
	}

	public void UpdateThumbnails()
	{
		for (int i = 1; i < 13; i++)
		{
			if (NextMenu == 1)
			{
				VideoThumbnailTextures[i].mainTexture = PromoThumbnails[i];
				VideoTitleLabels[i].text = PromoTitles[i];
			}
			else if (NextMenu == 2)
			{
				VideoThumbnailTextures[i].mainTexture = HumorThumbnails[i];
				VideoTitleLabels[i].text = HumorTitles[i];
			}
			else if (NextMenu == 3)
			{
				VideoThumbnailTextures[i].mainTexture = ParodyThumbnails[i];
				VideoTitleLabels[i].text = ParodyTitles[i];
			}
			else if (NextMenu == 4)
			{
				VideoThumbnailTextures[i].mainTexture = LoreThumbnails[i];
				VideoTitleLabels[i].text = LoreTitles[i];
			}
			if (VideoTitleLabels[i].text == "")
			{
				VideoContainers[i].alpha = 0.5f;
			}
			else
			{
				VideoContainers[i].alpha = 1f;
			}
		}
	}

	public void PinkAllVideoBGs()
	{
		for (int i = 1; i < 13; i++)
		{
			VideoBGs[i].color = new Color(1f, 0.75f, 1f, 1f);
		}
	}

	public void ReturnToMain()
	{
		NextMenu = 0;
		FadeOut = true;
		PromptBar.ClearButtons();
		PromptBar.UpdateButtons();
		PromptBar.Show = false;
	}
}
