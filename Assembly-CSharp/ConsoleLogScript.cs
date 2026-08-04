using UnityEngine;

public class ConsoleLogScript : MonoBehaviour
{
	public DebugEnablerScript debug;

	private string myLog = "Debug Console Output:";

	private bool doShow;

	private bool Long;

	public int kChars = 700;

	private int enters;

	private int id;

	public string[] code;

	private void Start()
	{
		kChars = 2100;
	}

	private void OnEnable()
	{
		Application.logMessageReceived += Log;
	}

	private void OnDisable()
	{
		Application.logMessageReceived -= Log;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			enters++;
			if (enters == 10)
			{
				doShow = true;
				Long = false;
			}
			else if (enters == 11)
			{
				doShow = true;
				Long = true;
			}
			else if (enters == 12)
			{
				doShow = false;
				enters = 9;
			}
		}
		if (id < code.Length && Input.GetKeyDown(code[id]))
		{
			id++;
			if (id == code.Length && debug.gameObject != null)
			{
				debug.EnableDebug();
			}
		}
	}

	public void Log(string logString, string stackTrace, LogType type)
	{
		switch (type)
		{
		case LogType.Warning:
			return;
		case LogType.Error:
		case LogType.Assert:
		case LogType.Exception:
			myLog += "\n";
			break;
		}
		myLog = myLog + "\n" + logString;
		if (type == LogType.Error || type == LogType.Exception || type == LogType.Assert)
		{
			if (!string.IsNullOrEmpty(stackTrace))
			{
				myLog = myLog + "\n" + stackTrace;
			}
			myLog += "\n";
		}
		if (myLog.Length > kChars)
		{
			myLog = myLog.Substring(myLog.Length - kChars);
		}
	}

	private void OnGUI()
	{
		if (doShow)
		{
			if (Long)
			{
				GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)Screen.height / 720f, 1f));
				GUI.TextArea(new Rect(0f, 0f, 469.33246f, Screen.height), myLog);
			}
			else
			{
				GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, (float)Screen.height / 720f, 1f));
				GUI.TextArea(new Rect(0f, 479.9952f, 469.33246f, 239.9976f), myLog);
			}
		}
	}
}
