using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortraitSceneManagerScript : MonoBehaviour
{
	public CameraFilterPack_Colors_Adjust_PreFilters BlueFilter;

	public UITexture Background;

	public GameObject Petals;

	public GameObject Tree;

	public int[] Heights;

	public int[] Widths;

	public int X;

	public int Y;

	private void Start()
	{
		X = Screen.currentResolution.width;
		Y = Screen.currentResolution.height;
		if (GameGlobals.Eighties)
		{
			BlueFilter.enabled = true;
			Petals.SetActive(value: false);
			Tree.SetActive(value: false);
			if (GameGlobals.CustomMode)
			{
				StartCoroutine(GrabCustomTexturesAsync());
			}
		}
		else
		{
			BlueFilter.enabled = false;
			Petals.SetActive(value: true);
			Tree.SetActive(value: true);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Screen.SetResolution(Widths[OptionGlobals.ResolutionID], Heights[OptionGlobals.ResolutionID], OptionGlobals.WindowedMode);
			SceneManager.LoadScene("NewTitleScene");
		}
	}

	public IEnumerator GrabCustomTexturesAsync()
	{
		WWW NewTexture = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/PortraitBG.png");
		yield return NewTexture;
		if (NewTexture.error == null)
		{
			Background.mainTexture = NewTexture.texture;
		}
		if (NewTexture.error != null)
		{
			Debug.Log("Well, the texture wasn't null!");
		}
	}
}
