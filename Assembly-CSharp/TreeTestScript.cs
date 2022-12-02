using UnityEngine;

public class TreeTestScript : MonoBehaviour
{
	public QualityManagerScript QualityManager;

	public StudentManagerScript StudentManager;

	public GameObject[] Petals;

	public GameObject[] Trees;

	public int Command;

	public int PetalID;

	public int TreeID;

	public int Is;

	public int Us;

	public int Ys;

	public GameObject MinimapCamera;

	public CameraFilterPack_Color_BrightContrastSaturation Contrast;

	public CameraFilterPack_Color_GrayScale Gray;

	public CameraFilterPack_Color_RGB RGB;

	private void Update()
	{
		if (Input.GetKeyDown("y"))
		{
			Ys++;
			if (Ys > 8)
			{
				if (Command == 0)
				{
					Command++;
					GameObject[] array = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
					foreach (GameObject gameObject in array)
					{
						if (gameObject.name == "BigTree" || gameObject.name == "SmallTree")
						{
							Trees[TreeID] = gameObject;
							TreeID++;
						}
					}
				}
				else if (Command == 1)
				{
					OptionGlobals.ParticleCount = 1;
					QualityManager.UpdateParticles();
					Command++;
					PetalID = 0;
					for (TreeID = 0; TreeID < Trees.Length; TreeID++)
					{
						if (Trees[TreeID] != null)
						{
							Trees[TreeID].SetActive(false);
						}
					}
					while (PetalID < Petals.Length)
					{
						Petals[PetalID].SetActive(false);
						PetalID++;
					}
				}
				else if (Command == 2)
				{
					OptionGlobals.ParticleCount = 3;
					QualityManager.UpdateParticles();
					Command--;
					PetalID = 0;
					for (TreeID = 0; TreeID < Trees.Length; TreeID++)
					{
						if (Trees[TreeID] != null)
						{
							Trees[TreeID].SetActive(true);
						}
					}
					while (PetalID < Petals.Length)
					{
						Petals[PetalID].SetActive(true);
						PetalID++;
					}
				}
			}
		}
		if (!Input.GetKeyDown("i"))
		{
			return;
		}
		Is++;
		if (Is == 10)
		{
			StudentManager.MiniMapTest();
		}
		else if (Is == 11)
		{
			if (Gray == null)
			{
				Gray = MinimapCamera.AddComponent<CameraFilterPack_Color_GrayScale>();
				RGB = MinimapCamera.AddComponent<CameraFilterPack_Color_RGB>();
				Contrast = MinimapCamera.AddComponent<CameraFilterPack_Color_BrightContrastSaturation>();
				RGB.ColorRGB = new Color(1f, 0.75f, 1f, 1f);
				Contrast.Brightness = 2f;
				Contrast.Saturation = 1f;
				Contrast.Contrast = 0.5f;
			}
			else
			{
				Gray.enabled = true;
				RGB.enabled = true;
				Contrast.enabled = true;
			}
		}
		else if (Is == 12)
		{
			StudentManager.MiniMap.SetActive(false);
			Gray.enabled = false;
			RGB.enabled = false;
			Contrast.enabled = false;
			Is = 9;
		}
	}
}
