//----------------------
// <auto-generated>
// This file was automatically generated. Any changes to it will be lost if and when the file is regenerated.
// </auto-generated>
//----------------------
#pragma warning disable

using System;
using SQEX.Luminous.Core.Object;
using System.Collections.Generic;
using CodeDom = System.CodeDom;

namespace SQEX.Ebony.Framework.Sequence.Variable.Compare
{
    [Serializable, CodeDom.Compiler.GeneratedCode("Luminaire", "0.1")]
    public partial class SequenceCompareInt : SQEX.Ebony.Framework.Sequence.Variable.Compare.SequenceCompareBase
    {
        new public static ObjectType ObjectType { get; private set; }
        private static PropertyContainer fieldProperties;
		
		public int value_;
		
        
        new public static void SetupObjectType()
        {
            if (ObjectType != null)
            {
                return;
            }

            var dummy = new SequenceCompareInt();
            var properties = dummy.GetFieldProperties();

            ObjectType = new ObjectType("SQEX.Ebony.Framework.Sequence.Variable.Compare.SequenceCompareInt", 0, SQEX.Ebony.Framework.Sequence.Variable.Compare.SequenceCompareInt.ObjectType, Construct, properties, 0, 40);
        }
		
        public override ObjectType GetObjectType()
        {
            return ObjectType;
        }

        protected override PropertyContainer GetFieldProperties()
        {
            if (fieldProperties != null)
            {
                return fieldProperties;
            }

            fieldProperties = new PropertyContainer("SQEX.Ebony.Framework.Sequence.Variable.Compare.SequenceCompareInt", base.GetFieldProperties(), -729396827, 101856147);
            
			fieldProperties.AddIndirectlyProperty(new Property("pDependencyPin_", 1541179946, "void", 8, 8, 1, Property.PrimitiveType.Pointer, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("operator_", 305375494, "SQEX.Ebony.Framework.Sequence.Variable.Compare.SequenceCompareBase.OperatorType", 24, 4, 1, Property.PrimitiveType.Enum, 0, (char)0));
			
			
			fieldProperties.AddProperty(new Property("value_", 273093519, "int", 32, 4, 1, Property.PrimitiveType.Int32, 0, (char)0));
			
			
			return fieldProperties;
        }

		
        private static BaseObject Construct()
        {
            return new SequenceCompareInt();
        }
		
    }
}