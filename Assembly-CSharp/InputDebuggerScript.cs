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
		Debug.Log("A Button: " + Input.GetButton("A"));
		Debug.Log("B Button: " + Input.GetButton("B"));
		Debug.Log("X Button: " + Input.GetButton("X"));
		Debug.Log("Y Button: " + Input.GetButton("Y"));
		Debug.Log("LB Button: " + Input.GetButton("LB"));
		Debug.Log("RB Button: " + Input.GetButton("RB"));
		Debug.Log("Select Button: " + Input.GetButton("Back"));
		Debug.Log("Start Button: " + Input.GetButton("Start"));
		Debug.Log("LS Button: " + Input.GetButton("LS"));
		Debug.Log("RS Button: " + Input.GetButton("RS"));
		Debug.Log("LT Axis: " + Input.GetAxis("LT"));
		Debug.Log("RT Axis: " + Input.GetAxis("RT"));
		Debug.Log("DpadX: " + Input.GetAxisRaw("DpadX"));
		Debug.Log("DpadY: " + Input.GetAxisRaw("DpadY"));
	}
}
