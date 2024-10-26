using UnityEngine;

public class SkyBoxRotation : MonoBehaviour
{
	public int rotateAmountX;

	public int rotateAmountY;

	public int rotateAmountZ;

	public float orgX;

	public float orgY;

	public float orgZ;

	public float RotSpeedFactor;

	private void Start()
	{
		_ = base.transform.rotation.eulerAngles;
	}

	private void Update()
	{
		base.transform.Rotate(rotateAmountX, rotateAmountY, (float)rotateAmountZ * Time.deltaTime * RotSpeedFactor);
		orgX = base.transform.rotation.x;
		orgY = base.transform.rotation.y;
		orgZ = base.transform.rotation.z;
		if (orgX >= 360f)
		{
			base.transform.Rotate(0f, orgY, orgZ);
		}
		if (orgY >= 360f)
		{
			base.transform.Rotate(orgX, 0f, orgZ);
		}
		if (orgZ >= 360f)
		{
			base.transform.Rotate(orgX, orgZ, 0f);
		}
	}
}
