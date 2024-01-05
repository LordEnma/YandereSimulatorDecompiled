using UnityEngine;
using UnityEngine.SceneManagement;

public class PortraitSceneManagerScript : MonoBehaviour
{
	public CameraFilterPack_Colors_Adjust_PreFilters BlueFilter;

	public GameObject Petals;

	public GameObject Tree;

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
			Screen.SetResolution(X, Y, FullScreenMode.Windowed);
			SceneManager.LoadScene("NewTitleScene");
		}
	}
}
