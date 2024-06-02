using UnityEngine;

public class MemeManagerScript : MonoBehaviour
{
	[SerializeField]
	private GameObject[] Memes;

	private void Start()
	{
		if (!GameGlobals.LoveSick)
		{
			return;
		}
		GameObject[] memes = Memes;
		foreach (GameObject gameObject in memes)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
	}
}
