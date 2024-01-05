using UnityEngine;

public class FloatingWindowScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Transform MostRecentStudent;

	public Transform Parent;

	public UISprite Sprite;

	public UILabel NameLabel;

	public UILabel DescLabel;

	public Vector3 Offset;

	public string[] Sins;

	private void Update()
	{
		if (Yandere.YandereVision)
		{
			float num = 0f;
			StudentScript studentScript = null;
			for (int i = 1; i < 101; i++)
			{
				StudentScript studentScript2 = Yandere.StudentManager.Students[i];
				if (studentScript2 != null && studentScript2.Alive)
				{
					float num2 = Vector3.Distance(studentScript2.transform.position, Yandere.transform.position);
					if ((studentScript == null && num2 < 5f) || num2 < num)
					{
						num = num2;
						MostRecentStudent = studentScript2.transform;
						Parent = studentScript2.Head;
						studentScript = studentScript2;
						Debug.Log("FloatingWindow's Student is now: " + studentScript.Name);
						NameLabel.text = studentScript2.Name;
						DescLabel.text = Sins[i];
					}
				}
			}
		}
		if (Parent != null)
		{
			if (Vector3.Angle(Yandere.MainCamera.transform.forward, Yandere.MainCamera.transform.position - Parent.position) > 90f)
			{
				Vector2 zero = Vector2.zero;
				zero = Yandere.MainCamera.WorldToScreenPoint(Parent.position + Vector3.up * 0.05f);
				base.transform.position = Vector3.Lerp(base.transform.position, Yandere.UICamera.ScreenToWorldPoint(new Vector3(zero.x, zero.y, 1f) + new Vector3(Offset.x, Offset.y, Offset.z)), Time.deltaTime * 10f);
				if (!Yandere.YandereVision)
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
					Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 0f, Time.deltaTime);
				}
				else if (Vector3.Distance(MostRecentStudent.position, Yandere.transform.position) > 5f)
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
					Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 0f, Time.deltaTime);
				}
				else
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.one, Time.deltaTime * 10f);
					Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 1f, Time.deltaTime);
				}
			}
			else
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
				Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 0f, Time.deltaTime);
			}
		}
		else
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 0f, Time.deltaTime);
		}
		if (Sprite.alpha == 0f)
		{
			Parent = null;
		}
	}
}
