using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	[SerializeField]
	private List<T> elements;

	private const string XML_Element = "Element";

	public SerializableHashSet()
	{
		elements = new List<T>();
	}

	public void OnBeforeSerialize()
	{
		elements.Clear();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				elements.Add(current);
			}
		}
	}

	public void OnAfterDeserialize()
	{
		Clear();
		for (int i = 0; i < elements.Count; i++)
		{
			Add(elements[i]);
		}
	}

	public XmlSchema GetSchema()
	{
		return null;
	}

	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (!isEmptyElement)
		{
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				reader.ReadStartElement("Element");
				T item = (T)xmlSerializer.Deserialize(reader);
				reader.ReadEndElement();
				Add(item);
				reader.MoveToContent();
			}
		}
	}

	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				writer.WriteStartElement("Element");
				xmlSerializer.Serialize(writer, current);
				writer.WriteEndElement();
			}
		}
	}
}
