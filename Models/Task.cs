namespace ToDo_List.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public bool IsComplete { get; set; }
        public string Status { get; set; } //  to track task state
        public string Priority { get; set; } // Added for task urgency
        public DateTime DueDate { get; set; } //  deadline
        public DateTime CreationDate { get; set; } 
        public DateTime LastModifiedDate { get; set; } // Added last update timestamp
        public string AssignedTo { get; set; } //  responsible person
        
        
        
        
    }


}