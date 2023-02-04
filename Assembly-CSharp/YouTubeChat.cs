using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using UnityEngine;

public class YouTubeChat : MonoBehaviour
{
	public static YouTubeChat instance;

	public WebDriver driver;

	public string youtubeChatPopoutUrl;

	private string pathToDriver = Directory.GetCurrentDirectory() + "\\Assets\\Packages\\Selenium.WebDriver.GeckoDriver.0.30.0.1\\driver\\";

	private string defaultPathToDriver = Directory.GetCurrentDirectory() + "\\Assets\\Packages\\Selenium.WebDriver.GeckoDriver.0.30.0.1\\driver\\";

	private FirefoxOptions options;

	private FirefoxDriverService FFDriverService;

	private int previousLength;

	public Queue<YouTubeChatMessage> MessageQueue = new Queue<YouTubeChatMessage>();

	private Thread updateThread;

	private bool hasSetVersion;

	private string _youtubeChatPopoutUrl;

	public bool isValidURL;

	public float Timer;

	public bool TimeBased;

	private void OnEnable()
	{
		instance = this;
		pathToDriver = Application.dataPath + "/StreamingAssets/Packages/Selenium.WebDriver.GeckoDriver.0.30.0.1/driver/";
		defaultPathToDriver = pathToDriver;
		options = getFirefoxOptions();
		if (updateThread != null && updateThread.IsAlive)
		{
			updateThread.Abort();
			updateThread = null;
		}
		StartDriver();
		_youtubeChatPopoutUrl = youtubeChatPopoutUrl;
	}

	private void StartDriver()
	{
		if (FFDriverService != null)
		{
			FFDriverService = null;
		}
		FFDriverService = FirefoxDriverService.CreateDefaultService(getVersionPath());
		FFDriverService.HideCommandPromptWindow = true;
		ActivateDriver();
	}

	private void OnDisable()
	{
		instance = null;
		CloseDriver();
	}

	private void Update()
	{
		AssureDriverActivated();
		if (!isValidURL && updateThread != null && updateThread.IsAlive)
		{
			updateThread.Abort();
		}
	}

	public YouTubeChatMessage NextInQueue()
	{
		if (MessageQueue.Count != 0)
		{
			return MessageQueue.Peek();
		}
		return null;
	}

	public void Dequeue()
	{
		MessageQueue.Dequeue();
	}

	private void _messageUpdate()
	{
		while (true)
		{
			try
			{
				UpdateMessagesList(initialRun: false);
			}
			catch (Exception)
			{
			}
		}
	}

	public void UpdateMessagesList(bool initialRun)
	{
		ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(By.TagName("YT-LIVE-CHAT-TEXT-MESSAGE-RENDERER"));
		if (!initialRun)
		{
			if (previousLength > readOnlyCollection.Count)
			{
				UpdateMessagesList(initialRun: true);
			}
			if (previousLength < readOnlyCollection.Count)
			{
				for (int i = previousLength; i < readOnlyCollection.Count; i++)
				{
					try
					{
						IWebElement webElement = readOnlyCollection[i].FindElement(By.Id("message"));
						if (webElement != null && webElement.Text != string.Empty && webElement.Text[0] == '!')
						{
							MessageQueue.Enqueue(new YouTubeChatMessage(readOnlyCollection[i].FindElement(By.Id("author-name")).Text, readOnlyCollection[i].GetAttribute("timestampString"), webElement.Text));
						}
					}
					catch
					{
					}
				}
			}
		}
		previousLength = readOnlyCollection.Count;
		if (previousLength >= 100)
		{
			driver.Navigate().Refresh();
		}
	}

	public void AssureDriverActivated()
	{
		if (driver == null || string.IsNullOrEmpty(driver.CurrentWindowHandle) || _youtubeChatPopoutUrl != youtubeChatPopoutUrl)
		{
			if (_youtubeChatPopoutUrl != youtubeChatPopoutUrl)
			{
				CloseDriver();
			}
			ActivateDriver();
			_youtubeChatPopoutUrl = youtubeChatPopoutUrl;
		}
	}

	private void ActivateDriver()
	{
		Debug.Log(pathToDriver);
		if (FFDriverService == null)
		{
			FFDriverService = FirefoxDriverService.CreateDefaultService(getVersionPath());
			FFDriverService.HideCommandPromptWindow = true;
		}
		driver = new FirefoxDriver(FFDriverService, options);
		if (!string.IsNullOrEmpty(youtubeChatPopoutUrl) && youtubeChatPopoutUrl.Contains("https://www.youtube.") && youtubeChatPopoutUrl.Contains("/live_chat?is_popout=") && youtubeChatPopoutUrl.Contains("&v="))
		{
			try
			{
				HttpWebResponse httpWebResponse = null;
				httpWebResponse = (HttpWebResponse)((HttpWebRequest)WebRequest.Create(youtubeChatPopoutUrl)).GetResponse();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					try
					{
						driver.Navigate().GoToUrl(youtubeChatPopoutUrl);
						UpdateMessagesList(initialRun: true);
						isValidURL = true;
						if (updateThread != null && updateThread.IsAlive)
						{
							updateThread.Abort();
							updateThread = null;
						}
						updateThread = new Thread(_messageUpdate);
						updateThread.Start();
					}
					catch (Exception)
					{
						isValidURL = false;
					}
				}
				httpWebResponse.Dispose();
				return;
			}
			catch
			{
				isValidURL = false;
				_youtubeChatPopoutUrl = string.Empty;
				return;
			}
		}
		isValidURL = false;
	}

	private void OnApplicationQuit()
	{
		CloseDriver();
	}

	private void CloseDriver()
	{
		if (driver != null)
		{
			driver.Close();
			driver.Quit();
			driver = null;
			if (FFDriverService != null)
			{
				FFDriverService.Dispose();
				FFDriverService = null;
			}
			if (updateThread != null)
			{
				updateThread.Abort();
				updateThread = null;
			}
		}
	}

	private string getVersionPath()
	{
		_ = Application.platform;
		if (!hasSetVersion)
		{
			switch (Application.platform)
			{
			case RuntimePlatform.WindowsPlayer:
				pathToDriver += "win32";
				break;
			case RuntimePlatform.WindowsEditor:
				pathToDriver += "win32";
				break;
			case RuntimePlatform.OSXEditor:
				pathToDriver += "mac64";
				break;
			case RuntimePlatform.OSXPlayer:
				pathToDriver += "mac64";
				break;
			case RuntimePlatform.LinuxEditor:
				pathToDriver += "linux64";
				break;
			case RuntimePlatform.LinuxPlayer:
				pathToDriver += "linux64";
				break;
			default:
				Debug.LogError("Unsupported Version for Youtube Chat");
				break;
			}
			hasSetVersion = true;
		}
		return pathToDriver;
	}

	private FirefoxOptions getFirefoxOptions()
	{
		FirefoxOptions firefoxOptions = new FirefoxOptions();
		firefoxOptions.BrowserExecutableLocation = defaultPathToDriver + "MozillaFirefox/firefox.exe";
		firefoxOptions.AddArguments(new List<string> { "--silent-launch", "--no-startup-window", "no-sandbox", "--disable-gpu", "-headless" });
		return firefoxOptions;
	}
}
