using UnityEngine;

public class PromoCameraScript : MonoBehaviour
{
	public PortraitChanScript PromoCharacter;

	public Vector3[] StartPositions;

	public Vector3[] StartRotations;

	public Renderer PromoBlack;

	public Renderer Noose;

	public Renderer Rope;

	public Camera MyCamera;

	public Transform Drills;

	public float Timer;

	public int ID;

	private void Start()
	{
		base.transform.eulerAngles = StartRotations[ID];
		base.transform.position = StartPositions[ID];
		PromoCharacter.gameObject.SetActive(value: false);
		PromoBlack.material.color = new Color(PromoBlack.material.color.r, PromoBlack.material.color.g, PromoBlack.material.color.b, 0f);
		Noose.material.color = new Color(Noose.material.color.r, Noose.material.color.g, Noose.material.color.b, 0f);
		Rope.material.color = new Color(Rope.material.color.r, Rope.material.color.g, Rope.material.color.b, 0f);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && ID < 3)
		{
			ID++;
			UpdatePosition();
		}
		if (ID == 0)
		{
			base.transform.Translate(Vector3.back * (Time.deltaTime * 0.01f));
		}
		else if (ID == 1)
		{
			base.transform.Translate(Vector3.back * (Time.deltaTime * 0.01f));
		}
		else if (ID == 2)
		{
			base.transform.Translate(Vector3.forward * (Time.deltaTime * 0.01f));
			PromoCharacter.gameObject.SetActive(value: true);
		}
		else if (ID == 1 || ID == 3)
		{
			base.transform.Translate(Vector3.back * (Time.deltaTime * 0.1f));
		}
		Timer += Time.deltaTime;
		if (Timer > 20f)
		{
			Noose.material.color = new Color(Noose.material.color.r, Noose.material.color.g, Noose.material.color.b, Noose.material.color.a + Time.deltaTime * 0.2f);
			Rope.material.color = new Color(Rope.material.color.r, Rope.material.color.g, Rope.material.color.b, Rope.material.color.a + Time.deltaTime * 0.2f);
		}
		else if (Timer > 15f)
		{
			PromoBlack.material.color = new Color(PromoBlack.material.color.r, PromoBlack.material.color.g, PromoBlack.material.color.b, PromoBlack.material.color.a + Time.deltaTime * 0.2f);
		}
		if (Timer > 10f)
		{
			Drills.LookAt(Drills.position - Vector3.right);
			if (ID == 2)
			{
				ID = 3;
				UpdatePosition();
			}
		}
		else if (Timer > 5f)
		{
			PromoCharacter.EyeShrink += Time.deltaTime * 0.1f;
			if (ID == 1)
			{
				ID = 2;
				UpdatePosition();
			}
		}
	}

	private void UpdatePosition()
	{
		base.transform.position = StartPositions[ID];
		base.transform.eulerAngles = StartRotations[ID];
		if (ID == 2)
		{
			MyCamera.farClipPlane = 3f;
			Timer = 5f;
		}
		if (ID == 3)
		{
			MyCamera.farClipPlane = 5f;
			Timer = 10f;
		}
	}
}
