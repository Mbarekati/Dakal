using System;
using Dakal.Models;
using System.ComponentModel.DataAnnotations;

namespace Dakal.AppService.DTO
{
    public class PredictAdvertisementResponse
    {
        public int banking { get; set; }
        public int education { get; set; }
        public int entertainment { get; set; }
        public int family { get; set; }
        public int health { get; set; }
        public int movie { get; set; }
        public int music { get; set; }
        public int travel { get; set; }


    }
}