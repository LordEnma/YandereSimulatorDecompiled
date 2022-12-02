using UnityEngine;

public class FoldingChairScript : MonoBehaviour
{
	public GameObject[] Student;

	private void Start()
	{
		int num = Random.Range(0, Student.Length);
		Object.Instantiate(Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}
}
