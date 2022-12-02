using UnityEngine;

public class StopAnimationScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Transform Yandere;

	private Animation Anim;

	private void Start()
	{
		StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		Anim = GetComponent<Animation>();
	}

	private void Update()
	{
		if (StudentManager.DisableFarAnims)
		{
			if (Vector3.Distance(Yandere.position, base.transform.position) > 15f)
			{
				if (Anim.enabled)
				{
					Anim.enabled = false;
				}
			}
			else if (!Anim.enabled)
			{
				Anim.enabled = true;
			}
		}
		else if (!Anim.enabled)
		{
			Anim.enabled = true;
		}
	}
}
