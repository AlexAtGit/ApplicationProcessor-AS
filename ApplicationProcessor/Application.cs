using System;
using System.Text;
using ULaw.ApplicationProcessor.Enums;  

namespace ULaw.ApplicationProcessor
{
    public class Application
    {
        private const string ContactEmail = "AdmissionsTeam@Ulaw.co.uk";
        private const decimal _depositForLaw = 350.0m;

        public Application()
        {
            this.ApplicationId = new Guid();
        }
        public Application(string faculty, string courseCode, DateTime? startdate, string title, string firstName, string lastName, DateTime dateOfBirth, bool requiresVisa) : this()
        {
            Faculty = faculty;
            CourseCode = courseCode;
            StartDate = startdate;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            RequiresVisa = requiresVisa;
            DateOfBirth = dateOfBirth;
        }

        public Guid ApplicationId { get; private set; }
        public string Faculty { get; private set; }
        public string CourseCode { get; private set; }
        public DateTime? StartDate { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public bool RequiresVisa { get; private set; }

        public DegreeGradeEnum DegreeGrade { get; set; } = DegreeGradeEnum.None;
        public DegreeSubjectEnum DegreeSubject { get; set; } = DegreeSubjectEnum.None;

        public string Process()
        {
            if (DegreeGrade == DegreeGradeEnum.None || DegreeSubject == DegreeSubjectEnum.None || string.IsNullOrWhiteSpace(Faculty) || string.IsNullOrWhiteSpace(CourseCode)) throw new Exception("Unspecified subject, grade, faculty, or course code!");
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)) throw new Exception("Unspecified student name");
            if (!StartDate.HasValue) throw new Exception("Unspecified start date for the course");

            var result = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");

            result.Append(string.IsNullOrWhiteSpace(Title) ? $"<p>Dear {FirstName} {LastName},</p>" : $"<p>Dear {Title} {FirstName} {LastName},</p>");

            if (DegreeGrade == DegreeGradeEnum.twoTwo)
            {
                result.Append($"<p>Further to your recent application for our course reference: {CourseCode} starting on {StartDate.Value.ToLongDateString()}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.</p>");
                result.Append($"<br/><p>If you wish to discuss any aspect of your application, please contact us at {ContactEmail}.</p>");
            }
            else
            {
                if (DegreeGrade == DegreeGradeEnum.third)
                {
                    result.Append("<p>Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.</p>");
                    result.Append($"<br/><p>If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at {ContactEmail}.</p>");
                }
                else
                {
                    if (DegreeSubject == DegreeSubjectEnum.law || DegreeSubject == DegreeSubjectEnum.lawAndBusiness)
                    {
                        result.Append($"<p>Further to your recent application, we are delighted to offer you a place on our course reference: {CourseCode} starting on {StartDate.Value.ToLongDateString()}.</p>");
                        result.Append($"<br/><p>This offer will be subject to evidence of your qualifying {DegreeSubject.ToDescription()} degree at grade: {DegreeGrade.ToDescription()}.</p>");
                        result.Append($"<br/><p>Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the &pound;{_depositForLaw:0.00} deposit fee to secure your place.</p>");
                        result.Append("<br/><p>We look forward to welcoming you to the University,</p>");
                    }
                    else
                    {
                        result.Append($"<p>Further to your recent application for our course reference: {CourseCode} starting on {StartDate.Value.ToLongDateString()}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.</p>");
                        result.Append($"<br/><p>If you wish to discuss any aspect of your application, please contact us at {ContactEmail}.</p>");
                    }
                }
            }

            result.Append("<br/><p>Yours sincerely,</p>");
            result.Append($"<p>The Admissions Team, Faculty of {Faculty}</p>");
            result.Append("</body></html>");

            return result.ToString();
        }
    }
}

