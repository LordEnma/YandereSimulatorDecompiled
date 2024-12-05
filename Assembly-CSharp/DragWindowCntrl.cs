using UnityEngine;

public class DragWindowCntrl : MonoBehaviour
{
	private RectTransform window;

	private Vector2 delta;

	private void Awake()
	{
		window = (RectTransform)base.transform;
	}

	public void BeginDrag()
	{
		delta = Input.mousePosition - window.position;
	}

	public void Drag()
	{
		Vector2 vector = (Vector2)Input.mousePosition - delta;
		Vector2 vector2 = new Vector2(window.rect.width * base.transform.root.lossyScale.x, window.rect.height * base.transform.root.lossyScale.y);
		Vector2 vector3 = default(Vector2);
		vector3.x = vector.x - window.pivot.x * vector2.x;
		vector3.y = vector.y - window.pivot.y * vector2.y;
		Vector2 vector4 = default(Vector2);
		vector4.x = vector.x + (1f - window.pivot.x) * vector2.x;
		vector4.y = vector.y + (1f - window.pivot.y) * vector2.y;
		if (vector3.x < 0f)
		{
			vector.x = window.pivot.x * vector2.x;
		}
		else if (vector4.x > (float)Screen.width)
		{
			vector.x = (float)Screen.width - (1f - window.pivot.x) * vector2.x;
		}
		if (vector3.y < 0f)
		{
			vector.y = window.pivot.y * vector2.y;
		}
		else if (vector4.y > (float)Screen.height)
		{
			vector.y = (float)Screen.height - (1f - window.pivot.y) * vector2.y;
		}
		window.position = vector;
	}
}
