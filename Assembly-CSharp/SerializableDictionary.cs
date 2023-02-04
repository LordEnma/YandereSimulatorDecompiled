using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver, IXmlSerializable
{
	[SerializeField]
	private List<K> keys;

	[SerializeField]
	private List<V> values;

	private const string XML_Item = "Item";

	private const string XML_Key = "Key";

	private const string XML_Value = "Value";

	public SerializableDictionary()
	{
		keys = new List<K>();
		values = new List<V>();
	}

	public void OnBeforeSerialize()
	{
		keys.Clear();
		values.Clear();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<K, V> current = enumerator.Current;
			keys.Add(current.Key);
			values.Add(current.Value);
		}
	}

	public void OnAfterDeserialize()
	{
		Clear();
		for (int i = 0; i < keys.Count; i++)
		{
			Add(keys[i], values[i]);
		}
	}

	public XmlSchema GetSchema()
	{
		return null;
	}

	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(K));
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(V));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (!isEmptyElement)
		{
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				reader.ReadStartElement("Item");
				reader.ReadStartElement("Key");
				K key = (K)xmlSerializer.Deserialize(reader);
				reader.ReadEndElement();
				reader.ReadStartElement("Value");
				V value = (V)xmlSerializer2.Deserialize(reader);
				reader.ReadEndElement();
				Add(key, value);
				reader.ReadEndElement();
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}
	}

	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(K));
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(V));
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<K, V> current = enumerator.Current;
			writer.WriteStartElement("Item");
			writer.WriteStartElement("Key");
			xmlSerializer.Serialize(writer, current.Key);
			writer.WriteEndElement();
			writer.WriteStartElement("Value");
			xmlSerializer2.Serialize(writer, current.Value);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}
}
