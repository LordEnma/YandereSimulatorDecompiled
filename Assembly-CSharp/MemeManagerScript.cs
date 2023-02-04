using UnityEngine;

public class MemeManagerScript : MonoBehaviour
{
	[SerializeField]
	private GameObject[] Memes;

	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			GameObject[] memes = Memes;
			for (int i = 0; i < memes.Length; i++)
			{
				memes[i].SetActive(value: false);
			}
		}
	}
}
