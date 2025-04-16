using UnityEngine;

public class AnimTestScript : MonoBehaviour
{
	public SkinnedMeshRenderer ChainsawTeeth;

	public Animation CharacterA;

	public Animation CharacterB;

	public int ID;

	private void Start()
	{
		Time.timeScale = 1f;
	}

	private void Update()
	{
		ChainsawTeeth.SetBlendShapeWeight(0, Random.Range(0, 101));
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
			CharacterB.transform.position = new Vector3(0.5f, 0f, 0f);
			CharacterB.transform.eulerAngles = new Vector3(0f, -90f, 0f);
			CharacterA.Play("f02_chainsawHighSanityA_00");
			CharacterB.Play("f02_chainsawHighSanityB_00");
		}
		else if (ID == 2)
		{
			CharacterA.Play("f02_chainsawMedSanityA_00");
			CharacterB.Play("f02_chainsawMedSanityB_00");
		}
		else if (ID == 3)
		{
			CharacterA.Play("f02_chainsawLowSanityA_00");
			CharacterB.Play("f02_chainsawLowSanityB_00");
		}
		else if (ID == 4)
		{
			CharacterB.transform.position = new Vector3(0.25f, 0f, 0f);
			CharacterB.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			CharacterA.Play("f02_chainsawStealthA_00");
			CharacterB.Play("f02_chainsawStealthB_00");
		}
	}
}
