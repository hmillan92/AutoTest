using AutoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoTest.Clases
{
    public class DBHelper
    {
        public static Response SaveChanges(AtestContext db)
        {
            try
            {
                db.SaveChanges();
                return new Response { Succeeded = true };
            }
            catch (Exception ex)
            {
                var response = new Response { Succeeded = false };
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    response.Message = "There are a record with the same value.";
                }
                else if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "The record can't be deleted because it has related records.";
                }
                else
                {
                    response.Message = ex.Message;
                }
                return response;
            }
        }

        public static int GetState(string stateName, AtestContext db)
        {
            var state = db.States.Where(s => s.StateName == stateName).FirstOrDefault();
            if (state == null)
            {
                state = new State { StateName = stateName, };
                db.States.Add(state);
                db.SaveChanges();
            }
            return state.StateID;
        }
    }
}