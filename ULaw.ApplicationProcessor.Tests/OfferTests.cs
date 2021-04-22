using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ULaw.ApplicationProcessor.Enums;

namespace ULaw.ApplicationProcessor.Tests
{

    [TestClass]
    public class ApplicationSubmissionTests
    {
        private const string OfferEmailForFirstLawDegreeResultNoTitle = @"<html><body><h1>Your Recent Application from the University of Law</h1><p>Dear Test Tester,</p><p>Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.</p><br/><p>This offer will be subject to evidence of your qualifying Law degree at grade: 1st.</p><br/><p>Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the &pound;350.00 deposit fee to secure your place.</p><br/><p>We look forward to welcoming you to the University,</p><br/><p>Yours sincerely,</p><p>The Admissions Team, Faculty of Law</p></body></html>";
        private const string OfferEmailForFirstLawDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p>Dear Mr Test Tester,</p><p>Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.</p><br/><p>This offer will be subject to evidence of your qualifying Law degree at grade: 1st.</p><br/><p>Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the &pound;350.00 deposit fee to secure your place.</p><br/><p>We look forward to welcoming you to the University,</p><br/><p>Yours sincerely,</p><p>The Admissions Team, Faculty of Law</p></body></html>";
        private const string OfferEmailForTwoOneLawDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p>Dear Mr Test Tester,</p><p>Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.</p><br/><p>This offer will be subject to evidence of your qualifying Law degree at grade: 2:1.</p><br/><p>Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the &pound;350.00 deposit fee to secure your place.</p><br/><p>We look forward to welcoming you to the University,</p><br/><p>Yours sincerely,</p><p>The Admissions Team, Faculty of Law</p></body></html>";
        private const string OfferEmailForFirstLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p>Dear Mr Test Tester,</p><p>Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.</p><br/><p>This offer will be subject to evidence of your qualifying Law and Business degree at grade: 1st.</p><br/><p>Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the &pound;350.00 deposit fee to secure your place.</p><br/><p>We look forward to welcoming you to the University,</p><br/><p>Yours sincerely,</p><p>The Admissions Team, Faculty of Law</p></body></html>";
        private const string OfferEmailForTwoOneLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p>Dear Mr Test Tester,</p><p>Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.</p><br/><p>This offer will be subject to evidence of your qualifying Law and Business degree at grade: 2:1.</p><br/><p>Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the &pound;350.00 deposit fee to secure your place.</p><br/><p>We look forward to welcoming you to the University,</p><br/><p>Yours sincerely,</p><p>The Admissions Team, Faculty of Law</p></body></html>";

        private const string FurtherInfoEmailResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p>Dear Mr Test Tester,</p><p>Further to your recent application for our course reference: ABC123 starting on 22 September 2019, we are writing to inform you that we are currently assessing your information and will be in touch shortly.</p><br/><p>If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.</p><br/><p>Yours sincerely,</p><p>The Admissions Team, Faculty of Law</p></body></html>";
        private const string RejectionEmailForAnyThirdDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p>Dear Mr Test Tester,</p><p>Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.</p><br/><p>If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.</p><br/><p>Yours sincerely,</p><p>The Admissions Team, Faculty of Law</p></body></html>";

        [TestMethod]
        public void ApplicationSubmissionNoCourseCode()
        {
            Application thisSubmission = new Application("Law", "", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.first;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.law;

            Assert.ThrowsException<Exception>(() => thisSubmission.Process());
        }

        [TestMethod]
        public void ApplicationSubmissionNoFirstname()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.first;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.law;

            Assert.ThrowsException<Exception>(() => thisSubmission.Process());
        }

        [TestMethod]
        public void ApplicationSubmissionNoFaculty()
        {
            Application thisSubmission = new Application("", "ABC123", new DateTime(2019, 9, 22), "Mr", "", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.first;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.law;

            Assert.ThrowsException<Exception>(() => thisSubmission.Process());
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawDegree()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.first;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.law;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForFirstLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawDegreeNoTitle()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.first;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.law;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForFirstLawDegreeResultNoTitle);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawAndBusinessDegree()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.first;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.lawAndBusiness;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForFirstLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstEnglishDegree()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.first;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.English;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawDegree()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.twoOne;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.law;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneMathsDegree()
        {

            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.twoOne;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.maths;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawAndBusinessDegree()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.twoOne;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.lawAndBusiness;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoEnglishDegree()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.twoTwo;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.English;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoLawDegree()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.twoTwo;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.law;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithThirdDegree()
        {
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.third;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.maths;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, RejectionEmailForAnyThirdDegreeResult);
        }

        // Suggestions
        // 1. We need o test ToDescription() where no Description is provided.
        // 2. Common output above, e.g. "Your Recent Application from the University of Law" and "Yours sincerely" could put is a separate strings and inserted accordingly
        // 3. I would prefer specific string to be put in their relative tests if no referenced elsewhere
    }

}
