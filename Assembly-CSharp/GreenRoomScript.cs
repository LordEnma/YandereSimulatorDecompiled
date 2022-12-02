using UnityEngine;

public class GreenRoomScript : MonoBehaviour
{
	public QualityManagerScript QualityManager;

	public Color[] Colors;

	public Renderer[] Renderers;

	public int ID;

	private void Start()
	{
		QualityManager.Obscurance.enabled = false;
		UpdateColor();
	}

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			UpdateColor();
		}
	}

	private void UpdateColor()
	{
		ID++;
		if (ID > 7)
		{
			ID = 0;
		}
		Renderers[0].material.color = Colors[ID];
		Renderers[1].material.color = Colors[ID];
	}
}
