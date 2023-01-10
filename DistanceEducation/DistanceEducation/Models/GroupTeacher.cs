using Microsoft.Extensions.Hosting;

namespace DistanceEducation.Models
{
    public class GroupTeacher
    {

        public int GroupsId { get; set; }
        public Group group { get; set; }

        public int TeachersId { get; set; }
        public Teacher teacher { get; set; }

    }
}
