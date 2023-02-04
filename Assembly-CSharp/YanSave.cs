using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class YanSave
{
	public const string SAVE_EXTENSION = "yansave";

	public static Action OnLoad;

	public static Action OnSave;

	private static Dictionary<Type, PropertyInfo[]> PropertyCache = new Dictionary<Type, PropertyInfo[]>();

	private static Dictionary<Type, FieldInfo[]> FieldCache = new Dictionary<Type, FieldInfo[]>();

	public static string SaveDataPath => Path.Combine(Application.streamingAssetsPath, "SaveFiles");

	public static void SaveData(string targetSave)
	{
		YanSaveIdentifier[] array = Resources.FindObjectsOfTypeAll<YanSaveIdentifier>();
		List<SerializedGameObject> list = new List<SerializedGameObject>();
		YanSaveIdentifier[] array2 = array;
		foreach (YanSaveIdentifier yanSaveIdentifier in array2)
		{
			List<SerializedComponent> list2 = new List<SerializedComponent>();
			Component[] components = yanSaveIdentifier.gameObject.GetComponents(typeof(Component));
			foreach (Component component in components)
			{
				if (!yanSaveIdentifier.EnabledComponents.Contains(component))
				{
					continue;
				}
				SerializedComponent item = default(SerializedComponent);
				item.TypePath = component.GetType().AssemblyQualifiedName;
				item.PropertyReferences = new ReferenceDict();
				item.PropertyValues = new ValueDict();
				item.FieldReferences = new ReferenceDict();
				item.FieldValues = new ValueDict();
				item.FieldReferenceArrays = new ReferenceArrayDict();
				item.PropertyReferenceArrays = new ReferenceArrayDict();
				if (typeof(MonoBehaviour).IsAssignableFrom(component.GetType()))
				{
					item.IsMonoBehaviour = true;
					item.IsEnabled = ((MonoBehaviour)component).enabled;
				}
				Type type = component.GetType();
				PropertyInfo[] cachedProperties = GetCachedProperties(type);
				foreach (PropertyInfo propertyInfo in cachedProperties)
				{
					if (!propertyInfo.CanWrite || propertyInfo.IsDefined(typeof(ObsoleteAttribute), inherit: true))
					{
						continue;
					}
					bool flag = false;
					foreach (DisabledYanSaveMember disabledProperty in yanSaveIdentifier.DisabledProperties)
					{
						if (disabledProperty.Component == component && disabledProperty.Name == propertyInfo.Name)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
					object value = propertyInfo.GetValue(component);
					bool flag2 = typeof(Component).IsAssignableFrom(propertyInfo.PropertyType);
					bool flag3 = propertyInfo.PropertyType == typeof(GameObject);
					bool isArray = propertyInfo.PropertyType.IsArray;
					bool flag4 = typeof(Component[]).IsAssignableFrom(propertyInfo.PropertyType);
					bool flag5 = typeof(GameObject[]).IsAssignableFrom(propertyInfo.PropertyType);
					if (value == null)
					{
						continue;
					}
					try
					{
						if (!flag2 && !flag3)
						{
							item.PropertyValues.Add(propertyInfo.Name, value);
						}
						else if (isArray)
						{
							List<string> list3 = new List<string>();
							if (flag4)
							{
								list3.AddRange(((Component[])value).Select((Component x) => (!(x.GetComponent<YanSaveIdentifier>() != null)) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID));
							}
							else if (flag5)
							{
								list3.AddRange(((GameObject[])value).Select((GameObject x) => (!(x.GetComponent<YanSaveIdentifier>() != null)) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID));
							}
							item.PropertyReferenceArrays.Add(propertyInfo.Name, list3);
						}
						else
						{
							YanSaveIdentifier yanSaveIdentifier2 = (flag2 ? ((Component)value).gameObject.GetComponent<YanSaveIdentifier>() : (flag3 ? ((GameObject)value).GetComponent<YanSaveIdentifier>() : null));
							if (yanSaveIdentifier2 != null)
							{
								item.PropertyReferences.Add(propertyInfo.Name, yanSaveIdentifier2.ObjectID);
							}
							else
							{
								item.PropertyReferences.Add(propertyInfo.Name, null);
							}
						}
					}
					catch
					{
					}
				}
				FieldInfo[] cachedFields = GetCachedFields(type);
				foreach (FieldInfo fieldInfo in cachedFields)
				{
					if (fieldInfo.IsLiteral || fieldInfo.IsDefined(typeof(ObsoleteAttribute), inherit: true))
					{
						continue;
					}
					bool flag6 = false;
					foreach (DisabledYanSaveMember disabledField in yanSaveIdentifier.DisabledFields)
					{
						if (disabledField.Component == component && disabledField.Name == fieldInfo.Name)
						{
							flag6 = true;
							break;
						}
					}
					if (flag6)
					{
						continue;
					}
					object value2 = fieldInfo.GetValue(component);
					bool flag7 = typeof(Component).IsAssignableFrom(fieldInfo.FieldType);
					bool flag8 = fieldInfo.FieldType == typeof(GameObject);
					bool isArray2 = fieldInfo.FieldType.IsArray;
					bool flag9 = typeof(Component[]).IsAssignableFrom(fieldInfo.FieldType);
					bool flag10 = typeof(GameObject[]).IsAssignableFrom(fieldInfo.FieldType);
					try
					{
						if (!flag7 && !flag8 && !flag9 && !flag10)
						{
							item.FieldValues.Add(fieldInfo.Name, value2);
						}
						else if (isArray2)
						{
							List<string> list4 = new List<string>();
							if (flag9)
							{
								list4.AddRange(((Component[])value2).Select((Component x) => (!(x.GetComponent<YanSaveIdentifier>() != null)) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID));
							}
							else if (flag10)
							{
								list4.AddRange(((GameObject[])value2).Select((GameObject x) => (!(x.GetComponent<YanSaveIdentifier>() != null)) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID));
							}
							item.FieldReferenceArrays.Add(fieldInfo.Name, list4);
						}
						else
						{
							YanSaveIdentifier yanSaveIdentifier3 = (flag7 ? ((Component)value2).gameObject.GetComponent<YanSaveIdentifier>() : (flag8 ? ((GameObject)value2).GetComponent<YanSaveIdentifier>() : null));
							if (yanSaveIdentifier3 != null)
							{
								item.FieldReferences.Add(fieldInfo.Name, yanSaveIdentifier3.ObjectID);
							}
							else
							{
								item.FieldReferences.Add(fieldInfo.Name, null);
							}
						}
					}
					catch
					{
					}
				}
				item.OwnerID = yanSaveIdentifier.ObjectID;
				list2.Add(item);
			}
			SerializedGameObject serializedGameObject = default(SerializedGameObject);
			serializedGameObject.ActiveInHierarchy = yanSaveIdentifier.gameObject.activeInHierarchy;
			serializedGameObject.ActiveSelf = yanSaveIdentifier.gameObject.activeSelf;
			serializedGameObject.IsStatic = yanSaveIdentifier.gameObject.isStatic;
			serializedGameObject.Layer = yanSaveIdentifier.gameObject.layer;
			serializedGameObject.Tag = yanSaveIdentifier.gameObject.tag;
			serializedGameObject.Name = yanSaveIdentifier.gameObject.name;
			serializedGameObject.SerializedComponents = list2.ToArray();
			serializedGameObject.ObjectID = yanSaveIdentifier.ObjectID;
			SerializedGameObject item2 = serializedGameObject;
			list.Add(item2);
		}
		YanSaveStaticIdentifier yanSaveStaticIdentifier = UnityEngine.Object.FindObjectOfType<YanSaveStaticIdentifier>();
		List<SerializedStaticClass> list5 = new List<SerializedStaticClass>();
		ValueDict valueDict = new ValueDict();
		if (yanSaveStaticIdentifier != null)
		{
			foreach (string staticTypeName in yanSaveStaticIdentifier.StaticTypeNames)
			{
				Type type2 = YanSaveHelpers.GrabType(staticTypeName);
				if (!(type2 != null) || !type2.IsAbstract || !type2.IsSealed)
				{
					continue;
				}
				SerializedStaticClass item3 = default(SerializedStaticClass);
				item3.TypePath = type2.AssemblyQualifiedName;
				item3.PropertyReferences = new ReferenceDict();
				item3.PropertyValues = new ValueDict();
				item3.FieldReferences = new ReferenceDict();
				item3.FieldValues = new ValueDict();
				item3.FieldReferenceArrays = new ReferenceArrayDict();
				item3.PropertyReferenceArrays = new ReferenceArrayDict();
				PropertyInfo[] cachedProperties = GetCachedProperties(type2);
				foreach (PropertyInfo propertyInfo2 in cachedProperties)
				{
					if (!propertyInfo2.CanWrite || propertyInfo2.IsDefined(typeof(ObsoleteAttribute), inherit: true))
					{
						continue;
					}
					bool flag11 = false;
					foreach (KeyValuePair<Type, string> disabledMember in yanSaveStaticIdentifier.DisabledMembers)
					{
						if (disabledMember.Value == propertyInfo2.Name)
						{
							flag11 = true;
							break;
						}
					}
					if (flag11)
					{
						continue;
					}
					object value3 = propertyInfo2.GetValue(null, null);
					bool flag12 = typeof(Component).IsAssignableFrom(propertyInfo2.PropertyType);
					bool flag13 = propertyInfo2.PropertyType == typeof(GameObject);
					bool isArray3 = propertyInfo2.PropertyType.IsArray;
					bool flag14 = typeof(Component[]).IsAssignableFrom(propertyInfo2.PropertyType);
					bool flag15 = typeof(GameObject[]).IsAssignableFrom(propertyInfo2.PropertyType);
					if (value3 == null)
					{
						continue;
					}
					try
					{
						if (!flag12 && !flag13)
						{
							item3.PropertyValues.Add(propertyInfo2.Name, value3);
						}
						else if (isArray3)
						{
							List<string> list6 = new List<string>();
							if (flag14)
							{
								list6.AddRange(((Component[])value3).Select((Component x) => (!(x.GetComponent<YanSaveIdentifier>() != null)) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID));
							}
							else if (flag15)
							{
								list6.AddRange(((GameObject[])value3).Select((GameObject x) => (!(x.GetComponent<YanSaveIdentifier>() != null)) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID));
							}
							item3.PropertyReferenceArrays.Add(propertyInfo2.Name, list6);
						}
						else
						{
							YanSaveIdentifier yanSaveIdentifier4 = (flag12 ? ((Component)value3).gameObject.GetComponent<YanSaveIdentifier>() : (flag13 ? ((GameObject)value3).GetComponent<YanSaveIdentifier>() : null));
							if (yanSaveIdentifier4 != null)
							{
								item3.PropertyReferences.Add(propertyInfo2.Name, yanSaveIdentifier4.ObjectID);
							}
							else
							{
								item3.PropertyReferences.Add(propertyInfo2.Name, null);
							}
						}
					}
					catch
					{
					}
				}
				FieldInfo[] cachedFields = GetCachedFields(type2);
				foreach (FieldInfo fieldInfo2 in cachedFields)
				{
					if (fieldInfo2.IsLiteral || fieldInfo2.IsDefined(typeof(ObsoleteAttribute), inherit: true))
					{
						continue;
					}
					bool flag16 = false;
					foreach (KeyValuePair<Type, string> disabledMember2 in yanSaveStaticIdentifier.DisabledMembers)
					{
						if (disabledMember2.Value == fieldInfo2.Name)
						{
							flag16 = true;
							break;
						}
					}
					if (flag16)
					{
						continue;
					}
					object value4 = fieldInfo2.GetValue(null);
					bool flag17 = typeof(Component).IsAssignableFrom(fieldInfo2.FieldType);
					bool flag18 = fieldInfo2.FieldType == typeof(GameObject);
					bool isArray4 = fieldInfo2.FieldType.IsArray;
					bool flag19 = typeof(Component[]).IsAssignableFrom(fieldInfo2.FieldType);
					bool flag20 = typeof(GameObject[]).IsAssignableFrom(fieldInfo2.FieldType);
					try
					{
						if (!flag17 && !flag18 && !flag19 && !flag20)
						{
							item3.FieldValues.Add(fieldInfo2.Name, value4);
						}
						else if (isArray4)
						{
							List<string> list7 = new List<string>();
							if (flag19)
							{
								list7.AddRange(((Component[])value4).Select((Component x) => (!(x.GetComponent<YanSaveIdentifier>() != null)) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID));
							}
							else if (flag20)
							{
								list7.AddRange(((GameObject[])value4).Select((GameObject x) => (!(x.GetComponent<YanSaveIdentifier>() != null)) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID));
							}
							item3.FieldReferenceArrays.Add(fieldInfo2.Name, list7);
						}
						else
						{
							YanSaveIdentifier yanSaveIdentifier5 = (flag17 ? ((Component)value4).gameObject.GetComponent<YanSaveIdentifier>() : (flag18 ? ((GameObject)value4).GetComponent<YanSaveIdentifier>() : null));
							if (yanSaveIdentifier5 != null)
							{
								item3.FieldReferences.Add(fieldInfo2.Name, yanSaveIdentifier5.ObjectID);
							}
							else
							{
								item3.FieldReferences.Add(fieldInfo2.Name, null);
							}
						}
					}
					catch
					{
					}
				}
				list5.Add(item3);
			}
			foreach (YanSavePlayerPrefTracker prefTracker in yanSaveStaticIdentifier.PrefTrackers)
			{
				string text = prefTracker.PrefFormat;
				YanSavePlayerPrefsType prefType = prefTracker.PrefType;
				for (int l = 0; l < prefTracker.RangeMax + 1; l++)
				{
					for (int m = 0; m < prefTracker.PrefFormatValues.Count; m++)
					{
						string text2 = prefTracker.PrefFormatValues[m];
						int num = text2.LastIndexOf('.');
						Type type3 = YanSaveHelpers.GrabType(text2.Substring(0, num));
						string newValue = string.Empty;
						FieldInfo field = type3.GetField(text2.Substring(num + 1));
						PropertyInfo property = type3.GetProperty(text2.Substring(num + 1));
						if (property != null)
						{
							newValue = property.GetValue(null, null).ToString();
						}
						else if (field != null)
						{
							newValue = field.GetValue(null).ToString();
						}
						else
						{
							Debug.Log("Couldn't grab replacement value of '" + text2 + "'");
						}
						text = text.Replace($"{{{m}}}", newValue);
					}
					string key = text.Replace("{i}", l.ToString());
					switch (prefType)
					{
					case YanSavePlayerPrefsType.Float:
						valueDict.Add(key, PlayerPrefs.GetFloat(key));
						break;
					case YanSavePlayerPrefsType.Int:
						valueDict.Add(key, PlayerPrefs.GetInt(key));
						break;
					case YanSavePlayerPrefsType.String:
						valueDict.Add(key, PlayerPrefs.GetString(key));
						break;
					}
				}
			}
		}
		YanSaveData yanSaveData = default(YanSaveData);
		yanSaveData.LoadedLevelName = SceneManager.GetActiveScene().name;
		yanSaveData.SerializedGameObjects = list.ToArray();
		yanSaveData.SerializedStaticClasses = list5.ToArray();
		yanSaveData.SerializedPlayerPrefs = valueDict;
		string contents = JsonConvert.SerializeObject(yanSaveData, new JsonSerializerSettings
		{
			ContractResolver = new YanSaveResolver(),
			Error = delegate(object s, Newtonsoft.Json.Serialization.ErrorEventArgs e)
			{
				e.ErrorContext.Handled = true;
			}
		});
		if (!Directory.Exists(SaveDataPath))
		{
			Directory.CreateDirectory(SaveDataPath);
		}
		File.WriteAllText(Path.Combine(SaveDataPath, targetSave + ".yansave"), contents);
		OnSave?.Invoke();
	}

	public static void LoadData(string targetSave, bool recreateMissing = false)
	{
		if (!File.Exists(Path.Combine(SaveDataPath, targetSave + ".yansave")))
		{
			return;
		}
		YanSaveData yanSaveData = JsonConvert.DeserializeObject<YanSaveData>(File.ReadAllText(Path.Combine(SaveDataPath, targetSave + ".yansave")));
		if (SceneManager.GetActiveScene().name != yanSaveData.LoadedLevelName)
		{
			SceneManager.LoadScene(yanSaveData.LoadedLevelName);
		}
		SerializedGameObject[] serializedGameObjects = yanSaveData.SerializedGameObjects;
		for (int i = 0; i < serializedGameObjects.Length; i++)
		{
			SerializedGameObject serializedGameObject = serializedGameObjects[i];
			GameObject gameObject = YanSaveIdentifier.GetObject(serializedGameObject);
			if (gameObject == null)
			{
				if (!recreateMissing)
				{
					continue;
				}
				gameObject = new GameObject();
				gameObject.AddComponent<YanSaveIdentifier>().ObjectID = serializedGameObject.ObjectID;
				gameObject.SetActive(serializedGameObject.ActiveSelf);
			}
			gameObject.isStatic = serializedGameObject.IsStatic;
			gameObject.layer = serializedGameObject.Layer;
			gameObject.tag = serializedGameObject.Tag;
			gameObject.name = serializedGameObject.Name;
			gameObject.SetActive(serializedGameObject.ActiveSelf);
			SerializedComponent[] serializedComponents = serializedGameObject.SerializedComponents;
			for (int j = 0; j < serializedComponents.Length; j++)
			{
				SerializedComponent serializedComponent = serializedComponents[j];
				if (gameObject != null)
				{
					Type type = GetType(serializedComponent.TypePath);
					if (recreateMissing && gameObject.GetComponent(type) == null)
					{
						gameObject.AddComponent(type);
					}
				}
			}
		}
		serializedGameObjects = yanSaveData.SerializedGameObjects;
		for (int i = 0; i < serializedGameObjects.Length; i++)
		{
			SerializedGameObject serializedGameObject2 = serializedGameObjects[i];
			GameObject @object = YanSaveIdentifier.GetObject(serializedGameObject2);
			if (@object == null)
			{
				continue;
			}
			SerializedComponent[] serializedComponents = serializedGameObject2.SerializedComponents;
			for (int j = 0; j < serializedComponents.Length; j++)
			{
				SerializedComponent serializedComponent2 = serializedComponents[j];
				Type type2 = GetType(serializedComponent2.TypePath);
				Component component = @object.GetComponent(type2);
				@object.GetComponent<YanSaveIdentifier>();
				if (component == null)
				{
					continue;
				}
				if (serializedComponent2.IsMonoBehaviour)
				{
					((MonoBehaviour)component).enabled = serializedComponent2.IsEnabled;
				}
				PropertyInfo[] cachedProperties = GetCachedProperties(type2);
				foreach (PropertyInfo propertyInfo in cachedProperties)
				{
					if (!propertyInfo.CanWrite)
					{
						continue;
					}
					bool flag = typeof(Component).IsAssignableFrom(propertyInfo.PropertyType);
					if (!flag && propertyInfo.PropertyType != typeof(GameObject))
					{
						if (!serializedComponent2.PropertyValues.ContainsKey(propertyInfo.Name))
						{
							continue;
						}
						object obj = serializedComponent2.PropertyValues[propertyInfo.Name];
						if (obj == null)
						{
							propertyInfo.SetValue(component, null);
						}
						else if (obj.GetType() == typeof(JObject))
						{
							try
							{
								propertyInfo.SetValue(component, ((JObject)obj).ToObject(propertyInfo.PropertyType));
							}
							catch
							{
							}
						}
						else if (obj.GetType() == typeof(JArray))
						{
							try
							{
								propertyInfo.SetValue(component, ((JArray)obj).ToObject(propertyInfo.PropertyType));
							}
							catch
							{
							}
						}
						else
						{
							bool isEnum = propertyInfo.PropertyType.IsEnum;
							bool flag2 = typeof(IConvertible).IsAssignableFrom(obj.GetType());
							propertyInfo.SetValue(component, isEnum ? Enum.ToObject(propertyInfo.PropertyType, obj) : (flag2 ? Convert.ChangeType(obj, propertyInfo.PropertyType) : obj));
						}
					}
					else if (serializedComponent2.PropertyReferences.ContainsKey(propertyInfo.Name))
					{
						bool flag3 = propertyInfo.PropertyType == typeof(GameObject);
						GameObject object2 = YanSaveIdentifier.GetObject(serializedComponent2.FieldReferences[propertyInfo.Name]);
						if (!(object2 == null))
						{
							if (flag)
							{
								propertyInfo.SetValue(component, object2.GetComponent(propertyInfo.PropertyType));
							}
							else if (flag3)
							{
								propertyInfo.SetValue(component, object2);
							}
						}
					}
					else
					{
						if (!serializedComponent2.PropertyReferenceArrays.ContainsKey(propertyInfo.Name))
						{
							continue;
						}
						bool num = typeof(Component[]).IsAssignableFrom(propertyInfo.PropertyType);
						bool flag4 = typeof(GameObject[]).IsAssignableFrom(propertyInfo.PropertyType);
						List<string> list = serializedComponent2.PropertyReferenceArrays[propertyInfo.Name];
						Type elementType = propertyInfo.PropertyType.GetElementType();
						if (num)
						{
							IList list2 = Array.CreateInstance(elementType, list.Count);
							for (int l = 0; l < list.Count; l++)
							{
								GameObject object3 = YanSaveIdentifier.GetObject(list[l]);
								Component value = ((object3 != null) ? object3.GetComponent(elementType) : null);
								list2[l] = value;
							}
							propertyInfo.SetValue(component, list2);
						}
						else if (flag4)
						{
							IList list3 = Array.CreateInstance(elementType, list.Count);
							for (int m = 0; m < list.Count; m++)
							{
								GameObject object4 = YanSaveIdentifier.GetObject(list[m]);
								list3[m] = object4;
							}
							propertyInfo.SetValue(component, list3);
						}
					}
				}
				FieldInfo[] cachedFields = GetCachedFields(type2);
				foreach (FieldInfo fieldInfo in cachedFields)
				{
					bool flag5 = typeof(Component).IsAssignableFrom(fieldInfo.FieldType);
					bool flag6 = typeof(Component[]).IsAssignableFrom(fieldInfo.FieldType);
					bool flag7 = typeof(GameObject[]).IsAssignableFrom(fieldInfo.FieldType);
					if (!flag6 && !flag7 && !flag5 && fieldInfo.FieldType != typeof(GameObject))
					{
						if (!serializedComponent2.FieldValues.ContainsKey(fieldInfo.Name))
						{
							continue;
						}
						object obj4 = serializedComponent2.FieldValues[fieldInfo.Name];
						if (obj4 == null)
						{
							fieldInfo.SetValue(component, null);
						}
						else if (obj4.GetType() == typeof(JObject))
						{
							try
							{
								fieldInfo.SetValue(component, ((JObject)obj4).ToObject(fieldInfo.FieldType));
							}
							catch
							{
							}
						}
						else if (obj4.GetType() == typeof(JArray))
						{
							try
							{
								fieldInfo.SetValue(component, ((JArray)obj4).ToObject(fieldInfo.FieldType));
							}
							catch
							{
							}
						}
						else
						{
							bool isEnum2 = fieldInfo.FieldType.IsEnum;
							bool flag8 = typeof(IConvertible).IsAssignableFrom(obj4.GetType());
							fieldInfo.SetValue(component, isEnum2 ? Enum.ToObject(fieldInfo.FieldType, obj4) : (flag8 ? Convert.ChangeType(obj4, fieldInfo.FieldType) : obj4));
						}
					}
					else if (serializedComponent2.FieldReferences.ContainsKey(fieldInfo.Name))
					{
						bool flag9 = fieldInfo.FieldType == typeof(GameObject);
						GameObject object5 = YanSaveIdentifier.GetObject(serializedComponent2.FieldReferences[fieldInfo.Name]);
						if (!(object5 == null))
						{
							if (flag5)
							{
								fieldInfo.SetValue(component, object5.GetComponent(fieldInfo.FieldType));
							}
							else if (flag9)
							{
								fieldInfo.SetValue(component, object5);
							}
						}
					}
					else
					{
						if (!serializedComponent2.FieldReferenceArrays.ContainsKey(fieldInfo.Name))
						{
							continue;
						}
						List<string> list4 = serializedComponent2.FieldReferenceArrays[fieldInfo.Name];
						Type elementType2 = fieldInfo.FieldType.GetElementType();
						if (flag6)
						{
							IList list5 = Array.CreateInstance(elementType2, list4.Count);
							for (int n = 0; n < list4.Count; n++)
							{
								GameObject object6 = YanSaveIdentifier.GetObject(list4[n]);
								Component value2 = ((object6 != null) ? object6.GetComponent(elementType2) : null);
								list5[n] = value2;
							}
							fieldInfo.SetValue(component, list5);
						}
						else if (flag7)
						{
							IList list6 = Array.CreateInstance(elementType2, list4.Count);
							for (int num2 = 0; num2 < list4.Count; num2++)
							{
								GameObject object7 = YanSaveIdentifier.GetObject(list4[num2]);
								list6[num2] = object7;
							}
							fieldInfo.SetValue(component, list6);
						}
					}
				}
			}
		}
		SerializedStaticClass[] serializedStaticClasses = yanSaveData.SerializedStaticClasses;
		for (int i = 0; i < serializedStaticClasses.Length; i++)
		{
			SerializedStaticClass serializedStaticClass = serializedStaticClasses[i];
			Type type3 = GetType(serializedStaticClass.TypePath);
			if (type3 == null)
			{
				continue;
			}
			PropertyInfo[] cachedProperties = type3.GetProperties();
			foreach (PropertyInfo propertyInfo2 in cachedProperties)
			{
				if (!propertyInfo2.CanWrite)
				{
					continue;
				}
				bool flag10 = typeof(Component).IsAssignableFrom(propertyInfo2.PropertyType);
				if (!flag10 && propertyInfo2.PropertyType != typeof(GameObject))
				{
					if (!serializedStaticClass.PropertyValues.ContainsKey(propertyInfo2.Name))
					{
						continue;
					}
					object obj7 = serializedStaticClass.PropertyValues[propertyInfo2.Name];
					if (obj7 == null)
					{
						propertyInfo2.SetValue(null, null);
					}
					else if (obj7.GetType() == typeof(JObject))
					{
						try
						{
							propertyInfo2.SetValue(null, ((JObject)obj7).ToObject(propertyInfo2.PropertyType));
						}
						catch
						{
						}
					}
					else if (obj7.GetType() == typeof(JArray))
					{
						try
						{
							propertyInfo2.SetValue(null, ((JArray)obj7).ToObject(propertyInfo2.PropertyType));
						}
						catch
						{
						}
					}
					else
					{
						bool isEnum3 = propertyInfo2.PropertyType.IsEnum;
						bool flag11 = typeof(IConvertible).IsAssignableFrom(obj7.GetType());
						propertyInfo2.SetValue(null, isEnum3 ? Enum.ToObject(propertyInfo2.PropertyType, obj7) : (flag11 ? Convert.ChangeType(obj7, propertyInfo2.PropertyType) : obj7));
					}
				}
				else if (serializedStaticClass.PropertyReferences.ContainsKey(propertyInfo2.Name))
				{
					bool flag12 = propertyInfo2.PropertyType == typeof(GameObject);
					GameObject object8 = YanSaveIdentifier.GetObject(serializedStaticClass.FieldReferences[propertyInfo2.Name]);
					if (!(object8 == null))
					{
						if (flag10)
						{
							propertyInfo2.SetValue(null, object8.GetComponent(propertyInfo2.PropertyType));
						}
						else if (flag12)
						{
							propertyInfo2.SetValue(null, object8);
						}
					}
				}
				else
				{
					if (!serializedStaticClass.PropertyReferenceArrays.ContainsKey(propertyInfo2.Name))
					{
						continue;
					}
					bool num3 = typeof(Component[]).IsAssignableFrom(propertyInfo2.PropertyType);
					bool flag13 = typeof(GameObject[]).IsAssignableFrom(propertyInfo2.PropertyType);
					List<string> list7 = serializedStaticClass.PropertyReferenceArrays[propertyInfo2.Name];
					Type elementType3 = propertyInfo2.PropertyType.GetElementType();
					if (num3)
					{
						IList list8 = Array.CreateInstance(elementType3, list7.Count);
						for (int num4 = 0; num4 < list7.Count; num4++)
						{
							GameObject object9 = YanSaveIdentifier.GetObject(list7[num4]);
							Component value3 = ((object9 != null) ? object9.GetComponent(elementType3) : null);
							list8[num4] = value3;
						}
						propertyInfo2.SetValue(null, list8);
					}
					else if (flag13)
					{
						IList list9 = Array.CreateInstance(elementType3, list7.Count);
						for (int num5 = 0; num5 < list7.Count; num5++)
						{
							GameObject object10 = YanSaveIdentifier.GetObject(list7[num5]);
							list9[num5] = object10;
						}
						propertyInfo2.SetValue(null, list9);
					}
				}
			}
			FieldInfo[] cachedFields = type3.GetFields();
			foreach (FieldInfo fieldInfo2 in cachedFields)
			{
				bool flag14 = typeof(Component).IsAssignableFrom(fieldInfo2.FieldType);
				bool flag15 = typeof(Component[]).IsAssignableFrom(fieldInfo2.FieldType);
				bool flag16 = typeof(GameObject[]).IsAssignableFrom(fieldInfo2.FieldType);
				if (!flag15 && !flag16 && !flag14 && fieldInfo2.FieldType != typeof(GameObject))
				{
					if (!serializedStaticClass.FieldValues.ContainsKey(fieldInfo2.Name))
					{
						continue;
					}
					object obj10 = serializedStaticClass.FieldValues[fieldInfo2.Name];
					if (obj10 == null)
					{
						fieldInfo2.SetValue(null, null);
					}
					else if (obj10.GetType() == typeof(JObject))
					{
						try
						{
							fieldInfo2.SetValue(null, ((JObject)obj10).ToObject(fieldInfo2.FieldType));
						}
						catch
						{
						}
					}
					else if (obj10.GetType() == typeof(JArray))
					{
						try
						{
							fieldInfo2.SetValue(null, ((JArray)obj10).ToObject(fieldInfo2.FieldType));
						}
						catch
						{
						}
					}
					else
					{
						bool isEnum4 = fieldInfo2.FieldType.IsEnum;
						bool flag17 = typeof(IConvertible).IsAssignableFrom(obj10.GetType());
						fieldInfo2.SetValue(null, isEnum4 ? Enum.ToObject(fieldInfo2.FieldType, obj10) : (flag17 ? Convert.ChangeType(obj10, fieldInfo2.FieldType) : obj10));
					}
				}
				else if (serializedStaticClass.FieldReferences.ContainsKey(fieldInfo2.Name))
				{
					bool flag18 = fieldInfo2.FieldType == typeof(GameObject);
					GameObject object11 = YanSaveIdentifier.GetObject(serializedStaticClass.FieldReferences[fieldInfo2.Name]);
					if (!(object11 == null))
					{
						if (flag14)
						{
							fieldInfo2.SetValue(null, object11.GetComponent(fieldInfo2.FieldType));
						}
						else if (flag18)
						{
							fieldInfo2.SetValue(null, object11);
						}
					}
				}
				else
				{
					if (!serializedStaticClass.FieldReferenceArrays.ContainsKey(fieldInfo2.Name))
					{
						continue;
					}
					List<string> list10 = serializedStaticClass.FieldReferenceArrays[fieldInfo2.Name];
					Type elementType4 = fieldInfo2.FieldType.GetElementType();
					if (flag15)
					{
						IList list11 = Array.CreateInstance(elementType4, list10.Count);
						for (int num6 = 0; num6 < list10.Count; num6++)
						{
							GameObject object12 = YanSaveIdentifier.GetObject(list10[num6]);
							Component value4 = ((object12 != null) ? object12.GetComponent(elementType4) : null);
							list11[num6] = value4;
						}
						fieldInfo2.SetValue(null, list11);
					}
					else if (flag16)
					{
						IList list12 = Array.CreateInstance(elementType4, list10.Count);
						for (int num7 = 0; num7 < list10.Count; num7++)
						{
							GameObject object13 = YanSaveIdentifier.GetObject(list10[num7]);
							list12[num7] = object13;
						}
						fieldInfo2.SetValue(null, list12);
					}
				}
			}
		}
		OnLoad?.Invoke();
	}

	public static void LoadPrefs(string targetSave)
	{
		foreach (KeyValuePair<string, object> serializedPlayerPref in JsonConvert.DeserializeObject<YanSaveData>(File.ReadAllText(Path.Combine(SaveDataPath, targetSave + ".yansave"))).SerializedPlayerPrefs)
		{
			object value = serializedPlayerPref.Value;
			Type type = value.GetType();
			if (type == typeof(double) || type == typeof(float))
			{
				PlayerPrefs.SetFloat(serializedPlayerPref.Key, (float)value);
			}
			else if (type == typeof(string))
			{
				PlayerPrefs.SetString(serializedPlayerPref.Key, (string)value);
			}
			else if (type == typeof(short) || type == typeof(int) || type == typeof(long))
			{
				PlayerPrefs.SetInt(serializedPlayerPref.Key, Convert.ToInt32(value));
			}
		}
	}

	public static void LoadAll(string targetSave)
	{
		LoadData(targetSave);
		LoadPrefs(targetSave);
	}

	public static void RemoveData(string targetSave)
	{
		string path = Path.Combine(SaveDataPath, targetSave + ".yansave");
		try
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		catch
		{
		}
	}

	private static PropertyInfo[] GetCachedProperties(Type type)
	{
		if (PropertyCache.ContainsKey(type))
		{
			return PropertyCache[type];
		}
		PropertyCache.Add(type, type.GetProperties());
		return PropertyCache[type];
	}

	private static FieldInfo[] GetCachedFields(Type type)
	{
		if (FieldCache.ContainsKey(type))
		{
			return FieldCache[type];
		}
		FieldInfo[] fields = type.GetFields();
		FieldCache.Add(type, fields);
		return fields;
	}

	private static Type GetType(string typeName)
	{
		Type type = Type.GetType(typeName);
		if (type != null)
		{
			return type;
		}
		Assembly assembly = Assembly.Load(typeName.Substring(0, typeName.IndexOf('.')));
		if (assembly == null)
		{
			return null;
		}
		return assembly.GetType(typeName);
	}
}
