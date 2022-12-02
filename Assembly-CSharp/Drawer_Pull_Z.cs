using System.Collections;
using UnityEngine;

public class Drawer_Pull_Z : MonoBehaviour
{
	public Animator pull;

	public bool open;

	public Transform Player;

	private void Start()
	{
		open = false;
	}

	private void OnMouseOver()
	{
		if (!Player || !(Vector3.Distance(Player.position, base.transform.position) < 10f))
		{
			return;
		}
		MonoBehaviour.print("object name");
		if (!open)
		{
			if (Input.GetMouseButtonDown(0))
			{
				StartCoroutine(opening());
			}
		}
		else if (open && Input.GetMouseButtonDown(0))
		{
			StartCoroutine(closing());
		}
	}

	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		pull.Play("openpull");
		open = true;
		yield return new WaitForSeconds(0.5f);
	}

	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		pull.Play("closepush");
		open = false;
		yield return new WaitForSeconds(0.5f);
	}
}
