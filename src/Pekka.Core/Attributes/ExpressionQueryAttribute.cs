using System;

namespace Pekka.Core.Attributes
{
    public class ExpressionQueryAttribute : Attribute
    {
        public ExpressionQueryAttribute(string keyName)
        {
            KeyName = keyName;
        }

        public string KeyName { get; }
    }
}