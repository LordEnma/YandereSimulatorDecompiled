using UnityEngine;

public class ConstantRandomRotation : MonoBehaviour
{
	private void Update()
	{
		int num = Random.Range(0, 360);
		int num2 = Random.Range(0, 360);
		int num3 = Random.Range(0, 360);
		base.transform.Rotate(num, num2, num3);
	}
}
