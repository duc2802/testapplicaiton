using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Collections;

namespace ResourceMassageManager
{
    public class LocalizeManager
    {
        /// <summary>
        /// Default resource name for all Fault Exception
        /// </summary>
        public const string ErrorMessageResourceName = "ResourceMassageManager.ErrorMessage";

        public const string InfoMessageResourceName = "ResourceMassageManager.InfoMessage";

        /// <summary>
        /// Get resource String for default localize
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceFile"></param>
        /// <param name="resourceCode"></param>
        /// <returns></returns>
        public static String GetString(System.Reflection.Assembly assembly, String resourceFile, String resourceCode)
        {
            if (assembly != null && !string.IsNullOrEmpty(resourceFile) && !string.IsNullOrEmpty(resourceCode))
            {
                System.Resources.ResourceManager resource = new System.Resources.ResourceManager(resourceFile, assembly);
                return resource.GetString(resourceCode);
            }

            return null;
        }

        /// <summary>
        /// Get resource String
        /// </summary>
        /// <param name="resourceFile"></param>
        /// <param name="resourceCode"></param>
        /// <returns></returns>
        public static String GetString(String resourceFile, String resourceCode)
        {
            return GetString(typeof(ResourceMassageManager.LocalizeManager).Assembly, resourceFile, resourceCode);
        }

        /// <summary>
        /// get error message string
        /// </summary>
        /// <param name="errorMessageClient"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static String GetErrorMessage(ErrorMessageClient errorMessageClient, params object[] parameters)
        {
            return string.Format(
                LocalizeManager.GetString(LocalizeManager.ErrorMessageResourceName,
                errorMessageClient.ToString()),
                parameters);
        }

        /// <summary>
        /// get info message string
        /// </summary>
        /// <param name="infoMessageClient"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static String GetInfoMessage(InfoMessageClient infoMessageClient, params object[] parameters)
        {
            return string.Format(
                LocalizeManager.GetString(LocalizeManager.InfoMessageResourceName,
                infoMessageClient.ToString()),
                parameters);
        }

        /// <summary>
        /// Get a list of resource key in a resrouce
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="culture"></param>
        /// <param name="resourceFile"></param>
        /// <returns></returns>
        public static List<String> GetListResourceKey(System.Reflection.Assembly assembly, CultureInfo culture, String resourceFile)
        {
            List<String> result = new List<string>();
            System.Resources.ResourceManager resource = new System.Resources.ResourceManager(resourceFile, assembly);
            ResourceSet resourceSet = resource.GetResourceSet(culture, true, true);
            IDictionaryEnumerator enumerator = resourceSet.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Key.ToString());
            }
            return result;
        }
    }
}
