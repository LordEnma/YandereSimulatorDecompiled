using UnityEngine;

public class UniqueHeightAssigner : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public StudentScript[] objects;

	public float[] possibleHeights;

	private void Start()
	{
		if (objects.Length != 101)
		{
			Debug.LogError("The array must contain exactly 101 objects.");
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("x"))
		{
			objects = StudentManager.Students;
			AssignUniqueHeights(objects);
		}
	}

	private void AssignUniqueHeights(StudentScript[] StudentScript)
	{
		possibleHeights = new float[101];
		for (int i = 1; i < 101; i++)
		{
			possibleHeights[i] = 0.9f + (float)i * 0.002f;
		}
		Shuffle(possibleHeights);
		for (int j = 1; j < objects.Length; j++)
		{
			if (objects[j] != null)
			{
				objects[j].transform.localScale = new Vector3(possibleHeights[j], possibleHeights[j], possibleHeights[j]);
			}
		}
	}

	private void Shuffle(float[] array)
	{
		for (int num = array.Length - 1; num > 1; num--)
		{
			int num2 = Random.Range(1, num + 1);
			float num3 = array[num];
			array[num] = array[num2];
			array[num2] = num3;
		}
	}
}
