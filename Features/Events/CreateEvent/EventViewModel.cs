// Features/Events/CreateEvent/EventViewModel.cs
using System.ComponentModel.DataAnnotations;


namespace MeetApp.Features.Events.CreateEvent
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(maximumLength:100)]
        public string ? Title  { get; set; }

        [StringLength(maximumLength:500)]
        public string ? Description { get; set; }

        [Required]
        public DateOnly BeginDate { get; set; }
        [Required]
        public TimeOnly BeginTime { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string ? Location { get; set; }
        public string ? MeetUpLink { get; set; }
        [Required]
        public string ? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }
        public int OrganizerId { get; set; }

        public EventViewModel()
        {
            BeginDate = DateOnly.FromDateTime(DateTime.Now);
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddHours(1));
            BeginTime = TimeOnly.FromDateTime(DateTime.Now);
            EndTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(1));
        }

        public bool ValidateDates()
        {
            if(BeginDate > EndDate)
            {
                return false;
            }
            if(BeginDate == EndDate && BeginTime >= EndTime)
            {
                return false;
            }
            return true;
        }

        public bool ValidateLocation()
        {
            if(Category == MeetupCategoriesEnum.Inperson.ToString() && string.IsNullOrWhiteSpace(Location))
            {
                return false;
            }
            return true;
        }

        public bool ValidateMeetupLink()
        {
            if(Category == MeetupCategoriesEnum.Online.ToString() && string.IsNullOrWhiteSpace(MeetUpLink))
            {
                return false;
            }
            return true;
        }

        
    }

}