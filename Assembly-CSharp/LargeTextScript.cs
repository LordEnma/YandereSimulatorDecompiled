using UnityEngine;

public class LargeTextScript : MonoBehaviour
{
	public UILabel Label;

	public string[] String;

	public int ID;

	private void Start()
	{
		Label.text = String[ID];
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			ID++;
			Label.text = String[ID];
		}
	}
}
