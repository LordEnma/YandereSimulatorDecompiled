using UnityEngine;

public class OsanaMatrixScript : MonoBehaviour
{
	public CameraFilterPack_3D_Matrix MatrixEffect;

	public GameObject Rivals;

	public int Phase = 1;

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			Phase++;
		}
		if (Phase == 2)
		{
			MatrixEffect.Fade = Mathf.MoveTowards(MatrixEffect.Fade, 1f, Time.deltaTime);
		}
		else if (Phase == 3)
		{
			MatrixEffect.Fade = Mathf.MoveTowards(MatrixEffect.Fade, 0f, Time.deltaTime);
		}
		else if (Phase == 4)
		{
			Rivals.SetActive(value: true);
		}
	}
}
