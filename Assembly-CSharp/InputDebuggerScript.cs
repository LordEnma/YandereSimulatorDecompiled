using UnityEngine;

public class InputDebuggerScript : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		Debug.Log("h is: " + Input.GetAxis("Horizontal"));
		Debug.Log("v is: " + Input.GetAxis("Vertical"));
		Debug.Log("Mouse X: " + Input.GetAxis("Mouse X"));
		Debug.Log("Mouse Y: " + Input.GetAxis("Mouse Y"));
		Debug.Log("Mouse X: " + Input.GetAxis(InputNames.Xbox_JoyX));
		Debug.Log("Mouse Y: " + Input.GetAxis(InputNames.Xbox_JoyY));
		Debug.Log("A Button: " + Input.GetButton(InputNames.Xbox_A));
		Debug.Log("B Button: " + Input.GetButton(InputNames.Xbox_B));
		Debug.Log("X Button: " + Input.GetButton(InputNames.Xbox_X));
		Debug.Log("Y Button: " + Input.GetButton(InputNames.Xbox_Y));
		Debug.Log("LB Button: " + Input.GetButton(InputNames.Xbox_LB));
		Debug.Log("RB Button: " + Input.GetButton(InputNames.Xbox_RB));
		Debug.Log("Select Button: " + Input.GetButton(InputNames.Xbox_Back));
		Debug.Log("Start Button: " + Input.GetButton(InputNames.Xbox_Start));
		Debug.Log("LS Button: " + Input.GetButton(InputNames.Xbox_LS));
		Debug.Log("RS Button: " + Input.GetButton(InputNames.Xbox_RS));
		Debug.Log("LT Axis: " + Input.GetAxis(InputNames.Xbox_LT));
		Debug.Log("RT Axis: " + Input.GetAxis(InputNames.Xbox_RT));
		Debug.Log("DpadX: " + Input.GetAxisRaw(InputNames.Xbox_DpadX));
		Debug.Log("DpadY: " + Input.GetAxisRaw(InputNames.Xbox_DpadY));
	}
}
