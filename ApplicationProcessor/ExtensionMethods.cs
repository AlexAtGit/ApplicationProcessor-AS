using System;
using System.ComponentModel;
using System.Reflection;

namespace ULaw.ApplicationProcessor
{
    static class ExtensionMethods
    {
        /// <summary>
        /// Returns the description associated with the specified enum
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();

            var enDesc = en.ToString();
            MemberInfo[] memInfo = type.GetMember(enDesc);

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(
                                              typeof(DescriptionAttribute),
                                              false);

                if (attrs != null && attrs.Length > 0)
                    enDesc = ((DescriptionAttribute)attrs[0]).Description;
            }
            return enDesc;
        }
    }
}
