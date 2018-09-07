using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dakal.Api.DTO
{
    public class UserCompletedSeeingAd
    {
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        public string username { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long adId { get; set; }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        public string appPackageName { get; set; }
    }
}