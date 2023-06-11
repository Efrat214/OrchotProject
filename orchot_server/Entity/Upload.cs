//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
namespace Entity
{
    public partial class Upload
    {
        public int Id { get; set; }

        public string? DocumentName { get; set; }

        public string? Organization { get; set; }

        public string? BusinessUnit { get; set; }

        public string? Department { get; set; }

        public string? CreateBy { get; set; }

        public string? MailAddress { get; set; }

        public string? DocType { get; set; }

        public string? DocLink { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}
