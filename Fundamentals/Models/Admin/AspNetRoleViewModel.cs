namespace Fundamentals.Models.Admin
{
    public class AspNetRoleViewModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public bool IsChecked { get; set; }

        public bool IsDirty { get; set; }

        public bool IsAssigned { get; set; }
    }
}