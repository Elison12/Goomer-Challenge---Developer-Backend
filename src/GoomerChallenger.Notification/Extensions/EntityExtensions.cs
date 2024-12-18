﻿using System.Reflection;
using GoomerChallenger.Notification.Attributes;
using GoomerChallenger.Notification.Entities;
using GoomerChallenger.Notification.Exceptions;
using GoomerChallenger.Notification.ValueObjects;
using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;

namespace GoomerChallenger.Notification.Extensions
{
    public static class EntityExtensions
    {
        private static Errors _errors;
        public static Errors CheckIfPropertiesIsNull<T>(this T obj) where T : Entity
        {
            _errors = new Errors();
            var properties = GetProperties<T>();

            foreach (var property in properties)
            {
                CheckProperty(obj, property);
            }
            return _errors;
        }
        #region Properties
        private static void CheckProperty<T>(T obj, PropertyInfo property) where T : Entity
        {
            if (property.GetValue(obj) is null)
            {
                AddError(property);
            }
            else if (property.PropertyType.BaseType == typeof(ValueObject))
            {
                var valueObjectProperty = property.GetValue(obj)!;
                var method = GetValueObjectValidationMethod();
                InvokeValueObjectValidationMethod(obj, valueObjectProperty, method);

            }
            else if (property.PropertyType.BaseType == typeof(Entity))
            {
                var entityProperty = property.GetValue(obj)!;
                var method = GetEntityValidationMethod();
                InvokeEntityValidationMethod(obj, entityProperty, method);
            }
        }

        private static List<PropertyInfo> GetProperties<T>() where T : Entity
        {
            return typeof(T)
                  .GetProperties()
                  .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(IfNullAttribute)))
                  .ToList();
        }

        #endregion

        #region Entity

        private static MethodInfo? GetEntityValidationMethod()
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            string namespaceName = thisAssembly.GetName().Name.ToString().Replace("-", "_");
            string name = $"{namespaceName}.Extensions.EntityExtensions";

            return thisAssembly.GetType(name)!.GetMethods().FirstOrDefault(x => x.Name.Equals("CheckIfPropertiesIsNull"));
        }

        private static void InvokeEntityValidationMethod<T>(T obj, object entityProperty, MethodInfo? method) where T : Entity
        {
            var generic = method.MakeGenericMethod(entityProperty.GetType());
            var result = generic.Invoke(obj, new object[] { entityProperty });

            if (result != null && result.GetType() == typeof(Errors))
            {
                var errorsResult = (Errors)result;
                foreach (var error in errorsResult)
                {
                    _errors.Add(error);
                }
            }
        }

        #endregion

        #region ValueObject

        private static MethodInfo? GetValueObjectValidationMethod()
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            string namespaceName = thisAssembly.GetName().Name!.ToString().Replace("-", "_");
            string name = $"{namespaceName}.Extensions.ValueObjectExtensions";

            return thisAssembly.GetType(name)!.GetMethods().FirstOrDefault(x => x.Name.Equals("CheckIfPropertiesIsNull"));
        }
        private static void InvokeValueObjectValidationMethod<T>(T obj, object valueObjectProperty, MethodInfo? method) where T : Entity
        {
            var generic = method.MakeGenericMethod(valueObjectProperty.GetType());

            var result = generic.Invoke(obj, new object[] { valueObjectProperty });

            if (result != null && result.GetType() == typeof(Errors))
            {
                var errorsResult = (Errors)result;
                foreach (var error in errorsResult)
                {
                    _errors.Add(error);
                }
            }
        }

        #endregion

        #region Add Error

        private static void AddError(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute(typeof(IfNullAttribute)) ?? throw new CustomAttributeNotDefineException($"Atributo para a propriedade não foi definido.");

            var errorMessage = ((IfNullAttribute)attribute).GetErrorMessage();

            var errorDictionary = new Dictionary<string, string>
                    {
                        { property.Name, errorMessage }
                    };

            _errors.Add(errorDictionary);
        }

        #endregion

    }
}
