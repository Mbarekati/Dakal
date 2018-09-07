using System;
using Dakal.Models;
using System.ComponentModel.DataAnnotations;

namespace Dakal.Api.ClientReqDto
{
    public class GetAdDTO
    {
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        public string username { get; set; }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5)]

        public string appPackageName { get; set; }

        [Required]
        [Range(10, 130)]
        public uint age { get; set; }

        [Required]
        public Gender gender { get; set; }
    }
}