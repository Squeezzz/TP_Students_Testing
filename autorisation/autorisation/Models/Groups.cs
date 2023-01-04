using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace autorisation.Models
{
    public class Groups
    {
        public string Name { get; set; }
        public int Well { get; set; }

        public virtual ICollection<Tests> Tests { get; set; }
        public virtual ICollection<A_list_of_users> A_list_of_users { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Groups()
        {
            ImagePath = "~/AppFiles/Images/default.png";
        }

        public static implicit operator Groups(string v)
        {
            throw new NotImplementedException();
        }
    }
}