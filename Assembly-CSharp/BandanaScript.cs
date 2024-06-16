using UnityEngine;

public class BandanaScript : MonoBehaviour
{
	public MeshRenderer MyRenderer;

	public GameObject OldHair;

	public string[] Letters;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown(Letters[ID]))
		{
			ID++;
			if (ID == Letters.Length)
			{
				MyRenderer.enabled = false;
				OldHair.SetActive(value: true);
				base.enabled = false;
			}
		}
	}
}
