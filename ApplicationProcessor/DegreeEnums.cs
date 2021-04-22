using System.ComponentModel;

namespace ULaw.ApplicationProcessor.Enums
{
    public enum DegreeGradeEnum : int
    {
        [DescriptionAttribute("None")]
        None,
        [DescriptionAttribute("1st")]
        first,
        [DescriptionAttribute("2:1")]
        twoOne,
        [DescriptionAttribute("2:2")]
        twoTwo,
        [DescriptionAttribute("3rd")]
        third
    }
    
    public enum DegreeSubjectEnum : int
    {
        [DescriptionAttribute("None")]
        None,
        [DescriptionAttribute("Law")]
        law,
        [DescriptionAttribute("Law and Business")]
        lawAndBusiness,
        [DescriptionAttribute("Maths")]
        maths,
        [DescriptionAttribute("English")]
        English
    }
}
