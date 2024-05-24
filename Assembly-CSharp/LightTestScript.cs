using UnityEngine;

public class LightTestScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Camera MyCamera;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			MyCamera.renderingPath = RenderingPath.UsePlayerSettings;
			Yandere.NotificationManager.CustomText = "RenderingPath = UsePlayerSettings";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			MyCamera.renderingPath = RenderingPath.DeferredLighting;
			Yandere.NotificationManager.CustomText = "RenderingPath = DeferredLighting";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			MyCamera.renderingPath = RenderingPath.DeferredShading;
			Yandere.NotificationManager.CustomText = "RenderingPath = DeferredShading";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			MyCamera.renderingPath = RenderingPath.Forward;
			Yandere.NotificationManager.CustomText = "RenderingPath = Forward";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			MyCamera.renderingPath = RenderingPath.VertexLit;
			Yandere.NotificationManager.CustomText = "RenderingPath = VertexLit";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}
}
