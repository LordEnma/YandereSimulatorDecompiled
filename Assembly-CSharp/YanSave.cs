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

// Token: 0x02000504 RID: 1284
public static class YanSave
{
	// Token: 0x170004CE RID: 1230
	// (get) Token: 0x0600212B RID: 8491 RVA: 0x001E651F File Offset: 0x001E471F
	public static string SaveDataPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "SaveFiles");
		}
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x001E6530 File Offset: 0x001E4730
	public static void SaveData(string targetSave)
	{
		YanSaveIdentifier[] array = Resources.FindObjectsOfTypeAll<YanSaveIdentifier>();
		List<SerializedGameObject> list = new List<SerializedGameObject>();
		foreach (YanSaveIdentifier yanSaveIdentifier in array)
		{
			List<SerializedComponent> list2 = new List<SerializedComponent>();
			foreach (Component component in yanSaveIdentifier.gameObject.GetComponents(typeof(Component)))
			{
				if (yanSaveIdentifier.EnabledComponents.Contains(component))
				{
					SerializedComponent serializedComponent = default(SerializedComponent);
					serializedComponent.TypePath = component.GetType().AssemblyQualifiedName;
					serializedComponent.PropertyReferences = new ReferenceDict();
					serializedComponent.PropertyValues = new ValueDict();
					serializedComponent.FieldReferences = new ReferenceDict();
					serializedComponent.FieldValues = new ValueDict();
					serializedComponent.FieldReferenceArrays = new ReferenceArrayDict();
					serializedComponent.PropertyReferenceArrays = new ReferenceArrayDict();
					if (typeof(MonoBehaviour).IsAssignableFrom(component.GetType()))
					{
						serializedComponent.IsMonoBehaviour = true;
						serializedComponent.IsEnabled = ((MonoBehaviour)component).enabled;
					}
					Type type = component.GetType();
					foreach (PropertyInfo propertyInfo in YanSave.GetCachedProperties(type))
					{
						if (propertyInfo.CanWrite && !propertyInfo.IsDefined(typeof(ObsoleteAttribute), true))
						{
							bool flag = false;
							foreach (DisabledYanSaveMember disabledYanSaveMember in yanSaveIdentifier.DisabledProperties)
							{
								if (disabledYanSaveMember.Component == component && disabledYanSaveMember.Name == propertyInfo.Name)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								object value = propertyInfo.GetValue(component);
								bool flag2 = typeof(Component).IsAssignableFrom(propertyInfo.PropertyType);
								bool flag3 = propertyInfo.PropertyType == typeof(GameObject);
								bool isArray = propertyInfo.PropertyType.IsArray;
								bool flag4 = typeof(Component[]).IsAssignableFrom(propertyInfo.PropertyType);
								bool flag5 = typeof(GameObject[]).IsAssignableFrom(propertyInfo.PropertyType);
								if (value != null)
								{
									try
									{
										if (!flag2 && !flag3)
										{
											serializedComponent.PropertyValues.Add(propertyInfo.Name, value);
										}
										else if (isArray)
										{
											List<string> list3 = new List<string>();
											if (flag4)
											{
												list3.AddRange(((Component[])value).Select(delegate(Component x)
												{
													if (!(x.GetComponent<YanSaveIdentifier>() != null))
													{
														return string.Empty;
													}
													return x.GetComponent<YanSaveIdentifier>().ObjectID;
												}));
											}
											else if (flag5)
											{
												list3.AddRange(((GameObject[])value).Select(delegate(GameObject x)
												{
													if (!(x.GetComponent<YanSaveIdentifier>() != null))
													{
														return string.Empty;
													}
													return x.GetComponent<YanSaveIdentifier>().ObjectID;
												}));
											}
											serializedComponent.PropertyReferenceArrays.Add(propertyInfo.Name, list3);
										}
										else
										{
											YanSaveIdentifier yanSaveIdentifier2 = flag2 ? ((Component)value).gameObject.GetComponent<YanSaveIdentifier>() : (flag3 ? ((GameObject)value).GetComponent<YanSaveIdentifier>() : null);
											if (yanSaveIdentifier2 != null)
											{
												serializedComponent.PropertyReferences.Add(propertyInfo.Name, yanSaveIdentifier2.ObjectID);
											}
											else
											{
												serializedComponent.PropertyReferences.Add(propertyInfo.Name, null);
											}
										}
									}
									catch
									{
									}
								}
							}
						}
					}
					foreach (FieldInfo fieldInfo in YanSave.GetCachedFields(type))
					{
						if (!fieldInfo.IsLiteral && !fieldInfo.IsDefined(typeof(ObsoleteAttribute), true))
						{
							bool flag6 = false;
							foreach (DisabledYanSaveMember disabledYanSaveMember2 in yanSaveIdentifier.DisabledFields)
							{
								if (disabledYanSaveMember2.Component == component && disabledYanSaveMember2.Name == fieldInfo.Name)
								{
									flag6 = true;
									break;
								}
							}
							if (!flag6)
							{
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
										serializedComponent.FieldValues.Add(fieldInfo.Name, value2);
									}
									else if (isArray2)
									{
										List<string> list4 = new List<string>();
										if (flag9)
										{
											list4.AddRange(((Component[])value2).Select(delegate(Component x)
											{
												if (!(x.GetComponent<YanSaveIdentifier>() != null))
												{
													return string.Empty;
												}
												return x.GetComponent<YanSaveIdentifier>().ObjectID;
											}));
										}
										else if (flag10)
										{
											list4.AddRange(((GameObject[])value2).Select(delegate(GameObject x)
											{
												if (!(x.GetComponent<YanSaveIdentifier>() != null))
												{
													return string.Empty;
												}
												return x.GetComponent<YanSaveIdentifier>().ObjectID;
											}));
										}
										serializedComponent.FieldReferenceArrays.Add(fieldInfo.Name, list4);
									}
									else
									{
										YanSaveIdentifier yanSaveIdentifier3 = flag7 ? ((Component)value2).gameObject.GetComponent<YanSaveIdentifier>() : (flag8 ? ((GameObject)value2).GetComponent<YanSaveIdentifier>() : null);
										if (yanSaveIdentifier3 != null)
										{
											serializedComponent.FieldReferences.Add(fieldInfo.Name, yanSaveIdentifier3.ObjectID);
										}
										else
										{
											serializedComponent.FieldReferences.Add(fieldInfo.Name, null);
										}
									}
								}
								catch
								{
								}
							}
						}
					}
					serializedComponent.OwnerID = yanSaveIdentifier.ObjectID;
					list2.Add(serializedComponent);
				}
			}
			SerializedGameObject item = new SerializedGameObject
			{
				ActiveInHierarchy = yanSaveIdentifier.gameObject.activeInHierarchy,
				ActiveSelf = yanSaveIdentifier.gameObject.activeSelf,
				IsStatic = yanSaveIdentifier.gameObject.isStatic,
				Layer = yanSaveIdentifier.gameObject.layer,
				Tag = yanSaveIdentifier.gameObject.tag,
				Name = yanSaveIdentifier.gameObject.name,
				SerializedComponents = list2.ToArray(),
				ObjectID = yanSaveIdentifier.ObjectID
			};
			list.Add(item);
		}
		YanSaveStaticIdentifier yanSaveStaticIdentifier = UnityEngine.Object.FindObjectOfType<YanSaveStaticIdentifier>();
		List<SerializedStaticClass> list5 = new List<SerializedStaticClass>();
		ValueDict valueDict = new ValueDict();
		if (yanSaveStaticIdentifier != null)
		{
			foreach (string type2 in yanSaveStaticIdentifier.StaticTypeNames)
			{
				Type type3 = YanSaveHelpers.GrabType(type2);
				if (type3 != null && type3.IsAbstract && type3.IsSealed)
				{
					SerializedStaticClass serializedStaticClass = default(SerializedStaticClass);
					serializedStaticClass.TypePath = type3.AssemblyQualifiedName;
					serializedStaticClass.PropertyReferences = new ReferenceDict();
					serializedStaticClass.PropertyValues = new ValueDict();
					serializedStaticClass.FieldReferences = new ReferenceDict();
					serializedStaticClass.FieldValues = new ValueDict();
					serializedStaticClass.FieldReferenceArrays = new ReferenceArrayDict();
					serializedStaticClass.PropertyReferenceArrays = new ReferenceArrayDict();
					foreach (PropertyInfo propertyInfo2 in YanSave.GetCachedProperties(type3))
					{
						if (propertyInfo2.CanWrite && !propertyInfo2.IsDefined(typeof(ObsoleteAttribute), true))
						{
							bool flag11 = false;
							foreach (KeyValuePair<Type, string> keyValuePair in yanSaveStaticIdentifier.DisabledMembers)
							{
								if (keyValuePair.Value == propertyInfo2.Name)
								{
									flag11 = true;
									break;
								}
							}
							if (!flag11)
							{
								object value3 = propertyInfo2.GetValue(null, null);
								bool flag12 = typeof(Component).IsAssignableFrom(propertyInfo2.PropertyType);
								bool flag13 = propertyInfo2.PropertyType == typeof(GameObject);
								bool isArray3 = propertyInfo2.PropertyType.IsArray;
								bool flag14 = typeof(Component[]).IsAssignableFrom(propertyInfo2.PropertyType);
								bool flag15 = typeof(GameObject[]).IsAssignableFrom(propertyInfo2.PropertyType);
								if (value3 != null)
								{
									try
									{
										if (!flag12 && !flag13)
										{
											serializedStaticClass.PropertyValues.Add(propertyInfo2.Name, value3);
										}
										else if (isArray3)
										{
											List<string> list6 = new List<string>();
											if (flag14)
											{
												list6.AddRange(((Component[])value3).Select(delegate(Component x)
												{
													if (!(x.GetComponent<YanSaveIdentifier>() != null))
													{
														return string.Empty;
													}
													return x.GetComponent<YanSaveIdentifier>().ObjectID;
												}));
											}
											else if (flag15)
											{
												list6.AddRange(((GameObject[])value3).Select(delegate(GameObject x)
												{
													if (!(x.GetComponent<YanSaveIdentifier>() != null))
													{
														return string.Empty;
													}
													return x.GetComponent<YanSaveIdentifier>().ObjectID;
												}));
											}
											serializedStaticClass.PropertyReferenceArrays.Add(propertyInfo2.Name, list6);
										}
										else
										{
											YanSaveIdentifier yanSaveIdentifier4 = flag12 ? ((Component)value3).gameObject.GetComponent<YanSaveIdentifier>() : (flag13 ? ((GameObject)value3).GetComponent<YanSaveIdentifier>() : null);
											if (yanSaveIdentifier4 != null)
											{
												serializedStaticClass.PropertyReferences.Add(propertyInfo2.Name, yanSaveIdentifier4.ObjectID);
											}
											else
											{
												serializedStaticClass.PropertyReferences.Add(propertyInfo2.Name, null);
											}
										}
									}
									catch
									{
									}
								}
							}
						}
					}
					foreach (FieldInfo fieldInfo2 in YanSave.GetCachedFields(type3))
					{
						if (!fieldInfo2.IsLiteral && !fieldInfo2.IsDefined(typeof(ObsoleteAttribute), true))
						{
							bool flag16 = false;
							foreach (KeyValuePair<Type, string> keyValuePair2 in yanSaveStaticIdentifier.DisabledMembers)
							{
								if (keyValuePair2.Value == fieldInfo2.Name)
								{
									flag16 = true;
									break;
								}
							}
							if (!flag16)
							{
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
										serializedStaticClass.FieldValues.Add(fieldInfo2.Name, value4);
									}
									else if (isArray4)
									{
										List<string> list7 = new List<string>();
										if (flag19)
										{
											list7.AddRange(((Component[])value4).Select(delegate(Component x)
											{
												if (!(x.GetComponent<YanSaveIdentifier>() != null))
												{
													return string.Empty;
												}
												return x.GetComponent<YanSaveIdentifier>().ObjectID;
											}));
										}
										else if (flag20)
										{
											list7.AddRange(((GameObject[])value4).Select(delegate(GameObject x)
											{
												if (!(x.GetComponent<YanSaveIdentifier>() != null))
												{
													return string.Empty;
												}
												return x.GetComponent<YanSaveIdentifier>().ObjectID;
											}));
										}
										serializedStaticClass.FieldReferenceArrays.Add(fieldInfo2.Name, list7);
									}
									else
									{
										YanSaveIdentifier yanSaveIdentifier5 = flag17 ? ((Component)value4).gameObject.GetComponent<YanSaveIdentifier>() : (flag18 ? ((GameObject)value4).GetComponent<YanSaveIdentifier>() : null);
										if (yanSaveIdentifier5 != null)
										{
											serializedStaticClass.FieldReferences.Add(fieldInfo2.Name, yanSaveIdentifier5.ObjectID);
										}
										else
										{
											serializedStaticClass.FieldReferences.Add(fieldInfo2.Name, null);
										}
									}
								}
								catch
								{
								}
							}
						}
					}
					list5.Add(serializedStaticClass);
				}
			}
			foreach (YanSavePlayerPrefTracker yanSavePlayerPrefTracker in yanSaveStaticIdentifier.PrefTrackers)
			{
				string text = yanSavePlayerPrefTracker.PrefFormat;
				YanSavePlayerPrefsType prefType = yanSavePlayerPrefTracker.PrefType;
				for (int l = 0; l < yanSavePlayerPrefTracker.RangeMax + 1; l++)
				{
					for (int m = 0; m < yanSavePlayerPrefTracker.PrefFormatValues.Count; m++)
					{
						string text2 = yanSavePlayerPrefTracker.PrefFormatValues[m];
						int num = text2.LastIndexOf('.');
						Type type4 = YanSaveHelpers.GrabType(text2.Substring(0, num));
						string newValue = string.Empty;
						FieldInfo field = type4.GetField(text2.Substring(num + 1));
						PropertyInfo property = type4.GetProperty(text2.Substring(num + 1));
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
						text = text.Replace(string.Format("{{{0}}}", m), newValue);
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
		object value5 = new YanSaveData
		{
			LoadedLevelName = SceneManager.GetActiveScene().name,
			SerializedGameObjects = list.ToArray(),
			SerializedStaticClasses = list5.ToArray(),
			SerializedPlayerPrefs = valueDict
		};
		JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
		jsonSerializerSettings.ContractResolver = new YanSaveResolver();
		jsonSerializerSettings.Error = delegate(object s, Newtonsoft.Json.Serialization.ErrorEventArgs e)
		{
			e.ErrorContext.Handled = true;
		};
		string contents = JsonConvert.SerializeObject(value5, jsonSerializerSettings);
		if (!Directory.Exists(YanSave.SaveDataPath))
		{
			Directory.CreateDirectory(YanSave.SaveDataPath);
		}
		File.WriteAllText(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave"), contents);
		Action onSave = YanSave.OnSave;
		if (onSave == null)
		{
			return;
		}
		onSave();
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x001E7488 File Offset: 0x001E5688
	public static void LoadData(string targetSave, bool recreateMissing = false)
	{
		if (!File.Exists(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave")))
		{
			return;
		}
		YanSaveData yanSaveData = JsonConvert.DeserializeObject<YanSaveData>(File.ReadAllText(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave")));
		if (SceneManager.GetActiveScene().name != yanSaveData.LoadedLevelName)
		{
			SceneManager.LoadScene(yanSaveData.LoadedLevelName);
		}
		SerializedGameObject[] serializedGameObjects = yanSaveData.SerializedGameObjects;
		int i = 0;
		while (i < serializedGameObjects.Length)
		{
			SerializedGameObject serializedGameObject = serializedGameObjects[i];
			GameObject gameObject = YanSaveIdentifier.GetObject(serializedGameObject);
			if (!(gameObject == null))
			{
				goto IL_BA;
			}
			if (recreateMissing)
			{
				gameObject = new GameObject();
				gameObject.AddComponent<YanSaveIdentifier>().ObjectID = serializedGameObject.ObjectID;
				gameObject.SetActive(serializedGameObject.ActiveSelf);
				goto IL_BA;
			}
			IL_15D:
			i++;
			continue;
			IL_BA:
			gameObject.isStatic = serializedGameObject.IsStatic;
			gameObject.layer = serializedGameObject.Layer;
			gameObject.tag = serializedGameObject.Tag;
			gameObject.name = serializedGameObject.Name;
			gameObject.SetActive(serializedGameObject.ActiveSelf);
			foreach (SerializedComponent serializedComponent in serializedGameObject.SerializedComponents)
			{
				if (gameObject != null)
				{
					Type type = YanSave.GetType(serializedComponent.TypePath);
					if (recreateMissing && gameObject.GetComponent(type) == null)
					{
						gameObject.AddComponent(type);
					}
				}
			}
			goto IL_15D;
		}
		foreach (SerializedGameObject serializedGameObject2 in yanSaveData.SerializedGameObjects)
		{
			GameObject @object = YanSaveIdentifier.GetObject(serializedGameObject2);
			if (!(@object == null))
			{
				foreach (SerializedComponent serializedComponent2 in serializedGameObject2.SerializedComponents)
				{
					Type type2 = YanSave.GetType(serializedComponent2.TypePath);
					Component component = @object.GetComponent(type2);
					@object.GetComponent<YanSaveIdentifier>();
					if (!(component == null))
					{
						if (serializedComponent2.IsMonoBehaviour)
						{
							((MonoBehaviour)component).enabled = serializedComponent2.IsEnabled;
						}
						foreach (PropertyInfo propertyInfo in YanSave.GetCachedProperties(type2))
						{
							if (propertyInfo.CanWrite)
							{
								bool flag = typeof(Component).IsAssignableFrom(propertyInfo.PropertyType);
								if (!flag && propertyInfo.PropertyType != typeof(GameObject))
								{
									if (serializedComponent2.PropertyValues.ContainsKey(propertyInfo.Name))
									{
										object obj = serializedComponent2.PropertyValues[propertyInfo.Name];
										if (obj == null)
										{
											propertyInfo.SetValue(component, null);
										}
										else
										{
											if (obj.GetType() == typeof(JObject))
											{
												try
												{
													propertyInfo.SetValue(component, ((JObject)obj).ToObject(propertyInfo.PropertyType));
													goto IL_523;
												}
												catch
												{
													goto IL_523;
												}
											}
											if (obj.GetType() == typeof(JArray))
											{
												try
												{
													propertyInfo.SetValue(component, ((JArray)obj).ToObject(propertyInfo.PropertyType));
													goto IL_523;
												}
												catch
												{
													goto IL_523;
												}
											}
											bool isEnum = propertyInfo.PropertyType.IsEnum;
											bool flag2 = typeof(IConvertible).IsAssignableFrom(obj.GetType());
											propertyInfo.SetValue(component, isEnum ? Enum.ToObject(propertyInfo.PropertyType, obj) : (flag2 ? Convert.ChangeType(obj, propertyInfo.PropertyType) : obj));
										}
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
								else if (serializedComponent2.PropertyReferenceArrays.ContainsKey(propertyInfo.Name))
								{
									bool flag4 = typeof(Component[]).IsAssignableFrom(propertyInfo.PropertyType);
									bool flag5 = typeof(GameObject[]).IsAssignableFrom(propertyInfo.PropertyType);
									List<string> list = serializedComponent2.PropertyReferenceArrays[propertyInfo.Name];
									Type elementType = propertyInfo.PropertyType.GetElementType();
									if (flag4)
									{
										IList list2 = Array.CreateInstance(elementType, list.Count);
										for (int l = 0; l < list.Count; l++)
										{
											GameObject object3 = YanSaveIdentifier.GetObject(list[l]);
											Component value = (object3 != null) ? object3.GetComponent(elementType) : null;
											list2[l] = value;
										}
										propertyInfo.SetValue(component, list2);
									}
									else if (flag5)
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
							IL_523:;
						}
						foreach (FieldInfo fieldInfo in YanSave.GetCachedFields(type2))
						{
							bool flag6 = typeof(Component).IsAssignableFrom(fieldInfo.FieldType);
							bool flag7 = typeof(Component[]).IsAssignableFrom(fieldInfo.FieldType);
							bool flag8 = typeof(GameObject[]).IsAssignableFrom(fieldInfo.FieldType);
							if (!flag7 && !flag8 && !flag6 && fieldInfo.FieldType != typeof(GameObject))
							{
								if (serializedComponent2.FieldValues.ContainsKey(fieldInfo.Name))
								{
									object obj2 = serializedComponent2.FieldValues[fieldInfo.Name];
									if (obj2 == null)
									{
										fieldInfo.SetValue(component, null);
									}
									else
									{
										if (obj2.GetType() == typeof(JObject))
										{
											try
											{
												fieldInfo.SetValue(component, ((JObject)obj2).ToObject(fieldInfo.FieldType));
												goto IL_860;
											}
											catch
											{
												goto IL_860;
											}
										}
										if (obj2.GetType() == typeof(JArray))
										{
											try
											{
												fieldInfo.SetValue(component, ((JArray)obj2).ToObject(fieldInfo.FieldType));
												goto IL_860;
											}
											catch
											{
												goto IL_860;
											}
										}
										bool isEnum2 = fieldInfo.FieldType.IsEnum;
										bool flag9 = typeof(IConvertible).IsAssignableFrom(obj2.GetType());
										fieldInfo.SetValue(component, isEnum2 ? Enum.ToObject(fieldInfo.FieldType, obj2) : (flag9 ? Convert.ChangeType(obj2, fieldInfo.FieldType) : obj2));
									}
								}
							}
							else if (serializedComponent2.FieldReferences.ContainsKey(fieldInfo.Name))
							{
								bool flag10 = fieldInfo.FieldType == typeof(GameObject);
								GameObject object5 = YanSaveIdentifier.GetObject(serializedComponent2.FieldReferences[fieldInfo.Name]);
								if (!(object5 == null))
								{
									if (flag6)
									{
										fieldInfo.SetValue(component, object5.GetComponent(fieldInfo.FieldType));
									}
									else if (flag10)
									{
										fieldInfo.SetValue(component, object5);
									}
								}
							}
							else if (serializedComponent2.FieldReferenceArrays.ContainsKey(fieldInfo.Name))
							{
								List<string> list4 = serializedComponent2.FieldReferenceArrays[fieldInfo.Name];
								Type elementType2 = fieldInfo.FieldType.GetElementType();
								if (flag7)
								{
									IList list5 = Array.CreateInstance(elementType2, list4.Count);
									for (int n = 0; n < list4.Count; n++)
									{
										GameObject object6 = YanSaveIdentifier.GetObject(list4[n]);
										Component value2 = (object6 != null) ? object6.GetComponent(elementType2) : null;
										list5[n] = value2;
									}
									fieldInfo.SetValue(component, list5);
								}
								else if (flag8)
								{
									IList list6 = Array.CreateInstance(elementType2, list4.Count);
									for (int num = 0; num < list4.Count; num++)
									{
										GameObject object7 = YanSaveIdentifier.GetObject(list4[num]);
										list6[num] = object7;
									}
									fieldInfo.SetValue(component, list6);
								}
							}
							IL_860:;
						}
					}
				}
			}
		}
		foreach (SerializedStaticClass serializedStaticClass in yanSaveData.SerializedStaticClasses)
		{
			Type type3 = YanSave.GetType(serializedStaticClass.TypePath);
			if (!(type3 == null))
			{
				foreach (PropertyInfo propertyInfo2 in type3.GetProperties())
				{
					if (propertyInfo2.CanWrite)
					{
						bool flag11 = typeof(Component).IsAssignableFrom(propertyInfo2.PropertyType);
						if (!flag11 && propertyInfo2.PropertyType != typeof(GameObject))
						{
							if (serializedStaticClass.PropertyValues.ContainsKey(propertyInfo2.Name))
							{
								object obj3 = serializedStaticClass.PropertyValues[propertyInfo2.Name];
								if (obj3 == null)
								{
									propertyInfo2.SetValue(null, null);
								}
								else
								{
									if (obj3.GetType() == typeof(JObject))
									{
										try
										{
											propertyInfo2.SetValue(null, ((JObject)obj3).ToObject(propertyInfo2.PropertyType));
											goto IL_BE1;
										}
										catch
										{
											goto IL_BE1;
										}
									}
									if (obj3.GetType() == typeof(JArray))
									{
										try
										{
											propertyInfo2.SetValue(null, ((JArray)obj3).ToObject(propertyInfo2.PropertyType));
											goto IL_BE1;
										}
										catch
										{
											goto IL_BE1;
										}
									}
									bool isEnum3 = propertyInfo2.PropertyType.IsEnum;
									bool flag12 = typeof(IConvertible).IsAssignableFrom(obj3.GetType());
									propertyInfo2.SetValue(null, isEnum3 ? Enum.ToObject(propertyInfo2.PropertyType, obj3) : (flag12 ? Convert.ChangeType(obj3, propertyInfo2.PropertyType) : obj3));
								}
							}
						}
						else if (serializedStaticClass.PropertyReferences.ContainsKey(propertyInfo2.Name))
						{
							bool flag13 = propertyInfo2.PropertyType == typeof(GameObject);
							GameObject object8 = YanSaveIdentifier.GetObject(serializedStaticClass.FieldReferences[propertyInfo2.Name]);
							if (!(object8 == null))
							{
								if (flag11)
								{
									propertyInfo2.SetValue(null, object8.GetComponent(propertyInfo2.PropertyType));
								}
								else if (flag13)
								{
									propertyInfo2.SetValue(null, object8);
								}
							}
						}
						else if (serializedStaticClass.PropertyReferenceArrays.ContainsKey(propertyInfo2.Name))
						{
							bool flag14 = typeof(Component[]).IsAssignableFrom(propertyInfo2.PropertyType);
							bool flag15 = typeof(GameObject[]).IsAssignableFrom(propertyInfo2.PropertyType);
							List<string> list7 = serializedStaticClass.PropertyReferenceArrays[propertyInfo2.Name];
							Type elementType3 = propertyInfo2.PropertyType.GetElementType();
							if (flag14)
							{
								IList list8 = Array.CreateInstance(elementType3, list7.Count);
								for (int num2 = 0; num2 < list7.Count; num2++)
								{
									GameObject object9 = YanSaveIdentifier.GetObject(list7[num2]);
									Component value3 = (object9 != null) ? object9.GetComponent(elementType3) : null;
									list8[num2] = value3;
								}
								propertyInfo2.SetValue(null, list8);
							}
							else if (flag15)
							{
								IList list9 = Array.CreateInstance(elementType3, list7.Count);
								for (int num3 = 0; num3 < list7.Count; num3++)
								{
									GameObject object10 = YanSaveIdentifier.GetObject(list7[num3]);
									list9[num3] = object10;
								}
								propertyInfo2.SetValue(null, list9);
							}
						}
					}
					IL_BE1:;
				}
				foreach (FieldInfo fieldInfo2 in type3.GetFields())
				{
					bool flag16 = typeof(Component).IsAssignableFrom(fieldInfo2.FieldType);
					bool flag17 = typeof(Component[]).IsAssignableFrom(fieldInfo2.FieldType);
					bool flag18 = typeof(GameObject[]).IsAssignableFrom(fieldInfo2.FieldType);
					if (!flag17 && !flag18 && !flag16 && fieldInfo2.FieldType != typeof(GameObject))
					{
						if (serializedStaticClass.FieldValues.ContainsKey(fieldInfo2.Name))
						{
							object obj4 = serializedStaticClass.FieldValues[fieldInfo2.Name];
							if (obj4 == null)
							{
								fieldInfo2.SetValue(null, null);
							}
							else
							{
								if (obj4.GetType() == typeof(JObject))
								{
									try
									{
										fieldInfo2.SetValue(null, ((JObject)obj4).ToObject(fieldInfo2.FieldType));
										goto IL_F16;
									}
									catch
									{
										goto IL_F16;
									}
								}
								if (obj4.GetType() == typeof(JArray))
								{
									try
									{
										fieldInfo2.SetValue(null, ((JArray)obj4).ToObject(fieldInfo2.FieldType));
										goto IL_F16;
									}
									catch
									{
										goto IL_F16;
									}
								}
								bool isEnum4 = fieldInfo2.FieldType.IsEnum;
								bool flag19 = typeof(IConvertible).IsAssignableFrom(obj4.GetType());
								fieldInfo2.SetValue(null, isEnum4 ? Enum.ToObject(fieldInfo2.FieldType, obj4) : (flag19 ? Convert.ChangeType(obj4, fieldInfo2.FieldType) : obj4));
							}
						}
					}
					else if (serializedStaticClass.FieldReferences.ContainsKey(fieldInfo2.Name))
					{
						bool flag20 = fieldInfo2.FieldType == typeof(GameObject);
						GameObject object11 = YanSaveIdentifier.GetObject(serializedStaticClass.FieldReferences[fieldInfo2.Name]);
						if (!(object11 == null))
						{
							if (flag16)
							{
								fieldInfo2.SetValue(null, object11.GetComponent(fieldInfo2.FieldType));
							}
							else if (flag20)
							{
								fieldInfo2.SetValue(null, object11);
							}
						}
					}
					else if (serializedStaticClass.FieldReferenceArrays.ContainsKey(fieldInfo2.Name))
					{
						List<string> list10 = serializedStaticClass.FieldReferenceArrays[fieldInfo2.Name];
						Type elementType4 = fieldInfo2.FieldType.GetElementType();
						if (flag17)
						{
							IList list11 = Array.CreateInstance(elementType4, list10.Count);
							for (int num4 = 0; num4 < list10.Count; num4++)
							{
								GameObject object12 = YanSaveIdentifier.GetObject(list10[num4]);
								Component value4 = (object12 != null) ? object12.GetComponent(elementType4) : null;
								list11[num4] = value4;
							}
							fieldInfo2.SetValue(null, list11);
						}
						else if (flag18)
						{
							IList list12 = Array.CreateInstance(elementType4, list10.Count);
							for (int num5 = 0; num5 < list10.Count; num5++)
							{
								GameObject object13 = YanSaveIdentifier.GetObject(list10[num5]);
								list12[num5] = object13;
							}
							fieldInfo2.SetValue(null, list12);
						}
					}
					IL_F16:;
				}
			}
		}
		Action onLoad = YanSave.OnLoad;
		if (onLoad == null)
		{
			return;
		}
		onLoad();
	}

	// Token: 0x0600212E RID: 8494 RVA: 0x001E8440 File Offset: 0x001E6640
	public static void LoadPrefs(string targetSave)
	{
		foreach (KeyValuePair<string, object> keyValuePair in JsonConvert.DeserializeObject<YanSaveData>(File.ReadAllText(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave"))).SerializedPlayerPrefs)
		{
			object value = keyValuePair.Value;
			Type type = value.GetType();
			if (type == typeof(double) || type == typeof(float))
			{
				PlayerPrefs.SetFloat(keyValuePair.Key, (float)value);
			}
			else if (type == typeof(string))
			{
				PlayerPrefs.SetString(keyValuePair.Key, (string)value);
			}
			else if (type == typeof(short) || type == typeof(int) || type == typeof(long))
			{
				PlayerPrefs.SetInt(keyValuePair.Key, Convert.ToInt32(value));
			}
		}
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x001E8568 File Offset: 0x001E6768
	public static void LoadAll(string targetSave)
	{
		YanSave.LoadData(targetSave, false);
		YanSave.LoadPrefs(targetSave);
	}

	// Token: 0x06002130 RID: 8496 RVA: 0x001E8578 File Offset: 0x001E6778
	public static void RemoveData(string targetSave)
	{
		string path = Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave");
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

	// Token: 0x06002131 RID: 8497 RVA: 0x001E85C0 File Offset: 0x001E67C0
	private static PropertyInfo[] GetCachedProperties(Type type)
	{
		if (YanSave.PropertyCache.ContainsKey(type))
		{
			return YanSave.PropertyCache[type];
		}
		YanSave.PropertyCache.Add(type, type.GetProperties());
		return YanSave.PropertyCache[type];
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x001E85F8 File Offset: 0x001E67F8
	private static FieldInfo[] GetCachedFields(Type type)
	{
		if (YanSave.FieldCache.ContainsKey(type))
		{
			return YanSave.FieldCache[type];
		}
		FieldInfo[] fields = type.GetFields();
		YanSave.FieldCache.Add(type, fields);
		return fields;
	}

	// Token: 0x06002133 RID: 8499 RVA: 0x001E8634 File Offset: 0x001E6834
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

	// Token: 0x040048C8 RID: 18632
	public const string SAVE_EXTENSION = "yansave";

	// Token: 0x040048C9 RID: 18633
	public static Action OnLoad;

	// Token: 0x040048CA RID: 18634
	public static Action OnSave;

	// Token: 0x040048CB RID: 18635
	private static Dictionary<Type, PropertyInfo[]> PropertyCache = new Dictionary<Type, PropertyInfo[]>();

	// Token: 0x040048CC RID: 18636
	private static Dictionary<Type, FieldInfo[]> FieldCache = new Dictionary<Type, FieldInfo[]>();
}
