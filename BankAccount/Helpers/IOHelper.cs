// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOHelper.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BankAccount.Models;
using BankAccount.Repositories;

namespace BankAccount.Helpers
{
    public class IOHelpers
    {
        /// <summary>
        /// Read the list of objects from a file.
        /// </summary>
        public static List<T2> ReadFromFile<T1, T2>(string filePath, bool inputData = false)
            where T1 : EntityBase
            where T2 : EntityBase
        {
            using (var dbContext = new BankAccountContext())
            {
                var repository = new RepositoryBaseEF<T1>(dbContext);

                string json = string.Empty;

                if (repository.Get().Count <= 0 || inputData)
                {
                    // Get the current WORKING directory (i.e. \bin\Debug)
                    string workingDirectory = Directory.GetCurrentDirectory();

                    // Get the current PROJECT directory
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

                    filePath = projectDirectory + filePath;
                    json = File.ReadAllText(filePath);
                }

                return json == string.Empty ? new List<T2>() : Newtonsoft.Json.JsonConvert.DeserializeObject<List<T2>>(json);
            }
        }

        public static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object source)
        {
            return from p in source.GetType().GetProperties()
                       // where p.PropertyType == typeof(T)
                   select new KeyValuePair<string, T>(p.Name, (T)Convert.ChangeType(p.GetValue(source), typeof(T)));
        }

        public static T ToObject<T>(Dictionary<string, string> source)
            where T : EntityBase, new()
        {
            var destination = new T();
            var destinationType = destination.GetType();

            foreach (var s in source)
            {
                var item = destinationType.GetProperty(s.Key);
                var itemType = item.PropertyType;
                if (itemType.IsEnum)
                {
                    item.SetValue(destination, Enum.Parse(itemType, s.Value, true), null);
                }
                else
                {
                    item.SetValue(destination, Convert.ChangeType(s.Value, item.PropertyType), null);
                }
            }

            return destination;
        }

        public static List<T1> EntitiesList<T1, T2>(List<T2> entitiesDTO, Dictionary<string, DomainObjectItem> BusinessToDomainObjectPropertyMap)
            where T1 : EntityBase, new()
            where T2 : EntityBase
        {
            var entities = new List<T1>();
            entitiesDTO.ForEach(c =>
            {
                var obj1 = PropertiesOfType<string>(c);
                var obj2 = PropertiesOfType<string>(new T1());
                var obj3 = obj2.ToDictionary(x => x.Key, x => x.Value);
                foreach (var prop1 in obj1)
                {
                    if (BusinessToDomainObjectPropertyMap.ContainsKey(prop1.Key))
                    {
                        var mapEntry = BusinessToDomainObjectPropertyMap.FirstOrDefault(x => x.Key == prop1.Key).Value.DomainObjectPropertyName;

                        foreach (var prop2 in obj2)
                        {
                            if (mapEntry.Equals(prop2.Key))
                            {
                                string name = prop2.Key;
                                string value = prop1.Value;
                                obj3.Remove(name);
                                obj3.Add(name, value);
                                break;
                            }
                        }
                    }
                }
                var entity = ToObject<T1>(obj3);
                entities.Add(entity);
            });
            foreach (T1 entity in entities)
            {
                entity.CreatedDate = DateTime.Now.ToString();
                entity.CreatedBy = "Aziz Azimi";
            }

            return entities;
        }
    }
}
