using AutoMapper;
using Data.Models;
using LibrarySystem.Data.DTOs;
using LibrarySystem.Data.Dtos.Category;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LibrarySystem.Data.Dtos.Author;
using LibrarySystem.Data.Dtos.Book;

namespace LibrarySystem.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<BookCopy, BookCopyDto>().ReverseMap();
            CreateMap<BookCopy, CreateBookCopyDto>().ReverseMap();
            CreateMap<BookCopy, UpdateBookCopyDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Loan, LoanDto>().ReverseMap();
            CreateMap<Loan, CreateLoanDto>().ReverseMap();
            CreateMap<Loan, UpdateLoanDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
        }
    }
}
