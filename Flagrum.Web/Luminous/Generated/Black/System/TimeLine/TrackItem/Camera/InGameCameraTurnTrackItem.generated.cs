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

namespace Black.System.TimeLine.TrackItem.Camera
{
    [Serializable, CodeDom.Compiler.GeneratedCode("Luminaire", "0.1")]
    public partial class InGameCameraTurnTrackItem : SQEX.Ebony.Framework.TimeControl.TimeLine.TrackItem
    {
        new public static ObjectType ObjectType { get; private set; }
        private static PropertyContainer fieldProperties;
		
		public Black.System.TimeLine.TrackItem.Camera.Struct.InGameCameraTurn turnData_= new Black.System.TimeLine.TrackItem.Camera.Struct.InGameCameraTurn();
		
        
        new public static void SetupObjectType()
        {
            if (ObjectType != null)
            {
                return;
            }

            var dummy = new InGameCameraTurnTrackItem();
            var properties = dummy.GetFieldProperties();

            ObjectType = new ObjectType("Black.System.TimeLine.TrackItem.Camera.InGameCameraTurnTrackItem", 0, Black.System.TimeLine.TrackItem.Camera.InGameCameraTurnTrackItem.ObjectType, Construct, properties, 0, 184);
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

            fieldProperties = new PropertyContainer("Black.System.TimeLine.TrackItem.Camera.InGameCameraTurnTrackItem", base.GetFieldProperties(), -855874924, 57542421);
            
			fieldProperties.AddIndirectlyProperty(new Property("name_", 182823483, "Ebony.Base.String", 8, 16, 1, Property.PrimitiveType.String, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("startTime_", 140908163, "float", 24, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("duration_", 1282328598, "float", 28, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.isOverrideLockOnLayer_", 3567920311, "bool", 96, 1, 1, Property.PrimitiveType.Bool, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.isUseLockOnTurn_", 2533559228, "bool", 97, 1, 1, Property.PrimitiveType.Bool, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.isUseLockOnTurnTilt_", 2859245817, "bool", 98, 1, 1, Property.PrimitiveType.Bool, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_", 1988401852, "Black.Camera.Struct.CameraControlTurn", 104, 56, 1, Property.PrimitiveType.ClassField, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.mode", 4087316061, "Black.Camera.Struct.CameraControlTurnMode", 112, 4, 1, Property.PrimitiveType.Enum, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.isUseAutoAdjustMode_", 2245401815, "bool", 116, 1, 1, Property.PrimitiveType.Bool, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.isUseAutoAdjustAngleMode_", 1072408860, "bool", 117, 1, 1, Property.PrimitiveType.Bool, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.isUseDefaultBrakeParam_", 2797317379, "bool", 118, 1, 1, Property.PrimitiveType.Bool, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.controlTurnVelocity_", 2767405268, "float", 120, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.backToDefaultTurnVelocity_", 775007214, "float", 124, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.yawMin_", 3403517188, "float", 128, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.yawMax_", 4057123734, "float", 132, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.tiltMin_", 1427567976, "float", 136, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.tiltMax_", 2116248418, "float", 140, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.brakeAngleYaw_", 124100920, "float", 144, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.brakePowerYaw_", 345049326, "float", 148, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.brakeAngleTilt_", 249626076, "float", 152, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.controlTurn_.brakePowerTilt_", 812313170, "float", 156, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.angleLimit_", 1759721162, "Black.Camera.Struct.CameraAngleLimit", 160, 24, 1, Property.PrimitiveType.ClassField, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.angleLimit_.tiltAngleLimitMode_", 3197147083, "Black.Camera.CameraAngleLimitMode", 168, 4, 1, Property.PrimitiveType.Enum, 0, (char)0));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.angleLimit_.tiltAngleLimitMin_", 4287928484, "float", 172, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			fieldProperties.AddIndirectlyProperty(new Property("turnData_.angleLimit_.tiltAngleLimitMax_", 2835576502, "float", 176, 4, 1, Property.PrimitiveType.Float, 0, (char)1));
			
			
			fieldProperties.AddProperty(new Property("turnData_", 3671100655, "Black.System.TimeLine.TrackItem.Camera.Struct.InGameCameraTurn", 88, 96, 1, Property.PrimitiveType.ClassField, 0, (char)0));
			
			
			return fieldProperties;
        }

		
        private static BaseObject Construct()
        {
            return new InGameCameraTurnTrackItem();
        }
		
    }
}