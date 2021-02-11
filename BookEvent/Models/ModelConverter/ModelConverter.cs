using Shared;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace BookEvent.ModelConverter
{
    public class ModelConverter
    {
        public static void FillDTOFromModel(object fromModel, DTOBase toDTO)
        {
            FillData(toDTO, fromModel, false);
        }

        public static void FillModelFromDTO(DTOBase fromDTO, object toModel)
        {
            FillData(fromDTO, toModel, true);
        }

        private static void FillData(DTOBase dto, object model, bool modelFromDto)
        {
            var dtoType = dto.GetType();
            var entityType = model.GetType();
            MappingType mappingType;

            if (!VerifyForModelType(entityType, dtoType, out mappingType))
            {
                throw new Exception(string.Format(Thread.CurrentThread.CurrentCulture, "Model type '{0}' must match with type specified in ModelMappingAttribute on type '{1}' !", entityType.ToString(), dtoType.ToString()));
            }

            var properties = dtoType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                bool skipThisProperty = false;
                object[] customAttributes = property.GetCustomAttributes(typeof(ModelPropertyMappingAttribute), false);
                if (mappingType == MappingType.TotalExplicit && customAttributes.Length == 0)
                {
                    continue;
                }

                foreach (object customAttribute in customAttributes)
                {
                    ModelPropertyMappingAttribute modelPropertyMappingAttribute = (ModelPropertyMappingAttribute)customAttribute;
                    if (modelPropertyMappingAttribute.MappingDirection == ModelMappingDirectionType.None)
                    {
                        skipThisProperty = true;
                        break;
                    }
                }

                if (skipThisProperty)
                {
                    continue;
                }

                var modelPropertyName = GetModelPropertyName(property, mappingType, modelFromDto);
                if (!string.IsNullOrEmpty(modelPropertyName))
                {
                    var entityProperty = entityType.GetProperty(modelPropertyName);

                    if (entityProperty == null)
                    {
                        throw new Exception(modelPropertyName);
                    }

                    var sourceProperty = modelFromDto ? property : entityProperty;
                    var destinationProperty = modelFromDto ? entityProperty : property;
                    var sourceObject = modelFromDto ? (dto as object) : (model as object);
                    var destinationObject = modelFromDto ? (model as object) : (dto as object);
                    var sourceValue = sourceProperty.GetValue(sourceObject, null);

                    if (destinationProperty.CanWrite)
                    {
                        if (sourceProperty.PropertyType.IsEnum && destinationProperty.PropertyType == typeof(byte))
                        {
                            sourceValue = (byte)(int)sourceValue;
                        }

                        destinationProperty.SetValue(destinationObject, sourceValue, null);
                    }
                }
            }
        }
        private static bool VerifyForModelType(Type entityType, Type DTOType, out MappingType mappingType)
        {
            var attributes = DTOType.GetCustomAttributes(typeof(ModelMappingAttribute), false);
            if (attributes.Count() == 1)
            {
                var mappingAttribute = (ModelMappingAttribute)attributes[0];
                mappingType = (MappingType)mappingAttribute.MappingType;
                return true;
            }

            throw new Exception("Only one EntityMappingAttribute can be applied on type '{0}' !");
        }

        private static string GetModelPropertyName(PropertyInfo property, MappingType mappingType, bool modelFromDTO)
        {
            string entityPropertyName = string.Empty;
            var attribute =
                        (ModelPropertyMappingAttribute)
                        Attribute.GetCustomAttribute(property, typeof(ModelPropertyMappingAttribute));

            bool skipMapping = false;

            if (attribute != null)
            {
                if (modelFromDTO)
                {
                    skipMapping = !(attribute.MappingDirection == ModelMappingDirectionType.ModelFromDTO || attribute.MappingDirection == ModelMappingDirectionType.Both);
                }
                else
                {
                    skipMapping = !(attribute.MappingDirection == ModelMappingDirectionType.DTOFromModel || attribute.MappingDirection == ModelMappingDirectionType.Both);
                }
            }

            switch (mappingType)
            {
                case MappingType.TotalExplicit:
                    if (attribute == null)
                    {
                        throw new Exception(
                            string.Format(
                                        Thread.CurrentThread.CurrentCulture,
                                        "Property '{0}' should have ModelPropertyMappingAttribute !")
                                        );
                    }

                    entityPropertyName = skipMapping ? string.Empty : attribute.MappedModelPropertyName;
                    break;
                case MappingType.TotalImplicit:
                    if (attribute != null && skipMapping)
                    {
                        entityPropertyName = string.Empty;
                    }
                    else
                    {
                        entityPropertyName = property.Name;
                    }

                    break;
                case MappingType.Hybrid:
                    if (attribute == null)
                    {
                        entityPropertyName = property.Name;
                    }
                    else if (skipMapping)
                    {
                        entityPropertyName = string.Empty;
                    }
                    else
                        entityPropertyName = attribute.MappedModelPropertyName;
                    break;
                default:
                    break;
            }

            return entityPropertyName;
        }
    }

   
}