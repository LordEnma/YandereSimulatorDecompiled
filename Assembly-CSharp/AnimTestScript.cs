using UnityEngine;

public class AnimTestScript : MonoBehaviour
{
	public Animation CharacterA;

	public Animation CharacterB;

	public int ID;

	private void Start()
	{
		Time.timeScale = 1f;
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			ID++;
			if (ID > 4)
			{
				ID = 1;
			}
			CharacterA["f02_katanaMedSanityA_00"].time = 0f;
			CharacterB["f02_katanaMedSanityB_00"].time = 0f;
			CharacterA.Play("f02_katanaMedSanityA_00");
			CharacterB.Play("f02_katanaMedSanityB_00");
		}
	}
}
