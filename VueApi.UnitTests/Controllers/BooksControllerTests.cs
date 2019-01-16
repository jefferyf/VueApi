using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VueApi.Controllers;
using VueApi.Models;
using VueApi.Repositories.Interfaces;
using VueApi.Services;

namespace VueApi.UnitTests.Controllers
{
    [TestFixture]
    class BooksControllerTests
    {
        private BooksController _booksController;
        private Mock<IBookRepository> _bookRepository;

        [SetUp]
        public void SetUp()
        {
            _bookRepository = new Mock<IBookRepository>();
            _booksController = new BooksController(_bookRepository.Object);
        }

        [Test]
        public void BookExists_BookIsFound_ReturnsTrue()
        {
            _bookRepository.Setup(br => br.FindBookAsync(1))
                .Returns(Task.FromResult( new Book { Name = "book", Year = 2019 }));
            
            var result = _booksController.GetBook(1);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void BookExists_BookIsNotFound_ReturnsFalse()
        {
            _bookRepository.Setup(br => br.FindBookAsync(1))
                .Returns(Task.FromResult<Book>(null));

            var result = _booksController.GetBook(1);
            
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }
            
    }
}
