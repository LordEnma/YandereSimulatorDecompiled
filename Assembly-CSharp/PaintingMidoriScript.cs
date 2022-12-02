using UnityEngine;

public class PaintingMidoriScript : MonoBehaviour
{
	public Animation Anim;

	public float Rotation;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			ID++;
		}
		if (ID == 0)
		{
			Anim.CrossFade("f02_painting_00");
		}
		else if (ID == 1)
		{
			Anim.CrossFade("f02_shock_00");
			Rotation = Mathf.Lerp(Rotation, -180f, Time.deltaTime * 10f);
		}
		else if (ID == 2)
		{
			base.transform.position -= new Vector3(Time.deltaTime * 2f, 0f, 0f);
		}
		base.transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
	}
}
