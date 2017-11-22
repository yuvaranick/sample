using SampleAuth1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using UrlGenaration;

namespace SampleAuth1.DBService
{
    public class SeedMyDb
    {

        public void FillDB(SampleAuth1.Models.MyDbContext context)
        {
            string[] Catgry = new string[] { "1000" };

            //define column of data table
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ASIN", typeof(string)));
            dt.Columns.Add(new DataColumn("DetailPageURL", typeof(string)));
            dt.Columns.Add(new DataColumn("LargeImage", typeof(string)));
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Brand", typeof(string)));
            dt.Columns.Add(new DataColumn("Category", typeof(int)));
            dt.Columns.Add(new DataColumn("OfferListingId", typeof(string)));
            dt.Columns.Add(new DataColumn("OtherInfo", typeof(string)));



            //setup browseNode and ItemPage
            GenerateURL url = new GenerateURL();

            foreach (string category in Catgry)
            {
                dt.Clear();
                url.BrowseNode = category;
                int bs = Convert.ToInt32(url.BrowseNode);
                for (int i = 1; i < 11; i++)
                {
                    string XmlResponse;
                    XmlResponse = string.Empty;
                    url.ItemPage = i.ToString();
                    DbClient c = new DbClient() { EndPoint = url.GetURL() };
                    //Get Response
                    XmlResponse = c.MakeRequest();

                    //process Response if not null
                    if (!string.IsNullOrEmpty(XmlResponse))
                    {
                        XElement ItemSearchResponse = XElement.Parse(XmlResponse);
                        XNamespace ns = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";
                        IEnumerable<XElement> Items = from node in ItemSearchResponse.Descendants(ns + "Item") select node;


                        //set data table column

                        foreach (var item in Items)
                        {
                            Product p = new Product();
                            p.ASIN = item.Element(ns + "ASIN").Value;
                            p.DetailPageURL = item.Element(ns + "DetailPageURL").Value;
                            p.LargeImage = item.Element(ns + "LargeImage")?.Element(ns + "URL")?.Value;
                            p.Category = bs;
                            p.OfferListingId = item.Descendants(ns + "OfferListingId")?.FirstOrDefault()?.Value;
                            p.Title = item.Descendants(ns + "Title")?.FirstOrDefault()?.Value;
                            //put switch for category
                            p.OtherInfo = "Author: " + item.Descendants(ns + "Author")?.FirstOrDefault()?.Value; ;
                            // dt.Rows.Add(p.DetailPageURL, p.ASIN, p.LargeImage, p.Title, p.Brand, p.Category, p.OfferListingId, p.OtherInfo);
                            context.Products.Add(p);
                        }
                    }
                }//end of category

                //connection string
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                /* SqlConnection cn = new SqlConnection(connectionString);
                 cn.Open();
                     using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cn))
                     {
                         bulkCopy.DestinationTableName =
                          "dbo.Products";

                         try
                         {
                             // Write from the source to the destination.
                             bulkCopy.WriteToServer(dt);
                         }
                         catch (Exception ex)
                         {
                             Console.WriteLine(ex.Message);
                         }
                     }
                     cn.Close();*/
            }
        }
    }
}