using UnityEngine;

public class AnimTestScript : MonoBehaviour
{
	public SkinnedMeshRenderer ChainsawTeeth;

	public Animation CharacterA;

	public Animation CharacterB;

	public string[] AnimListA;

	public string[] AnimListB;

	public float[] Distance;

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
			if (ID == AnimListA.Length)
			{
				ID = 0;
			}
		}
		if (ID == 0)
		{
			CharacterA.Play(AnimListA[ID]);
			CharacterB.Play(AnimListB[ID]);
		}
		else if (ID == 1)
		{
			CharacterA.Play(AnimListA[ID]);
			CharacterB.Play(AnimListB[ID]);
		}
		else if (ID == 2)
		{
			CharacterA.Play(AnimListA[ID]);
			CharacterB.Play(AnimListB[ID]);
		}
		else if (ID == 3)
		{
			CharacterA.Play(AnimListA[ID]);
			CharacterB.Play(AnimListB[ID]);
		}
		CharacterB.transform.position = new Vector3(Distance[ID], 0f, 0f);
	}
}
