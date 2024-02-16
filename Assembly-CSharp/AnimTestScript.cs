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
		}
		if (ID == 1)
		{
			CharacterB.transform.eulerAngles = new Vector3(0f, -90f, 0f);
			CharacterA.Play("f02_scytheHighSanityA_00");
			CharacterB.Play("f02_scytheHighSanityB_00");
		}
		else if (ID == 2)
		{
			CharacterA.Play("f02_scytheMedSanityA_00");
			CharacterB.Play("f02_scytheMedSanityB_00");
		}
		else if (ID == 3)
		{
			CharacterA.Play("f02_scytheLowSanityA_00");
			CharacterB.Play("f02_scytheLowSanityB_00");
		}
		else if (ID == 4)
		{
			CharacterB.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			CharacterA.Play("f02_scytheStealthA_00");
			CharacterB.Play("f02_scytheStealthB_00");
		}
	}
}
