using UnityEngine;
using UnityEngine.UI;

public class AlphaButtonClickMask : MonoBehaviour, ICanvasRaycastFilter
{
	protected Image _image;

	public void Start()
	{
		_image = GetComponent<Image>();
		Texture2D texture = _image.sprite.texture;
		bool flag = false;
		if (texture != null)
		{
			try
			{
				texture.GetPixels32();
			}
			catch (UnityException ex)
			{
				Debug.LogError(ex.Message);
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			Debug.LogError("This script need an Image with a readbale Texture2D to work.");
		}
	}

	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_image.rectTransform, sp, eventCamera, out var localPoint);
		Vector2 pivot = _image.rectTransform.pivot;
		Vector2 vector = new Vector2(pivot.x + localPoint.x / _image.rectTransform.rect.width, pivot.y + localPoint.y / _image.rectTransform.rect.height);
		Vector2 vector2 = new Vector2(_image.sprite.rect.x + vector.x * _image.sprite.rect.width, _image.sprite.rect.y + vector.y * _image.sprite.rect.height);
		vector2.x /= _image.sprite.texture.width;
		vector2.y /= _image.sprite.texture.height;
		return _image.sprite.texture.GetPixelBilinear(vector2.x, vector2.y).a > 0.1f;
	}
}
