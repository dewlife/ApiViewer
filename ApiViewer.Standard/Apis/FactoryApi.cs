////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	apis\factoryapi.cs
//
// summary:	Implements the factoryapi class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiViewer.Standard.Apis
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A factory api. </summary>
    ///
    /// <remarks>   James Coates, 8/26/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class FactoryApi
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an API using the given identifier. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="id">   The Identifier to get. </param>
        ///
        /// <returns>   An API. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Api Get(string id)
        {
            Api instance = null;
            var className = id;
            var requiredClass = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where string.Equals(type.Name, className, StringComparison.OrdinalIgnoreCase)
                                 select type).FirstOrDefault();
            if (requiredClass != null)
                instance = (Api)Activator.CreateInstance(requiredClass);

            return instance;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an API using the given identifier. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="id">   The Identifier to get. </param>
        ///
        /// <returns>   An API. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Api GetFromName(string id)
        {
            Api instance = null;

            var type = typeof(Api);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var t in types)
            {
                if (t.Name != "Api")
                {
                    if (id == ((Api)Activator.CreateInstance(t)).Name)
                        return (Api)Activator.CreateInstance(t);
                }
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the apis. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="category"> (Optional) The category. </param>
        ///
        /// <returns>   The apis. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<KeyValuePair<string, string>> GetApis(string category = "ALL")
        {
            var values = new List<KeyValuePair<string, string>>();

            var type = typeof(Api);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach(var t in types)
            {
                if (t.Name != "Api")
                {
                    if (category == "ALL" || category == ((Api)Activator.CreateInstance(t)).Category)
                        values.Add(new KeyValuePair<string, string>(t.Name, ((Api)Activator.CreateInstance(t)).Name));
                }
            }
            
            values = values.OrderBy(o => o.Value).ToList();

            return values;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the categories. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <returns>   The categories. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<string> GetCategories()
        {
            var values = new List<string>();

            var type = typeof(Api);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var t in types)
            {
                if (t.Name != "Api")
                {
                    var found = false;
                    foreach(var v in values)
                    {
                        if (((Api)Activator.CreateInstance(t)).Category == v)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        values.Add(((Api)Activator.CreateInstance(t)).Category);
                }
            }

            values = values.OrderBy(o => o.ToString()).ToList();

            return values;
        }


    }
}
