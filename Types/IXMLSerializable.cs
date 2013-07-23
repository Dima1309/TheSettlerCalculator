using System.Xml;

namespace TheSettlersCalculator.Types
{
	internal interface IXMLSerializable
	{
		void Load(XmlReader reader);

		void Save(XmlWriter writer);
	}
}
