using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberiAPI.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
      //  public DateTime DataAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        public City  City { get; set; }

    }
}
