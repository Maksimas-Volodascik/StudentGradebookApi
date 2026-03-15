namespace StudentGradebookApi.DTOs.SharedDto
{
    public class QueryDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int MaxSize = 100;
        public int ValidPageSize
        {
            
            get { return (PageSize > MaxSize || PageSize < 1) ? 20 : PageSize; }
        }
        //sortBy
        //sortDirection =asc/desc

        //filter by
    }
}
