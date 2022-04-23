using DotNet_Design_Patterns_Vol2.Chapter_08.ApplicationController;
using DotNet_Design_Patterns_Vol2.Chapter_08.FrontController;
using DotNet_Design_Patterns_Vol2.Chapter_08.ModelViewController;
using DotNet_Design_Patterns_Vol2.Chapter_08.TwoStepView;
using System.Text;
using DotNet_Design_Patterns_Vol2.Chapter_09.Data_Transfer_Object;
using DotNet_Design_Patterns_Vol2.Chapter_12.Gateway;
using DotNet_Design_Patterns_Vol2.Chapter_12.ValueObject;
using DotNet_Design_Patterns_Vol2.Chapter_12.ServiceStub;
using DotNet_Design_Patterns_Vol2.Chapter_12.Money;
using DotNet_Design_Patterns_Vol2.Chapter_12.SpecialCase;
using DotNet_Design_Patterns_Vol2.Chapter_12.Registry;
using System.Diagnostics;
using DotNet_Design_Patterns_Vol2.Chapter_12.Plugin;

//#region Plugin

//DotNet_Design_Patterns_Vol2.Chapter_12.Plugin.Environment.Name = "prod";
//AuthorService.Add();

//#endregion

//#region Registry

//Registry.BookFinder().GetAuthorBooks(1);
//Registry.InitializeStub();
//((BookFinderStub)Registry.BookFinder()).GetAuthorBooks(1);

//#endregion

//#region Special Case

//var searchResult = new AuthorRepository().Find(3);
//if (searchResult is AuthorNotFound)
//{
//    Console.WriteLine("Author not found!");
//}
//else
//{
//    Console.WriteLine(searchResult.LastName);
//}
//#endregion

//#region Money

//Money first = new Money(2, 50, Currency.Dollar);
//Console.WriteLine("NEW");
//Console.WriteLine(first.Amount);
//Console.WriteLine(first.Fraction);

//Money second = new Money(3, 60, Currency.Dollar);
//first.Add(second);
//Console.WriteLine("ADD");
//Console.WriteLine(first.Amount);
//Console.WriteLine(first.Fraction);

//first.Subtract(new Money(10, 5, Currency.Dollar));
//Console.WriteLine("SUBTRACT");
//Console.WriteLine(first.Amount);
//Console.WriteLine(first.Fraction);

//first.Multiply(1.5);
//Console.WriteLine("MULTIPLY");
//Console.WriteLine(first.Amount);
//Console.WriteLine(first.Fraction);

//Console.WriteLine(first.Equals(second));
//Console.WriteLine(first == second);
//Console.WriteLine(first != second);
//Console.WriteLine(first > second);
//Console.WriteLine(first < second);
//Console.WriteLine(first >= second);
//Console.WriteLine(first <= second);

//#endregion

//#region ServiceStub

//IInquiryService.InquiryService = new InquiryServiceStub();

//var result = IInquiryService.InquiryService.Inquiry("2740076223");


//#endregion

//#region ValueObject

//Publisher publisher = new Publisher();
//Address address1 = new Address("شهید بهشتی", "کاووسی فر", "نکیسا", "رهنما");
//Address address2 = new Address("شهید بهشتی", "کاووسی فر", "نکیسا", "رهنما");
//if (address1 == address2)
//    publisher.Addresses.Add(address1);
//else
//    publisher.Addresses.AddRange(new List<Address> { address1, address2 });
//#endregion

//#region Gateway

//var result = await WebAPIGateway.GetDataAsync("https://jsonplaceholder.typicode.com/posts");

//#endregion

//#region DTO

//var author = new Author()
//{
//    FirstName = "vahid",
//    LastName = "farajmandian",
//    AuthorId = 1,
//    IsActive = true,
//    Books = new List<Book>
//    {
//        new Book
//        {
//            BookId=1,
//            Title="Desing Patterns in .NET",
//            Language="fa"
//        },
//        new Book
//        {
//            BookId=2,
//            Title="Programming in C#",
//            Language="fa"
//        }
//    }
//};
//var t = author.ToDTO();
//var y = t.ToModel();

//#endregion

//#region Application Controller

//FrontController controller = new();
//controller.ReceiveRequest(new Uri("http://abc.com/leasing?model=bmw&state=1&date=20220101#return"));
//Console.WriteLine("+++++++++++++++++++++++++++++");
//controller.ReceiveRequest(new Uri("http://abc.com/leasing?model=bmw&state=2&date=20220101#return"));
//Console.WriteLine("+++++++++++++++++++++++++++++");
//controller.ReceiveRequest(new Uri("http://abc.com/leasing?model=bmw&state=1&date=20220101#damage"));
//Console.WriteLine("+++++++++++++++++++++++++++++");
//controller.ReceiveRequest(new Uri("http://abc.com/leasing?model=bmw&state=2&date=20220101#damage"));

//#endregion

//#region Two Step View

//FirstStepAuthor firstStep = new FirstStepAuthor();
//firstStep.FirstStepTransformer();

//SecondStepAuthor secondStep = new SecondStepAuthor();
//secondStep.SecondStepTransformer();

//#endregion

//#region TransformView

//AuthorTransformer transformer = new AuthorTransformer();
//var result = transformer.Transform(new DatabaseGateway().GetAuthors());

//#endregion

//#region FrontController

//MainHandler  handler = new MainHandler();
//handler.ReceiveRequest("http://a.com/author/get");

//#endregion

//#region Model View Controller

//UserController controller = new UserController();
//IView loginView = controller.LoginIndex();
//loginView = ((LoginView)loginView).Login();
//loginView = ((DashboardView)loginView).Logout();


//#endregion

//#region Query Object

//QueryObject qb = new QueryObject();
//qb.Criterias.Add(Criteria.GreaterThan(nameof(Person.Age), 33));
//var result = qb.Execute();

//#endregion

/*
#region Metadata Mapping

PersonMapper mapper = new PersonMapper();
var metadata = mapper.GetMetadata();
var result = mapper.Find(1);


#endregion

#region "Foreign Key Mapping"
var book = new DotNet_Design_Patterns_Vol2.Chapter_06.ForeignKeyMapping.Book()
{
    BookId = 1,
    Title = "Design Patterns in .NET",
    PublishDate = new DateOnly(2020, 10, 01),
    Detail = new BookDetail
    {
        BookId = 1,
        File = Array.Empty<byte>()
    },
    Comments = new List<Comment>()
    {
        new Comment()
        {
            CommentId = 1,
            Text = "good book"
        }
    }
};

var comment2 = new Comment
{
    CommentId = 2,
    Book = book,
    Text = "how can I buy this book?"
};

#endregion

#region "Association Table Mapping"

var objBook1 = new DotNet_Design_Patterns_Vol2.Chapter_06.AssociationTableMapping.Book()
{
    BookId = 1,
    Title = "Design Patterns in .NET vol 1",
    PublishDate = new DateOnly(2021,10,01)
};
var objBook2 = new DotNet_Design_Patterns_Vol2.Chapter_06.AssociationTableMapping.Book()
{
    BookId = 2,
    Title = "Design Patterns in .NET vol 2",
    PublishDate = new DateOnly(2022, 05, 01)
};
var objAuthor1 = new Author()
{
    AuthorId = 1001,
    FirstName = "Vahid",
    LastName = "Farahmandian"
};
var objAuthor2 = new Author()
{
    AuthorId = 1002,
    FirstName = "Ali",
    LastName = "Hassani"
};

objBook1.Authors.Add(objAuthor1);
objBook2.Authors.Add(objAuthor1);
objBook2.Authors.Add(objAuthor2);

#endregion

*/
Console.Read();