using AutoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoTest.Clases
{
    public class MovementsHelper : IDisposable
    {
        private static AtestContext db = new AtestContext();

        public void Dispose()
        {
            db.Dispose();
        }

        public static Response NewTest(NewTestView view, string userName)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var user = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
                    var testHeader = new TestHeader
                    {
                        UserID = user.UserID,
                        Date = view.Date,
                        StateID = DBHelper.GetState("created", db),
                    };

                    db.TestHeaders.Add(testHeader);
                    db.SaveChanges();

                    var details = db.TestSummaryDetailTmps.Where(tsdt => tsdt.UserName == userName).ToList();
                    var questionDetails = db.TestQuestionDetailTmps.Where(tqdt => tqdt.UserName == userName).ToList();
                    foreach (var detail in details)
                    {
                        var testDetail = new TestDetail
                        {
                            TestHeaderID = testHeader.TestHeaderID,
                            //SubCategoryID = detail.SubCategoryID,
                            SubCategoryName = detail.SubCategoryName,
                            Value = int.Parse(detail.TestAnswer.Value),
                            UserID = user.UserID,
                        };

                        db.TestDetails.Add(testDetail);
                        db.TestSummaryDetailTmps.Remove(detail);
                    }

                    foreach (var detail2 in questionDetails)
                    {
                        var testDetailQuestion = new TestDetailQuestion
                        {
                            TestHeaderID = testHeader.TestHeaderID,
                            //SubCategoryID = detail2.SubCategoryID,
                            QuestionName = detail2.QuestionName,
                            Value = int.Parse(detail2.TestAnswer.Value),
                            UserID = user.UserID,
                        };

                        db.TestDetailQuestions.Add(testDetailQuestion);
                        db.TestQuestionDetailTmps.Remove(detail2);
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    return new Response { Succeeded = true, };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new Response
                    {
                        Message = ex.Message,
                        Succeeded = false,
                    };
                }
            }
        }
    }
}