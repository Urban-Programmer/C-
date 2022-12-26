public class Book {
  public string Title;
  public string Author;
  public string Publisher;
  public int Pages;
  public string Description;

}

public class Solution {
  
  private static void Print(Book Book){
      Console.WriteLine($"Author: {Book.Author} \n, Title: {Book.Title} \n, Publisher: {Book.Publisher} \n, Description: {Book.Description} \n");
  }
  
  public static void Main(){
    Book book1 = new Book();

    book1.Author = "New Writter";
    book1.Title = "First Book";
    book1.Publisher = "Publisher 1";

    Book book2 = new Book();
    book2.Author = "New Writter";
    book2.Title="Second Book";
    book2.Publisher = "Publisher 2";
    book2.Description = "Interesting read";

    Print(book1);
    Print(book2);
    
  }
}