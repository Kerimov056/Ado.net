namespace TabloCore.Entity;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public string BookISBN { get; set; }

    public Book(int _id,string _name,int _pageCount,string _bookISbn)
    {
        Id= _id;
        Name= _name;
        PageCount= _pageCount;
        BookISBN= _bookISbn;
    }

}
