using codeWiki.Database;
using codeWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace codeWiki.Controllers
{
    public class RecordController : ApiController
    {
        DatabaseContext db = new DatabaseContext();

        public IEnumerable<Record> GetRecords()
        {
            return db.Records.ToList();
        }
        
        public Record GetRecord(int id)
        {
            return db.Records.Find(id);
        }
        [HttpPost]
        public HttpResponseMessage AddRecord(Record model)
        {
            try
            {
                db.Records.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    return response;
                }
                return null;
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateRecord(int id, Record model)
        {
            try
            {
                if (id == model.Id)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                }
                else
                {

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    return response;
                }
                return null;

            }
        }


        public HttpResponseMessage DeleteRecord(int id)
        {
            try
            {
                Record record = db.Records.Find(id);
                if (record != null)
                {
                    db.Records.Remove(record);
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return response;
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    return response;
                }
            }

            return null;

        }

    }
}
