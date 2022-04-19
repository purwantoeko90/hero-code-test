using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Model
{
    public class Pax
    {
        public long id { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public int age { get; set; }
        public string notes { get; set; }
        public string nationalityIso { get; set; }
        public string gender { get; set; }
        public string externalReference { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string postCode { get; set; }
    }

    public class Schedule
    {
        public int id { get; set; }
        public int productId { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public Nullable<int> overnights { get; set; }
        public int duration { get; set; }
        public string durationText { get; set; }
        public int scheduleId { get; set; }
        public int availability { get; set; }
        public string title { get; set; }
        public string color { get; set; }
        public bool available { get; set; }
        public object cta { get; set; }
        public object ctd { get; set; }
        public object minStay { get; set; }
        public object maxStay { get; set; }
        public bool isOpenDated { get; set; }
        public object allowAllDayEntry { get; set; }
        public object allDayEventLastAdmittance { get; set; }
        public bool isDeleted { get; set; }
    }


    public class Product
    {
        public int id { get; set; }
        public int category { get; set; }
        public bool liveAvailability { get; set; }
        public string name { get; set; }
        public string supplierName { get; set; }
        public string supplierLogoUrl { get; set; }
        public int durationMinutes { get; set; }
        public string durationText { get; set; }
        public string supplierBranchName { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public List<Imageurl> imageUrls { get; set; }
        public List<string> tags { get; set; }
        public List<Location> locations { get; set; }
        public List<string> mapUrls { get; set; }
        public string supplierId { get; set; }
        public List<Product> subProducts { get; set; }
        public decimal advertisedPrice { get; set; }
        public string currencyIso { get; set; }
        public decimal pricedPerXPax { get; set; }
        public string supplierProductCode { get; set; }
    }

    public class Imageurl
    {
        public int type { get; set; }
        public string url { get; set; }
    }

    public class Location
    {
        public int type { get; set; }
        public string address { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }


    public class Booking
    {
        public string name { get; set; }
        public List<Bookingproduct> bookingProducts { get; set; }
    }

    public class Bookingproduct
    {
        public int productId { get; set; }
        public List<string> paxId { get; set; }
        public string agentReference { get; set; }
        public int nights { get; set; }
        public List<Paxroomid> paxRoomId { get; set; }
    }

    public class Paxroomid
    {
        public int room { get; set; }
        public string paxId { get; set; }
    }


    public class ProductPricing
    {
        public int productId { get; set; }
        public string dateCheckIn { get; set; }
        public string dateCheckOut { get; set; }
        public decimal rrp { get; set; }
        public decimal commission { get; set; }
        public string currencyIso { get; set; }
    }


    public class Payment
    {
        public string receipt { get; set; }
        public string bookingId { get; set; }
        public string paxId { get; set; }
        public decimal amount { get; set; }
        public int method { get; set; }
        public bool isFinal { get; set; }
    }


    public class RootobjectProduct
    {
        public decimal searchTime { get; set; }
        public string numberResults { get; set; }
        public decimal rowVersion { get; set; }
        public List<Product> products { get; set; }
    }

    public class Requiredinformation
    {
        public int id { get; set; }
        public object addonId { get; set; }
        public int type { get; set; }
        public bool perPax { get; set; }
        public object paxId { get; set; }
        public string question { get; set; }
        public List<Possibleanswer> possibleAnswers { get; set; }
        public string answer { get; set; }
    }

    public class Possibleanswer
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }


}
